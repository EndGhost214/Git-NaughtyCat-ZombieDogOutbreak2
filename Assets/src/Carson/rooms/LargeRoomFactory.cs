using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeRoomFactory : AbstractRoomFactory
{	
	public GameObject roomPrefab;
	private List<Vector3> locations;
	private List<Vector3> locations1;
	
	protected override void setUp() {
		roomInfo = new Dictionary<string, Positions>();
		/*
		locations = new List<Vector3>();
		locations.Add(new Vector3(32.98f, 5.45f, 0));
		locations.Add(new Vector3(9.96f, -5.31f, -0.11f));
		locations.Add(new Vector3(-17.73f, 3.46f, -1));
		locations.Add(new Vector3(10.34f, -6.82f, -1));
		roomInfo.Add("Laboratory", locations);
		
		locations1 = new List<Vector3>();
		locations1.Add(new Vector3(36.79f, 27.9f, -0.12f));
		locations1.Add(new Vector3(5.91f, 27.9f, -0.12f));
		locations1.Add(new Vector3(18.87f, 41.2f, -1));
		locations1.Add(new Vector3(6.57f, 48.65f, -1));
		roomInfo.Add("Kitchen", locations1);
		
		foreach(string key in roomInfo.Keys) {
			Debug.Log(key);
		}*/
		
		Positions lab = new Positions("Laboratory");
		locations = new List<Vector3>();
		locations.Add(new Vector3(32.98f, 5.45f, 0));
		locations.Add(new Vector3(9.96f, -5.31f, -0.11f));
		lab.door.AddRange(locations);
		Debug.Log(lab.door[0]);
		Positions kitchen = new Positions("Kitchen");
		locations = new List<Vector3>();
		locations.Add(new Vector3(36.79f, 27.9f, -0.12f));
		locations.Add(new Vector3(5.91f, 27.9f, -0.12f));
		kitchen.door.AddRange(locations);
		Debug.Log(kitchen.door[0]);
		Debug.Log(lab.door[0]);
		
		roomInfo.Add(lab.roomName, lab);
		roomInfo.Add(kitchen.roomName, kitchen);
	}
	
	public override Room createRoom(string name) {
		foreach(string key in roomInfo.Keys) {
			Debug.Log(key);
		}
		GameObject newRoom = Instantiate(roomPrefab);
		Room room = newRoom.GetComponent<Room>();
		
		List<Vector3> spawnPoints = new List<Vector3>();
		spawnPoints.AddRange(roomInfo[name].spawn);
		//spawnPoints.Add(roomInfo[name][3]);
		
		room.setSpawnPoints(spawnPoints);
		return room;
	}
}
