using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Class to control UI elements and game event execution.
public class GameManager : Singleton<GameManager> {

	private GameObject playerObject;
	private PlayerInventory inventory;
	
	private GameObject HUD;
	private GameObject heart;
	private GameObject serum;
	private GameObject tuft;
	private GameObject cure;
	private GameObject hint1;
	private GameObject hint2;

	private TextMeshProUGUI bulletCount;
	private TextMeshProUGUI magCount;
	private TextMeshProUGUI health;
	private TextMeshProUGUI roundText;
	private TextMeshProUGUI timeText;
	
	private Slider healthBar;
	
	// Player object for molly to reference to allow the dogs to do damage
	[SerializeField]
	private SurvivalPlayer playerScript;
	private DemoShow demo;
	
	private MapManager map;
	private List<Vector3> currentSpawnPoints;
	
	// Keep track of how long the game has run
	private int startTime;
	private int time;
	private int idleTime;
	
	private int spawnID = 0; // index of next spawnpoint to use
	private int spawnedWave = 0; // time of last spawned wave
	private int round = 0;
	
	// Where the player begins the game
	private Vector3 playerSpawn = new Vector3(-1, 0, 0);

	/*
	 * Create references to scene objects to be updated later.
	 */
	void Awake() {
		HUD = GameObject.Find("HUD");
		heart = HUD.transform.Find("heart").gameObject;
		tuft = HUD.transform.Find("tuft").gameObject;
		cure = HUD.transform.Find("cure").gameObject;
		serum = HUD.transform.Find("serum").gameObject;
		hint1 = HUD.transform.Find("hint1").gameObject;
		hint2 = HUD.transform.Find("hint2").gameObject;
		
		bulletCount = HUD.transform.Find("inventory").Find("bulletCount").Find("Bullets").gameObject.GetComponent<TextMeshProUGUI>();
		magCount = HUD.transform.Find("inventory").Find("bulletCount").Find("Magazine").gameObject.GetComponent<TextMeshProUGUI>();
		healthBar = HUD.transform.Find("healthBar").GetComponent<Slider>();
		health = healthBar.gameObject.transform.Find("Health").gameObject.GetComponent<TextMeshProUGUI>();
		roundText = HUD.transform.Find("round").GetComponent<TextMeshProUGUI>();
		timeText = HUD.transform.Find("time").GetComponent<TextMeshProUGUI>();
		
		demo = gameObject.GetComponent<DemoShow>();
	}

    // Start is called before the first frame update
    void Start() {
        // Open start menu from Ambrea
		startGame(1);
    }
	
	void Update() {
		if (Input.anyKey) {
			idleTime = (int) Time.time;
			demo.HideVideo();
		}
		else if (Time.time - idleTime > 60) {
			Debug.Log("Player is idle");
			demo.ShowVideo();
		}
	}

    // Update is called once per frame
    void FixedUpdate() {
		updateHUD();
		
		int frameTime = (int) Time.time;
		
		// Calculate the time the game has run
		time = frameTime - startTime;
		
		timeText.text = getMinutes() + ":" + getSeconds();
		
		// Check that the game is in progress
        if (round > 0 && spawnedWave < time) {
			//Debug.Log("Spawning");
			// Spawn 5 (1 for now) dogs every 12 seconds
			if (time % 6 == 0) {
				spawnDogs(1);
				spawnedWave = time;
			}
			// Spawn another group every 4 seconds
			if (time > 24 && time % 4 == 0) {
				spawnDogs(2);
				spawnedWave = time;
			}
			
			if (time > 10) {
				round++;
			}
		}
    }
	
	private void newRound() {
		round++;
		roundText.text = "" + getRound();
		Debug.Log(map.unlockRoom() + " has just been unlocked!");
		currentSpawnPoints = map.getSpawnPoints();
	}
	
	private void updateHUD() {
		Shooter shooter = playerObject.GetComponent<Shooter>();
		
		bulletCount.text = "" + shooter.ReserveAmmoCount();
		magCount.text = "" + shooter.MagAmmoCount();
		health.text = "" + playerScript.GetHealth();
		healthBar.value = playerScript.GetHealth() / 100;
		
		if (round < 2 && shooter.MagAmmoCount() == 0) {
			hint1.SetActive(true);
		}
		else {
			hint1.SetActive(false);
		}
		
		if (shooter.ReserveAmmoCount() == 0) {
			hint2.SetActive(true);
		}
		else {
			hint2.SetActive(false);
		}
		
		heart.SetActive(inventory.hasHeart());
		tuft.SetActive(inventory.hasTuft());
		cure.SetActive(inventory.hasCure());
		serum.SetActive(inventory.hasSerum());
	}
	
	// Spawn the provided number of dogs at the next spawn locations
	private void spawnDogs(int num) {
		Vector3 spawn = nextSpawn(); // get position to spawn dogs at next
		
		// Clone the provided number of dogs
		for (int i = 0; i < num; i++) {
			DogPool.Instance.SpawnFromDogPool("ZombieDog", spawn, Quaternion.identity);
		}
	}
	
	// Returns the next position a dog should be spawned.
	private Vector3 nextSpawn() {
		List<Vector3> sPoints = currentSpawnPoints;
		
		// Increment counter to next spawn point in the list
		spawnID = (spawnID + 1) % (sPoints.Count);
		//Debug.Log(spawnID);
		return sPoints[spawnID];
	}
	
	// Call to end the game when the player dies or quits.
	public void endGame() {
		round = 0;
	}
	
	// Load the game background, create player and dogs.
	// Provided difficulty sets dog AI level. 0 = BC mode
	public void startGame(int difficulty) {
		startTime = (int) Time.time;
		idleTime = (int) Time.time;
		
		map = MapManager.Instance;
		round = 1;
		
		map.startGame(); // initialize map rooms+spawnpoints
		
		HUD.SetActive(true);
		
		GameObject.Find("Notes (disable on start)").SetActive(false);
		
		// Check if BC mode needs to be enabled
		if (difficulty == 0) {
			// Move BC player onto the map			
			playerObject = GameObject.Find("BCPlayer");
			GameObject.Find("SurvivalPlayer").SetActive(false);
		}
		else {
			// Move survival player onto the map
			playerObject = GameObject.Find("SurvivalPlayer");
			GameObject.Find("BCPlayer").SetActive(false);
		}

		playerObject.transform.position = playerSpawn;
		inventory = playerObject.GetComponent<PlayerInventory>();
		playerScript.SetHealth(100f);
		
		difficulty++;
		
		// Populate array with starting enemies
		spawnDogs(3 * difficulty);
	}
	
	// Getter function for current level (for modifying enemy speed, UI elements)
	public int getRound() {
		return round;
	}
	
	// Return player object.
	public SurvivalPlayer getPlayer() {
		return playerScript;
	}
	
	public GameObject getPlayerObject() {
		return playerObject;
	}
	
	// Return number of seconds since the game started.
	public string getSeconds() {
		int seconds = time % 60;
		return seconds < 10 ? "0" + seconds : "" + seconds;
	}
	
	// Return number of minutes since the game started, floored.
	public string getMinutes() {
		int minutes = time / 60;
		
		return minutes < 60 ? "" + minutes : minutes / 60 + ":" + (minutes % 60 < 10 ? "0" : "") + minutes % 60;
	}
	
	// Counts the number of dogs left to fight
	public int enemiesLeft() {
		int count = 0;
		
		// Loop through dogs array
		/*foreach(Dog d in dogs){
			// Count living dogs
			if (d != null) {
				count++;
			}
			else {
				dogs.Remove(d); // remove any null elements
			}
		}*/
		
		return count;
	}
}
