using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeRoomFactory : AbstractRoomFactory
{	
	public GameObject roomPrefab;
	
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
		lab.door.Add(new Vector3(19.0079f, 16.8899f, -0.116f));
		lab.door.Add(new Vector3(9.96f, -5.31f, -0.11f));
		lab.spawn.Add(new Vector3(-18.2999992f, 4.19999981f, 0f));
		lab.spawn.Add(new Vector3(37.7999992f , 9f, 0f));
		lab.home = new Vector3(16.5747f,-10.4444f,0.22559f);
		
		Positions kitchen = new Positions("Kitchen");
		kitchen.door.Add(new Vector3(36.79f, 27.9f, -0.12f));
		kitchen.door.Add(new Vector3(5.91f, 27.9f, -0.12f));
		kitchen.spawn.Add(new Vector3(18.87f, 41.2f, -1));
		kitchen.spawn.Add(new Vector3(6.57f, 48.65f, -1));
		
		roomInfo.Add(lab.roomName, lab);
		roomInfo.Add(kitchen.roomName, kitchen);
	}
	
	public override Room createRoom(string name) {
		GameObject newRoom = Instantiate(roomPrefab, roomInfo[name].home, Quaternion.identity);
		Room room = newRoom.GetComponent<Room>();
		
		List<Vector3> spawnPoints = new List<Vector3>();
		spawnPoints.AddRange(roomInfo[name].spawn);
		
		List<Vector3> doorPositions = new List<Vector3>();
		doorPositions.AddRange(roomInfo[name].door);

		Transform temp = newRoom.transform.Find("vent");
		temp.position = newRoom.transform.InverseTransformPoint(spawnPoints[0]);
		//Instantiate(temp.gameObject, spawnPoints[1], Quaternion.identity, newRoom.transform);
		temp = Instantiate(temp.gameObject, newRoom.transform, false).transform;
		temp.position = spawnPoints[1];
		
		List<GameObject> doors = new List<GameObject>();
		doors.Add(newRoom.transform.Find("door").gameObject);
		doors[0].transform.position = doorPositions[0];
		doors.Add(Instantiate(doors[0], doorPositions[1], Quaternion.identity, newRoom.transform));
		
		room.setSpawnPoints(spawnPoints);
		room.setDoors(doors);
		return room;
	}
}
