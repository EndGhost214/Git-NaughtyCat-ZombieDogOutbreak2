using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallRoomFactory : AbstractRoomFactory
{
	public GameObject roomPrefab;
	
	protected override void setUp() {
		
	}
	
	public override Room createRoom(string name) {
		GameObject newRoom = Instantiate(roomPrefab);
		Room room = newRoom.GetComponent<Room>();
		
		return room;
	}
}
