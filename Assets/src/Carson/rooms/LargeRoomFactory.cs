using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeRoomFactory : AbstractRoomFactory
{
	private GameObject roomPrefab;
	private List<Vector3> spawnPoints;
	
	public LargeRoomFactory(GameObject basicRoom) {
		roomPrefab = basicRoom;
	}
	
	public override Room createRoom(string name) {
		GameObject newRoom = Instantiate(roomPrefab);
		Room room = newRoom.GetComponent<Room>();
		
		room.setSpawnPoints(spawnPoints);
		
		setDoor();
		
		return room;
	}
	
	protected override void setDoor() {
		
	}
}
