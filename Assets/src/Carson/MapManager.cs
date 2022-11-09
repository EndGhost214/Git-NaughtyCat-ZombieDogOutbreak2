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
		
		unlocked = -1;
    }
	
	// Initialize the rooms and spawnpoints, hide the menu
	public void startGame() {
		AbstractRoomFactory factory = gameObject.AddComponent<LargeRoomFactory>();
		factory.roomPrefab = basicRoom;

		rooms.Add(factory.createRoom("Laboratory"));
		rooms.Add(factory.createRoom("Kitchen"));

		Destroy(factory);
		factory = gameObject.AddComponent<SmallRoomFactory>();
		factory.roomPrefab = basicRoom;

		rooms.Insert(0, factory.createRoom("Exam1"));
		rooms.Insert(1, factory.createRoom("Exam2"));
		rooms.Insert(3, factory.createRoom("Closet"));
		rooms.Add(factory.createRoom("Hallway"));
		
		Destroy(factory);
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
	
	public string unlockRoom() {
		unlocked++;
		
		rooms[unlocked].unlockRoom();
		
		return rooms[unlocked].name;
	}
}
