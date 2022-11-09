using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeRoomFactory : AbstractRoomFactory
{	
	protected override void setUp() {
		Positions lab = new Positions("Laboratory");
		lab.door.Add(new Vector3(18.4099998f, 16.2800007f, -0.115999997f));
		lab.door.Add(new Vector3(-3.55999994f, 5.55999994f, -0.225589991f));
		lab.spawn.Add(new Vector3(-12.0600004f, 3.81999993f, -0.225590006f));
		lab.spawn.Add(new Vector3(37.7999992f , 9f, 0f));
		lab.rotated.Add(false);
		lab.rotated.Add(true);
		lab.home = new Vector3(16.5747f, -10.4444f, 0.22559f);
		
		Positions kitchen = new Positions("Kitchen");
		kitchen.door.Add(new Vector3(5.67000008f, 27.2700005f, -0.116151907f));
		kitchen.door.Add(new Vector3(35.9599991f, 27.2199993f, -0.116151907f));
		kitchen.spawn.Add(new Vector3(27.2000008f, 39.5999985f, 0));
		kitchen.spawn.Add(new Vector3(5.9000001f, 58.4000015f, 0));
		kitchen.rotated.Add(true);
		kitchen.rotated.Add(true);
		kitchen.home = new Vector3(16.5747395f, -10.4444351f, 0.225589991f);
		
		addToDictionary(lab);
		addToDictionary(kitchen);
	}
	
	public override Room createRoom(string name) {
		GameObject newRoom = Instantiate(roomPrefab, roomInfo[name].home, Quaternion.identity);
		newRoom.name = name;
		Room room = newRoom.GetComponent<Room>();
		room.name = name;
		
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
		
		// Rotate doors by 90 degrees if required
		for (int i = 0; i < 2; i++) {
			if (roomInfo[name].rotated[i]) {
				doors[i].transform.Rotate(0, 0, 90);
			}
		}
		
		room.setSpawnPoints(spawnPoints);
		room.setDoors(doors);
		return room;
	}
}
