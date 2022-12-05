/*
 * GameManager.cs
 * Carson Sloan
 * Control game infrastructure and flow.
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


/*
 * Class to control UI elements and game event execution. Extends the Singleton
 * class to follow the singleton pattern.
 *
 * PRIVATE PROPERTIES:
 * playerObject - the player prefab controlled by the user, updated by start menu
 * playerScript - player controller script that dogs use to deal damage
 * bossDog - a prefab outside the map from which bosses are instantiated
 * enemies - the container GameObject under which enemies are instantiated
 * inventory - the inventory script attached to the user's character
 * HUD - HUD container to make it more efficient to find children
 * heart - image to show when a heart is in the inventory
 * serum - image to show when the serum is picked up
 * cure - image to show when the cure is created
 * hint1 - remind the user to reload with R
 * hint2 - remind the user to pick up bullet items
 * hint3 - display which room was just unlocked
 * bulletCount - number of bullets the player has in reserve
 * magCount - number of bullets currently loaded
 * health - text object displaying current player health
 * roundText - displays the current round
 * roundTimeText - displays the amount of time the current round has been going
 * enemyCount - number of enemies currently alive
 * healthBar - health bar slider object to scale with the player health
 * demo - script that displays/hides the demo video
 * map - MapManager to query spawn locations from and initialize+unlock rooms
 * startTime - time the game was started
 * time - time since the game started
 * idleTime - time that the player last moved
 * roundTime - time that has passed since the last round ended
 * lastRoundTime - time that the last round ended
 * spawnedWave - game time at which the last round was spawned
 * round - current round number
 * finished - whether or not the round is done spawning dogs
 * PLAYER_SPAWN - constant position to spawn the player at
 */
public class GameManager : Singleton<GameManager>
{
	[SerializeField]
	private int difficulty;
	private GameObject playerObject;
	// Player controller reference to allow the dogs to do damage
	[SerializeField]
	private SurvivalPlayer playerScript;
	[SerializeField]
	private GameObject bossDog;
	private GameObject enemies;
	
	// Used to control which items display on the HUD
	private PlayerInventory inventory;
	
	// HUD elements to enable/set the text of
	private GameObject HUD;
	private GameObject heart;
	private GameObject serum;
	private GameObject tuft;
	private GameObject cure;
	private GameObject hint1;
	private GameObject hint2;
	private TextMeshProUGUI hint3;
	private TextMeshProUGUI bulletCount;
	private TextMeshProUGUI magCount;
	private TextMeshProUGUI health;
	private TextMeshProUGUI roundText;
	private TextMeshProUGUI timeText;
	private TextMeshProUGUI roundTimeText;
	private TextMeshProUGUI enemyCount;
	private Slider healthBar;
	
	private DemoShow demo;
	
	private MapManager map;
	
	// Keep track of how long the game and rounds have run
	private int startTime;
	private int time;
	private int idleTime;
	private int roundTime;
	private int lastRoundTime = 0;
	
	private int spawnedWave = 0; // time of last spawned wave
	private int round = 0;
	private bool finished = false;
	
	// Where the player begins the game
	private readonly Vector3 PLAYER_SPAWN = new Vector3(0, 0, -0.5f);

	/*
	 * Create references to scene objects to be updated later. Since Find is a very
	 * expensive method, it's much more efficient to assign these fields initially
	 * than to search for them multiple times later.
	 */
	public override void Awake()
	{
		// Set the singleton instance property
		base.Awake();
		
		HUD = GameObject.Find("HUD");
		// Get inventory objects
		Transform inventory = HUD.transform.Find("inventory");
		heart = inventory.Find("heart").gameObject;
		tuft = inventory.Find("tuft").gameObject;
		cure = inventory.Find("cure").gameObject;
		serum = inventory.Find("serum").gameObject;
		// Get HUD objects
		hint1 = HUD.transform.Find("hint1").gameObject;
		hint2 = HUD.transform.Find("hint2").gameObject;
		// Text objects in the HUD that need to be dynamically updated
		hint3 = HUD.transform.Find("hint3").gameObject.GetComponent<TextMeshProUGUI>();
		bulletCount = HUD.transform.Find("inventory").Find("bulletCount").Find("Bullets").gameObject.GetComponent<TextMeshProUGUI>();
		magCount = HUD.transform.Find("inventory").Find("bulletCount").Find("Magazine").gameObject.GetComponent<TextMeshProUGUI>();
		healthBar = HUD.transform.Find("healthBar").GetComponent<Slider>();
		health = healthBar.gameObject.transform.Find("Health").gameObject.GetComponent<TextMeshProUGUI>();
		roundText = HUD.transform.Find("round").GetComponent<TextMeshProUGUI>();
		timeText = HUD.transform.Find("time").GetComponent<TextMeshProUGUI>();
		enemyCount = HUD.transform.Find("enemies").GetComponent<TextMeshProUGUI>();
		roundTimeText = HUD.transform.Find("roundTime").GetComponent<TextMeshProUGUI>();
		
		enemies = GameObject.Find("Enemies");
		
		demo = gameObject.GetComponent<DemoShow>();
	}

    /*
	 * Start is called before the first frame update by Unity.
	 */
    public void Start()
	{

    }
	
	/*
	 * Update is called many times per second regardless of what
	 * Time.timeScale is set to. This allows me to check for user input
	 * even when the game is paused for the demo mode.
	 */
	public void Update()
	{
		// When the user presses something
		if (Input.anyKey)
		{
			// Check if they were idle
			if (Time.time - idleTime > 30)
			{
				demo.HideVideo(); // stop the video, resume time
			}
			
			idleTime = (int) Time.time; // reset the timer
		}
		else if (Time.time - idleTime > 30)
		{
			//Debug.Log("Player is idle");
			demo.ShowVideo(); // freeze the game and show the video
		}
	}

    /*
	 * Called by Unity a fixed number of times per second, based on the time scale.
	 * Used to control when enemies spawn and update the timer variables.
	 */
    public void FixedUpdate()
	{
		updateHUD();
		
		int frameTime = (int) Time.time;
		
		// Calculate the time the game has run
		time = frameTime - startTime;
		roundTime = frameTime - lastRoundTime;
		
		timeText.text = getMinutes() + ":" + getSeconds();
		roundTimeText.text = "" + roundTime;
		
		// Don't spawn for the first 5 (0-4) seconds of each round
		if (round > 0 && roundTime < 5)
		{
			spawnedWave = roundTime;
			
			if (round == 2 || round == 7)
			{
				playerScript.SetHealth(100f);
			}
		}
		
 		// Check that the game is in progress
		if (spawnedWave < roundTime)
		{
			hint3.gameObject.SetActive(false);
			
			if (round == 0)
			{
				// Begin the game after 4 seconds
				if (time == 1)
				{
					newRound();
				}
			}
			else if (round == 1)
			{
				if (!finished)
				{
					if (roundTime % 6 == 0)
					{
						spawnDogs(2);
						spawnedWave = roundTime;
					}
					if (roundTime > 19 && roundTime % 4 == 0)
					{
						spawnDogs(1);
						spawnedWave = roundTime;
					}
					if (roundTime == 30)
					{
						finished = true;
					}
				}
				else if (enemiesLeft() == 0)
				{
					newRound();
				}
			}
			else if (round == 2)
			{
				if (!finished)
				{
					if (roundTime % 5 == 0)
					{
						spawnDogs(2);
						spawnedWave = roundTime;
					}
					if (roundTime > 17 && roundTime % 3 == 0)
					{
						spawnDogs(1);
						spawnedWave = roundTime;
					}
					if (roundTime == 33)
					{
						finished = true;
					}
				}
				else if (enemiesLeft() == 0)
				{
					newRound();
				}
			}
			else if (round == 3)
			{
				if (!finished)
				{
					if (roundTime % 5 == 0)
					{
						spawnDogs(2);
						spawnedWave = roundTime;
					}
					if (roundTime > 11 && roundTime % 3 == 0)
					{
						spawnDogs(1);
						spawnedWave = roundTime;
					}
					if (roundTime > 29 && roundTime % 3 == 0)
					{
						spawnDogs(1);
						spawnedWave = roundTime;
					}
					if (roundTime == 40)
					{
						finished = true;
					}
				}
				else if (enemiesLeft() == 0)
				{
					newRound();
				}
			}
			else if (round == 4)
			{
				if (!finished)
				{
					if (roundTime % 4 == 0)
					{
						spawnDogs(2);
						spawnedWave = roundTime;
					}
					if (roundTime > 11 && roundTime % 3 == 0)
					{
						spawnDogs(1);
						spawnedWave = roundTime;
					}
					if (roundTime > 29 && roundTime % 3 == 0)
					{
						spawnDogs(1);
						spawnedWave = roundTime;
					}
					if (roundTime == 40)
					{
						spawnBoss(new Vector3(11.1999998f, 3f, -0.1f));
						finished = true;
					}
				}
				else if (enemiesLeft() == 0)
				{
					newRound();
				}
			}
			else if (round == 5)
			{
				if (!finished)
				{
					if (roundTime % 4 == 0)
					{
						spawnDogs(2);
						spawnedWave = roundTime;
					}
					if (roundTime > 11 && roundTime % 3 == 0)
					{
						spawnDogs(1);
						spawnedWave = roundTime;
					}
					if (roundTime > 20 && roundTime % 3 == 0)
					{
						spawnDogs(2);
						spawnedWave = roundTime;
					}
					if (roundTime == 50)
					{
						spawnBoss(new Vector3(-7.55000019f, 14.7200003f, -0.1f));
						finished = true;
					}
				}
				else if (enemiesLeft() == 0)
				{
					newRound();
				}
			}
			else if (round == 6)
			{
				if (!finished)
				{
					if (roundTime % 4 == 0)
					{
						spawnDogs(2);
						spawnedWave = roundTime;
					}
					if (roundTime > 11 && roundTime % 3 == 0)
					{
						spawnDogs(1);
						spawnedWave = roundTime;
					}
					if (roundTime > 20 && roundTime % 3 == 0)
					{
						spawnDogs(2);
						spawnedWave = roundTime;
					}
					if (roundTime == 30)
					{
						spawnBoss(new Vector3(44.5f, -13.6999998f, -0.1f));
						spawnedWave = roundTime;
					}
					if (roundTime == 45)
					{
						spawnBoss(new Vector3(11.1999998f, 3f, -0.1f));
						spawnedWave = roundTime;
					}
					if (roundTime == 60)
					{
						spawnBoss(new Vector3(-7.55000019f, 14.7200003f, -0.1f));
						finished = true;
					}
				}
				else if (enemiesLeft() == 0)
				{
					newRound();
				}
			}
			else if (round == 7)
			{
				if (roundTime % 4 == 0)
				{
					spawnDogs(2);
					spawnedWave = roundTime;
				}
				if (roundTime > 11 && roundTime % 3 == 0)
				{
					spawnDogs(1);
					spawnedWave = roundTime;
				}
				if (roundTime > 20 && roundTime % 3 == 0)
				{
					spawnDogs(2);
					spawnedWave = roundTime;
				}
				if (roundTime > 50 && roundTime % 10 == 0)
				{
					spawnBoss(new Vector3(25.6299992f, 26.2199993f, -0.1f));
					spawnedWave = roundTime;
				}
			}
		}
    }
	
	/*
	 * Returns the inventory script of the player for Tosin to reference.
	 */
	public PlayerInventory getInventory()
	{
		return inventory;
	}
	
	/*
	 * Call to end the game when the player dies or quits.
	 */
	public void endGame()
	{
		round = 0;
		/* ###### Implement death screen and call it here! ###### */
	}
	
	/*
	 * Loads the map, sets necessary objects to active, gets the correct player and spawns it.
	 * Parameter diff sets player type, where 0 = BC mode.
	 */
	public void startGame(int diff)
	{
		startTime = (int) Time.time;
		idleTime = (int) Time.time;
		
		map = MapManager.Instance;
		round = 0;
		
		map.startGame(); // initialize map rooms
		
		HUD.SetActive(true);
		
		GameObject.Find("Notes (disable on start)").SetActive(false);
		
		// Check if BC mode needs to be enabled, get the correct player and disable the other
		if (diff == 0)
		{
			// Set the reference to the BCPlayer			
			playerObject = GameObject.Find("BCPlayer");
			GameObject.Find("SurvivalPlayer").SetActive(false);
			
			bulletCount.text = "<size=18>∞";
			magCount.text = "<size=18>∞";
			health.text = "∞";
			healthBar.value = 1;
		}
		else
		{
			playerObject = GameObject.Find("SurvivalPlayer");
			GameObject.Find("BCPlayer").SetActive(false);
		}

		// Move player onto the map
		playerObject.transform.position = PLAYER_SPAWN;
		// Get a reference to the inventory script
		inventory = playerObject.GetComponent<PlayerInventory>();
		playerScript.SetHealth(100f);

		// Populate map with testing enemies
		//spawnDogs(3 * difficulty);
	}
	
	/*
	 * Getter function for current level (for modifying enemy speed, UI elements).
	 */
	public int getRound()
	{
		return round;
	}
	
	/*
	 * Returns the SurvivalPlayer controller script for damaging the player.
	 */
	public SurvivalPlayer getPlayer()
	{
		return playerScript;
	}
	
	/*
	 * Returns a reference to the player GameObject.
	 */
	public GameObject getPlayerObject()
	{
		return playerObject;
	}
	
	/*
	 * Returns the number of seconds since the game started, formatted for use in a h:mm:ss format.
	 */
	public string getSeconds()
	{
		int seconds = time % 60;
		return seconds < 10 ? "0" + seconds : "" + seconds;
	}
	
	/*
	 * Return number of minutes (and hours if applicable) since the game started. Formatted in h:mm.
	 */
	public string getMinutes()
	{
		int minutes = time / 60;
		
		return minutes < 60 ? "" + minutes : minutes / 60 + ":" + (minutes % 60 < 10 ? "0" : "") + minutes % 60;
	}
	
	/*
	 * Returns the number of dogs currently alive on the map.
	 */
	public int enemiesLeft()
	{
		return enemies.transform.GetComponentsInChildren<Rigidbody2D>(false).Length;
	}
	
	/*
	 * Cleans up from the previous round and sets all the necessary variables for the new round.
	 */
	private void newRound()
	{
		// Update timers
		lastRoundTime = (int) Time.time;
		spawnedWave = 0;
		finished = false; // prepare to spawn again
		round++;
		roundText.text = "" + getRound();
		// Unlock next room and display which it was
		string room = map.unlockRoom();
		if (room != "") {
			hint3.text = "The <color=#870000>" + room + "</color> was just unlocked!";
			hint3.gameObject.SetActive(true);
		}
	}
	
	/*
	 * Updates all HUD objects to the values they should have.
	 */
	private void updateHUD()
	{
		// Only worry about ammo and health if the user is not BC
		if (playerObject.name == "SurvivalPlayer") {
			Shooter shooter = playerObject.GetComponent<Shooter>();
			
			bulletCount.text = "" + shooter.ReserveAmmoCount();
			magCount.text = "" + shooter.MagAmmoCount();
			health.text = "" + playerScript.GetHealth();
			healthBar.value = playerScript.GetHealth() / 100;
			
			if (round < 2 && shooter.MagAmmoCount() == 0)
			{
				hint1.SetActive(true);
			}
			else
			{
				hint1.SetActive(false);
			}
			
			if (shooter.ReserveAmmoCount() == 0)
			{
				hint2.SetActive(true);
			}
			else
			{
				hint2.SetActive(false);
			}
		}
		
		enemyCount.text = "zombies left: " + enemiesLeft();
		
		heart.SetActive(inventory.hasHeart());
		tuft.SetActive(inventory.hasTuft());
		cure.SetActive(inventory.hasCure());
		serum.SetActive(inventory.hasSerum());
	}
	
	/*
	 * Spawn zombie dogs at the next spawn location provided by the MapManager.
	 * Parameter num is the number of dogs to spawn at once.
	 */
	private void spawnDogs(int num)
	{
		Vector3 spawn = MapManager.Instance.nextSpawn(); // get position to spawn dogs at next
		spawn.z = -0.1f;
		
		// Clone the provided number of dogs
		for (int i = 0; i < num; i++)
		{
			DogPool.Instance.SpawnFromDogPool("ZombieDog", spawn, Quaternion.identity);
		}
	}
	
	/*
	 * Spawns a new boss dog and plays the growl sound effect.
	 * Parameter pos is the position at which to spawn the boss.
	 */
	private void spawnBoss(Vector3 pos) {
		SoundManager.Instance.bossGrowlFunction();
		
		Instantiate(bossDog, pos, Quaternion.identity, enemies.transform);
	}
}

