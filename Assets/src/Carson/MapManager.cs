using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Singleton<MapManager> {
	[SerializeField]
	private GameObject basicRoom;
	
	
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
		spawnPoints = new List<Vector3>();
		
		foreach (Room room in rooms) {
			if (!room.isLocked()) {
				spawnPoints.AddRange(room.getSpawnPoints());
			}
		}
		
		return spawnPoints;
	}
	
	// Initialize the rooms and spawnpoints, hide the menu
	public void startGame() {
		/*// Add default spawn locations
		spawnPoints.Add(new Vector3(0, 0, 0));
		spawnPoints.Add(new Vector3(3, 3, 0));
		spawnPoints.Add(new Vector3(10, 7, 0));
		spawnPoints.Add(new Vector3(20, -10, 0));*/
		
		LargeRoomFactory factory = gameObject.AddComponent<LargeRoomFactory>();
		factory.roomPrefab = basicRoom;
		/*if (factory.roomInfo == null) {
			Debug.Log("No dic");
		}
		else {*/
			rooms.Add(factory.createRoom("Laboratory"));
			Debug.Log("1");
			rooms.Add(factory.createRoom("Kitchen"));
		//}
		
		/*factory = new SmallRoomFactory(basicRoom);
		rooms.Add(factory.createRoom("Exam1"));
		rooms.Add(factory.createRoom("Exam2"));
		rooms.Add(factory.createRoom("Closet"));*/
	}
	
	public int unlockRoom() {
		unlocked++;
		
		rooms[unlocked].unlockRoom();
		
		return unlocked;
	}
}
