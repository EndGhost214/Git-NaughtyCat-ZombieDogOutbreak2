using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Singleton<MapManager> {
	//[SerializeField]
	//private GameObject StartMenu;
	
	//private List<Room> rooms = new List<Room>();
	
	private List<Vector3> spawnPoints;
	private List<Room> rooms;
	private int unlocked;
	
    // Start is called before the first frame update
    void Start() {
		spawnPoints = new List<Vector3>();
		rooms = new List<Room>();
		
		unlocked = 0;
    }

    // Update is called once per frame
    void Update() {
    }
	
	// Return the list of spawnpoints
	public List<Vector3> getSpawnPoints() {
		return spawnPoints;
	}
	
	// Initialize the rooms and spawnpoints, hide the menu
	public void startGame() {
		int id = 0;
		
		// Initialize rooms
		/*Room Lab = new Laboratory(id);
		id++;
		Room Kitchen = new Kitchen(id);
		id++;
		Room Exam1 = new Exam(id);
		id++;
		Room Exam2 = new Exam(id);
		id++;
		Room Closet = new Closet(id);
		
		// Add rooms to list
		rooms.Add(Exam2);
		rooms.Add(Lab);
		rooms.Add(Kitchen);
		rooms.Add(Exam1);
		rooms.Add(Closet);*/
		
		// Add default spawn locations
		spawnPoints.Add(new Vector3(0, 0, 0));
		spawnPoints.Add(new Vector3(3, 3, 0));
		spawnPoints.Add(new Vector3(10, 7, 0));
		spawnPoints.Add(new Vector3(20, -10, 0));
	}
	
	public int unlockRoom() {
		unlocked++;
		
		rooms[unlocked].unlockRoom();
		
		return unlocked;
	}
}
