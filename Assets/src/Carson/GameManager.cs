using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to control UI elements and game event execution.
public class GameManager : MonoBehaviour {
	private List<Dog> dogs = new List<Dog>();
	private Player player;
	
	[SerializeField]
	private MapManager map;
	
	private int round = 0;
	private int startTime = 0;
	private int time = 0;
	
	private int spawnID = 0; // index of next spawnpoint to use
	private int spawnedWave = 0;
	
	[SerializeField]
	private ZombieDog basicDog;
	
    // Start is called before the first frame update
    void Start() {
        // Open start menu from Ambrea?
		StartGame(1);
    }

    // Update is called once per frame
    void FixedUpdate() {
		time = (int) Time.time - startTime;
		Debug.Log(time);
		
		// Check that the game is in progress
        if (round > 0 && spawnedWave < time) {
			// Spawn 5 dogs every 12 seconds
			if (time % 12 == 0) {
				SpawnDogs(5);
				spawnedWave = time;
			}
			// Spawn a larger group every 4 seconds
			if (time > 24 && time % 4 == 0) {
				SpawnDogs(1);
				spawnedWave = time;
			}
		}
    }
	
	// Spawn the provided number of dogs at the next spawn locations
	private void SpawnDogs(int num) {
		Vector2 spawn = NextSpawn(); // get position to spawn dogs at next
		
		for (int i = 0; i < num; i++) {
			dogs.Add(Instantiate(basicDog, spawn, Quaternion.identity));
		}
	}
	
	// Returns the next position a dog should be spawned.
	private Vector3 NextSpawn() {
		List<Vector3> sPoints = map.GetSpawnPoints();
		
		// Increment counter to next spawn point in the list
		spawnID = (spawnID + 1) % (sPoints.Count);
		
		return sPoints[spawnID];
	}
	
	// Call to end the game when the player dies or quits.
	public void EndGame() {
		round = 0;
		
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
		
		map.StartGame();
		
		// Check if BC mode needs to be enabled
		if (difficulty == 0) {
			// create BC player
			//player = new BCPlayer();
			
			difficulty = 1;
		}
		else {
			// create survival player
			player = new SurvivalPlayer();
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
			if (d != null) {
				count++;
			}
			else {
				dogs.Remove(d);
			}
		}
		
		return count;
	}
}
