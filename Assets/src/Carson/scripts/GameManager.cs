using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Class to control UI elements and game event execution.
public class GameManager : Singleton<GameManager> {

	private GameObject playerObject;
	[SerializeField]
	private GameObject bossDog;
	private GameObject enemies;
	
	private PlayerInventory inventory;
	
	// HUD elements to enable/set the text of
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
	private TextMeshProUGUI roundTimeText;
	private TextMeshProUGUI enemyCount;
	private Slider healthBar;
	
	// Player object for molly to reference to allow the dogs to do damage
	[SerializeField]
	private SurvivalPlayer playerScript;
	private DemoShow demo;
	
	private MapManager map;
	
	// Keep track of how long the game has run
	private int startTime;
	private int time;
	private int idleTime;
	private int roundTime;
	private int lastRoundTime = 0;
	
	private int spawnedWave = 0; // time of last spawned wave
	private int round = 0;
	private bool finished = false;
	
	// Where the player begins the game
	private Vector3 playerSpawn = new Vector3(-9, 1, -0.5f);

	/*
	 * Create references to scene objects to be updated later. Since Find is a very
	 * expensive method, it's much more efficient to assign these fields initially
	 * than to search for them multiple times later.
	 */
	void Awake() {
		HUD = GameObject.Find("HUD");
		
		Transform inventory = HUD.transform.Find("inventory");
		
		heart = inventory.Find("heart").gameObject;
		tuft = inventory.Find("tuft").gameObject;
		cure = inventory.Find("cure").gameObject;
		serum = inventory.Find("serum").gameObject;
		
		hint1 = HUD.transform.Find("hint1").gameObject;
		hint2 = HUD.transform.Find("hint2").gameObject;
		
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
    void Start() {
        // Open start menu from Ambrea?
		startGame(1);
    }
	
	/*
	 * Update is called many times per second regardless of what
	 * Time.timeScale is set to. This allows me to check for user input
	 * even when the game is paused for the demo mode.
	 */
	void Update() {
		// When the user presses something
		if (Input.anyKey) {
			// Check if they were idle
			if (Time.time - idleTime > 30) {
				demo.HideVideo(); // stop the video, resume time
			}
			
			idleTime = (int) Time.time; // reset the timer
		}
		else if (Time.time - idleTime > 30) {
			//Debug.Log("Player is idle");
			demo.ShowVideo(); // freeze the game and show the video
		}
	}

    /*
	 * Called by Unity a fixed number of times per second, based on the time scale.
	 */
    void FixedUpdate() {
		updateHUD();
		
		int frameTime = (int) Time.time;
		
		// Calculate the time the game has run
		time = frameTime - startTime;
		roundTime = frameTime - lastRoundTime;
		
		timeText.text = getMinutes() + ":" + getSeconds();
		roundTimeText.text = "" + roundTime;
		
		// Don't spawn for the first 5 (0-4) seconds of each round
		if (round > 0 && roundTime < 5) {
			spawnedWave = roundTime;
			
			if (round == 2 || round == 7) {
				playerScript.SetHealth(100f);
			}
		}
		
 		// Check that the game is in progress
		if (spawnedWave < roundTime) {
			if (round == 0) {
				// Begin the game after 4 seconds
				if (time == 4) {
					newRound();
				}
			}
			else if (round == 1) {
				if (!finished) {
					if (roundTime % 6 == 0) {
						spawnDogs(2);
						spawnedWave = roundTime;
					}
					if (roundTime > 19 && roundTime % 4 == 0) {
						spawnDogs(1);
						spawnedWave = roundTime;
					}
					if (roundTime == 30) {
						finished = true;
					}
				}
				else if (enemiesLeft() == 0) {
					newRound();
				}
			}
			else if (round == 2) {
				if (!finished) {
					if (roundTime % 5 == 0) {
						spawnDogs(2);
						spawnedWave = roundTime;
					}
					if (roundTime > 17 && roundTime % 3 == 0) {
						spawnDogs(1);
						spawnedWave = roundTime;
					}
					if (roundTime == 33) {
						finished = true;
					}
				}
				else if (enemiesLeft() == 0) {
					newRound();
				}
			}
			else if (round == 3) {
				if (!finished) {
					if (roundTime % 5 == 0) {
						spawnDogs(2);
						spawnedWave = roundTime;
					}
					if (roundTime > 11 && roundTime % 3 == 0) {
						spawnDogs(1);
						spawnedWave = roundTime;
					}
					if (roundTime > 29 && roundTime % 3 == 0) {
						spawnDogs(1);
						spawnedWave = roundTime;
					}
					if (roundTime == 40) {
						finished = true;
					}
				}
				else if (enemiesLeft() == 0) {
					newRound();
				}
			}
			else if (round == 4) {
				if (!finished) {
					if (roundTime % 4 == 0) {
						spawnDogs(2);
						spawnedWave = roundTime;
					}
					if (roundTime > 11 && roundTime % 3 == 0) {
						spawnDogs(1);
						spawnedWave = roundTime;
					}
					if (roundTime > 29 && roundTime % 3 == 0) {
						spawnDogs(1);
						spawnedWave = roundTime;
					}
					if (roundTime == 40) {
						Instantiate(bossDog, new Vector3(11.1999998f, 3f, -0.1f), Quaternion.identity);
						finished = true;
					}
				}
				else if (enemiesLeft() == 0) {
					newRound();
				}
			}
			else if (round == 5) {
				if (!finished) {
					if (roundTime % 4 == 0) {
						spawnDogs(2);
						spawnedWave = roundTime;
					}
					if (roundTime > 11 && roundTime % 3 == 0) {
						spawnDogs(1);
						spawnedWave = roundTime;
					}
					if (roundTime > 20 && roundTime % 3 == 0) {
						spawnDogs(2);
						spawnedWave = roundTime;
					}
					if (roundTime == 50) {
						Instantiate(bossDog, new Vector3(-7.55000019f, 14.7200003f, -0.1f), Quaternion.identity);
						finished = true;
					}
				}
				else if (enemiesLeft() == 0) {
					newRound();
				}
			}
			else if (round == 6) {
				if (!finished) {
					if (roundTime % 4 == 0) {
						spawnDogs(2);
						spawnedWave = roundTime;
					}
					if (roundTime > 11 && roundTime % 3 == 0) {
						spawnDogs(1);
						spawnedWave = roundTime;
					}
					if (roundTime > 20 && roundTime % 3 == 0) {
						spawnDogs(2);
						spawnedWave = roundTime;
					}
					if (roundTime == 30) {
						Instantiate(bossDog, new Vector3(44.5f, -13.6999998f, -0.1f), Quaternion.identity);
						spawnedWave = roundTime;
					}
					if (roundTime == 45) {
						Instantiate(bossDog, new Vector3(11.1999998f, 3f, -0.1f), Quaternion.identity);
						spawnedWave = roundTime;
					}
					if (roundTime == 60) {
						Instantiate(bossDog, new Vector3(-7.55000019f, 14.7200003f, -0.1f), Quaternion.identity);
						finished = true;
					}
				}
				else if (enemiesLeft() == 0) {
					newRound();
				}
			}
			else if (round == 7) {
				if (roundTime % 4 == 0) {
					spawnDogs(2);
					spawnedWave = roundTime;
				}
				if (roundTime > 11 && roundTime % 3 == 0) {
					spawnDogs(1);
					spawnedWave = roundTime;
				}
				if (roundTime > 20 && roundTime % 3 == 0) {
					spawnDogs(2);
					spawnedWave = roundTime;
				}
				if (roundTime > 50 && roundTime % 10 == 0) {
					Instantiate(bossDog, new Vector3(25.6299992f, 26.2199993f, -0.1f), Quaternion.identity);
					spawnedWave = roundTime;
				}
			}
		}
    }
	
	private void newRound() {
		lastRoundTime = (int) Time.time;
		round++;
		spawnedWave = 0;
		finished = false;
		roundText.text = "" + getRound();
		Debug.Log(map.unlockRoom() + " has just been unlocked!");
	}
	
	private void updateHUD() {
		Shooter shooter = playerObject.GetComponent<Shooter>();
		
		bulletCount.text = "" + shooter.ReserveAmmoCount();
		magCount.text = "" + shooter.MagAmmoCount();
		health.text = "" + playerScript.GetHealth();
		enemyCount.text = "zombies left: " + enemiesLeft();
		
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
		Vector3 spawn = MapManager.Instance.nextSpawn(); // get position to spawn dogs at next
		spawn.z = -0.1f;
		
		// Clone the provided number of dogs
		for (int i = 0; i < num; i++) {
			DogPool.Instance.SpawnFromDogPool("ZombieDog", spawn, Quaternion.identity);
		}
	}
	
	/*
	 * Returns the inventory script of the player for Tosin to reference.
	 */
	public PlayerInventory getInventory() {
		return inventory;
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
		round = 0;
		
		map.startGame(); // initialize map rooms
		
		HUD.SetActive(true);
		
		GameObject.Find("Notes (disable on start)").SetActive(false);
		
		// Check if BC mode needs to be enabled, get the correct player and disable the other
		if (difficulty == 0) {
			// Set the reference to the BCPlayer			
			playerObject = GameObject.Find("BCPlayer");
			GameObject.Find("SurvivalPlayer").SetActive(false);
		}
		else {
			playerObject = GameObject.Find("SurvivalPlayer");
			GameObject.Find("BCPlayer").SetActive(false);
		}

		// Move player onto the map
		playerObject.transform.position = playerSpawn;
		// Get a reference to the inventory script
		inventory = playerObject.GetComponent<PlayerInventory>();
		playerScript.SetHealth(100f);
		
		difficulty++;
		
		// Populate map with starting enemies
		//spawnDogs(3 * difficulty);
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
	
	/*
	 * Counts the number of dogs to fight on the map.
	 */
	private int enemiesLeft() {
		return GameObject.FindGameObjectsWithTag("ZombieDog").Length - 1;
	}
}
