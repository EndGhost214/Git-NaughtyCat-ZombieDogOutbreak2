using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to control UI elements and game event execution.
public class GameManager : Singleton<GameManager> {
	[SerializeField]
	private Player playerPrefab;
	private Player player; // player object to reference
	
	private MapManager map;
	
	// Keep track of how long the game has run
	private int startTime = 0;
	private int time = 0;
	
	private int spawnID = 0; // index of next spawnpoint to use
	private int spawnedWave = 0; // time of last spawned wave
	private int round = 0;
	
	// Where the player begins the game
	private Vector3 playerSpawn = new Vector3(0, 0, 0);
	
	[SerializeField]
	private ZombieDog basicDog; // ZombieDog class for instantiating new dogs
	private List<Dog> dogs = new List<Dog>(); // list of alive dogs
	
    // Start is called before the first frame update
    void Start() {
        // Open start menu from Ambrea
		map = MapManager.Instance;
		StartGame(1);
    }

    // Update is called once per frame
    void FixedUpdate() {
		// Calculate the time the game has run
		time = (int) Time.time - startTime;
		//Debug.Log(time);
		
		// Check that the game is in progress
        if (round > 0 && spawnedWave < time) {
			// Spawn 5 (1 for now) dogs every 12 seconds
			if (time % 12 == 0) {
				SpawnDogs(1);
				spawnedWave = time;
			}
			// Spawn another group every 4 seconds
			if (time > 24 && time % 4 == 0) {
				SpawnDogs(1);
				spawnedWave = time;
			}
		}
    }
	
	// Spawn the provided number of dogs at the next spawn locations
	private void SpawnDogs(int num) {
		Vector3 spawn = NextSpawn(); // get position to spawn dogs at next
		
		// Clone the provided number of dogs
		for (int i = 0; i < num; i++) {
			dogs.Add(Instantiate(basicDog, spawn, Quaternion.identity));
		}
	}
	
	// Returns the next position a dog should be spawned.
	private Vector3 NextSpawn() {
		List<Vector3> sPoints = map.GetSpawnPoints();
		
		// Increment counter to next spawn point in the list
		spawnID = (spawnID + 1) % (sPoints.Count);
		//Debug.Log(spawnID);
		return sPoints[spawnID];
	}
	
	// Call to end the game when the player dies or quits.
	public void EndGame() {
		round = 0;
		
		// Kill every dog in the list
		dogs.ForEach(delegate(Dog dog) {
			dog.Death();
		});
		
		// Reset level manager
		// Display start menu
	}
	
	// Load the game background, create player and dogs.
	// Provided difficulty sets dog AI level. 0 = BC mode
	public void StartGame(int difficulty) {
		round = 1;
		
		map.StartGame(); // initialize map rooms+spawnpoints
		
		// Check if BC mode needs to be enabled
		if (difficulty == 0) {
			// create BC player
			player = Instantiate(playerPrefab, playerSpawn, Quaternion.identity);
			
			difficulty = 1;
		}
		else {
			// create survival player
			player = Instantiate(playerPrefab, playerSpawn, Quaternion.identity);
		}
		
		// Populate array with starting enemies
		SpawnDogs(3 * difficulty);
	}
	
	// Getter function for current level (for modifying enemy speed, UI elements)
	public int GetRound() {
		return round;
	}
	
	// Return player object.
	public Player GetPlayer() {
		return player;
	}
	
	// Return player position (for dog AI).
	public Vector3 GetPlayerPos() {
		return player.transform.position;
	}
	
	// Return number of seconds since the game started.
	public int GetSeconds() {
		return time;
	}
	
	// Return number of minutes since the game started, floored.
	public int GetMinutes() {
		return time / 60;
	}
	
	// Counts the number of dogs left to fight
	public int EnemiesLeft() {
		int count = 0;
		
		// Loop through dogs array
		foreach(Dog d in dogs){
			// Count living dogs
			if (d != null) {
				count++;
			}
			else {
				dogs.Remove(d); // remove any null elements
			}
		}
		
		return count;
	}
}
