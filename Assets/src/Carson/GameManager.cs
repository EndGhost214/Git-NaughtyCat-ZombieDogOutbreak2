using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to control UI elements and game event execution.
public static class GameManager : MonoBehaviour {
	private Dog[] dogs;
	private Player player;
	
	private LevelManager levelMan;
	
	private int round = 0;
	private int time = 0;
	
    // Start is called before the first frame update
    void Start() {
        // Open start menu from Ambrea?
		levelMan = new LevelManager();
    }

    // Update is called once per frame
    void Update() {
		// Check that the game is in progress
        if (round > 0) {
			
		}
    }
	
	// Call to end the game when the player dies or quits.
	public static void EndGame() {
		round = 0;
		for (int i = 0; dogs[i] != null; i++) {
			dogs[i].Disable();
		}
		
		// Reset level manager
		// Display start menu
	}
	
	// Load the game background, create player and dogs.
	// Provided difficulty sets dog AI level. 0 = BC mode
	public static void StartGame(int difficulty) {
		round = 1;
		
		levelMan.StartGame();
		
		// Check if BC mode needs to be enabled
		if (difficulty == 0) {
			// create BC player
			player = new BCPlayer();
			
			difficulty = 1;
		}
		else {
			// create survival player
			player = new SurvivalPlayer();
		}
		
		// Populate array with starting enemies
		for (int i = 0; i < 3 * difficulty) {
			ZombieDog[i] = new ZombieDog();
		}
	}
	
	// Getter function for current level (for modifying enemy speed, UI elements)
	public static int GetRound() {
		return round;
	}
	
	// Return player object.
	public static Player GetPlayer() {
		return player;
	}
	
	// Return player position (for dog AI).
	public static Vector2 GetPlayerPos() {
		return player.GetPos();
	}
	
	// Return number of seconds since the game started.
	public static int GetSeconds() {
		return time;
	}
	
	// Return number of minutes since the game started, floored.
	public static int GetMinutes() {
		return time / 60;
	}
	
	// Counts the number of dogs left to fight
	public static int EnemiesLeft() {
		int count = 0;
		
		// Loop through dogs array
		for (int i = 0; dogs[i] != null; i++) {
			if (dogs[i].IsAlive() == true) {
				count++;
			}
		}
		
		return count;
	}
}
