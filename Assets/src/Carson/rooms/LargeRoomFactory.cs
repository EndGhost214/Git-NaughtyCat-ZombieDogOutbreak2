using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeRoomFactory : AbstractRoomFactory
{
	private GameObject roomPrefab;
	private Dictionary<string, List<Vector3>> roomInfo;
	
	public LargeRoomFactory(GameObject basicRoom) {
		roomPrefab = basicRoom;
	}
	
	void Awake() {
		List<Vector3> locations = new List<Vector3>();
		locations.Add(new Vector3(32.98f, 5.45f, 0));
		locations.Add(new Vector3(9.96f, -5.31f, -0.11f));
		locations.Add(new Vector3(-17.73f, 3.46f, -1));
		locations.Add(new Vector3(10.34f, -6.82f, -1));
		
		roomInfo.Add("Laboratory", locations);
	}
	
	public override Room createRoom(string name) {
		GameObject newRoom = Instantiate(roomPrefab);
		Room room = newRoom.GetComponent<Room>();
		
		//room.setSpawnPoints(spawnPoints);
		
		
		return room;
	}
}
