using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallRoomFactory : AbstractRoomFactory
{
	private GameObject roomPrefab;
	
	public SmallRoomFactory(GameObject basicRoom) {
		roomPrefab = basicRoom;
	}
	
	public override Room createRoom(string name) {
		GameObject newRoom = Instantiate(roomPrefab);
		Room room = newRoom.GetComponent<Room>();
		
		return room;
	}
}
