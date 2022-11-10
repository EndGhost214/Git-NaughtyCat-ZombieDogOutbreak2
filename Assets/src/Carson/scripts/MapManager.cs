using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Singleton<MapManager> {
	[SerializeField]
	private GameObject basicRoom;
	
	private List<GameObject> vents;
	private List<Room> rooms;
	private int unlocked;
	private int spawnID = 0; // index of next spawnpoint to use

	
    // Start is called before the first frame update
    void Start() {
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
	private void updateSpawnPoints() {
		vents = new List<GameObject>();
		
		foreach (Room room in rooms) {
			if (!room.isLocked()) {
				vents.AddRange(room.getSpawnPoints());
			}
		}
	}
	
	// Returns the next position a dog should be spawned.
	public Vector3 nextSpawn() {
		// Increment counter to next spawn point in the list
		spawnID = (spawnID + 1) % (vents.Count);
		vents[spawnID].GetComponent<Animator>().Play("open", 0, 0);
		return vents[spawnID].transform.position;
	}
	
	public string unlockRoom() {
		unlocked++;
		
		if (unlocked == rooms.Count) {
			return "No room ";
		}
		
		rooms[unlocked].unlockRoom();
		
		updateSpawnPoints();
		
		return rooms[unlocked].name;
	}
}
