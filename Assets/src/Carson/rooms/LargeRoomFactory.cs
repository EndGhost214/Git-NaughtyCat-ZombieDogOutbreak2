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
		lab.door.Add(new Vector3(-4.01432419f,6.12993574f,-0.225589991f));
		lab.spawn.Add(new Vector3(-18.2700005f, 4.15999985f, -0.225590006f));
		lab.spawn.Add(new Vector3(37.7999992f , 9f, 0f));
		lab.home = new Vector3(16.5747f,-10.4444f,0.22559f);
		
		Positions kitchen = new Positions("Kitchen");
		kitchen.door.Add(new Vector3(5.90793419f,27.8999348f,-0.116151907f));
		kitchen.door.Add(new Vector3(36.7879333f,27.8999348f,-0.116151907f));
		kitchen.spawn.Add(new Vector3(27.2000008f,39.5999985f,0));
		kitchen.spawn.Add(new Vector3(5.9000001f,58.4000015f,0));
		kitchen.home = new Vector3(16.5747395f,-10.4444351f,0.225589991f);
		
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

		// Get the prefab vent
		Transform temp = newRoom.transform.Find("vent");
		temp.position = newRoom.transform.TransformPoint(spawnPoints[0]);
		Instantiate(temp.gameObject, newRoom.transform.TransformPoint(spawnPoints[1]), Quaternion.identity, newRoom.transform);
		
		// Store the doors in a list so the map manager can open them
		List<GameObject> doors = new List<GameObject>();
		// Get the prefab door
		doors.Add(newRoom.transform.Find("door").gameObject);
		doors[0].transform.position = newRoom.transform.TransformPoint(doorPositions[0]);
		// Make a copy for the second door
		doors.Add(Instantiate(doors[0], newRoom.transform.TransformPoint(doorPositions[1]), Quaternion.identity, newRoom.transform));
		doors[1].transform.rotation = Quaternion.Lerp(doors[1].transform.rotation, Quaternion.Euler(doors[1].transform.eulerAngles + new Vector3(0, 0, 90f)), 1f);
		
		room.setSpawnPoints(spawnPoints);
		room.setDoors(doors);
		return room;
	}
}
