using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeRoomFactory : AbstractRoomFactory
{
	private GameObject roomPrefab;
	private Dictionary<string, Vector3, Vector3, Vector3, Vector3> roomInfo;
	
	public LargeRoomFactory(GameObject basicRoom) {
		roomPrefab = basicRoom;
	}
	
	void Awake() {
		roomInfo.Add("Laboratory", Vector3(32.9799995,5.44999981,0), Vector3(9.95774174,-5.30999994,-0.109438084), 
	}
	
	public override Room createRoom(string name) {
		GameObject newRoom = Instantiate(roomPrefab);
		Room room = newRoom.GetComponent<Room>();
		
		room.setSpawnPoints(spawnPoints);
		
		
		return room;
	}
}
