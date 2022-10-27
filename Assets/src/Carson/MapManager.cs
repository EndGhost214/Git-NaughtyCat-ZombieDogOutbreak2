using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Singleton<MapManager> {
	//[SerializeField]
	//private GameObject StartMenu;
	
	//private List<Room> rooms = new List<Room>();
	
	private List<Vector3> spawnPoints = new List<Vector3>();
	
    // Start is called before the first frame update
    void Start() {
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
		//Debug.Log("Game started");
		//StartMenu.SetActive(false);
		
		//Initialize rooms
		
		// Add default spawn locations
		spawnPoints.Add(new Vector3(0, 0, 0));
		spawnPoints.Add(new Vector3(3, 3, 0));
		spawnPoints.Add(new Vector3(10, 7, 0));
		spawnPoints.Add(new Vector3(20, -10, 0));
	}
}
