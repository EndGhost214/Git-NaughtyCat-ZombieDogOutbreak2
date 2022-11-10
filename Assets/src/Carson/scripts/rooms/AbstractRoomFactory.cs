using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Abstract class defining the methods and fields implemented by all child classes.
 */
public abstract class AbstractRoomFactory : MonoBehaviour
{
	public GameObject roomPrefab;
	
	protected Dictionary<string, Positions> roomInfo;
	
	protected class Positions {
		public string roomName {get;}
		public Vector3 home;
		public List<bool> rotated {get;}
		public List<Vector3> spawn {get;}
		public List<Vector3> door {get;}
		
		public Positions(string name) {
			rotated = new List<bool>();
			spawn = new List<Vector3>();
			door = new List<Vector3>();
			roomName = name;
		}
	}
	
	void Awake() {
		roomInfo = new Dictionary<string, Positions>();
		setUp();
	}
	
	protected abstract void setUp();
	
	protected void addToDictionary(Positions newPos) {
		roomInfo.Add(newPos.roomName, newPos);
	}
	
	// Function to create a new room and return a reference to its script component
	public virtual Room createRoom(string name) {
		GameObject newRoom = Instantiate(roomPrefab, roomInfo[name].home, Quaternion.identity);
		newRoom.name = name;
		Room room = newRoom.GetComponent<Room>();
		room.name = name;
		
		List<Vector3> spawnPoints = new List<Vector3>();
		spawnPoints.AddRange(roomInfo[name].spawn);
		
		List<Vector3> doorPositions = new List<Vector3>();
		doorPositions.AddRange(roomInfo[name].door);

		// Store the vents in a list so the map manager can control them
		List<GameObject> vents = new List<GameObject>();
		// Get the prefab vent
		vents.Add(newRoom.transform.Find("vent").gameObject);
		vents[0].transform.position = newRoom.transform.TransformPoint(spawnPoints[0]);
		
		// Store the doors in a list so the map manager can open them
		List<GameObject> doors = new List<GameObject>();
		// Get the prefab door
		doors.Add(newRoom.transform.Find("door").gameObject);
		doors[0].transform.position = newRoom.transform.TransformPoint(doorPositions[0]);		
		if (roomInfo[name].rotated[0]) {
			doors[0].transform.Rotate(0, 0, 90);
		}
		
		room.setSpawnPoints(vents);
		room.setDoors(doors);
		return room;
	}
}
