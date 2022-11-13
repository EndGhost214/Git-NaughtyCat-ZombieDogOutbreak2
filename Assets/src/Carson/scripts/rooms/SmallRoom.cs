/*
 * SmallRoom.cs
 * Carson Sloan
 * Script to be attached to each room container GameObject to manage its doors and vents.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Class that defines the general attributes and behavior for small map rooms.
 * 
 * PUBLIC PROPERTIES:
 * name - the name of the room
 *
 * PRIVATE PROPERTIES:
 * doors - list of all doors inside the room
 * vents - list of all vents inside the room
 * locked - whether the doors are enabled and the vents are disabled
 */
public class SmallRoom : Room
{
	private GameObject door;
	private GameObject vent;
	
	/*
	 * Sets the locked property to false, plays the unlock noise, and disables the doors.
	 */
	public override void unlockRoom()
	{
		locked = false;
		SoundManager.Instance.unlockDoorFunction();
		
		door.SetActive(false);
	}
	
	/*
	 * Sets the locked property to true, plays the unlock noise, and enables the doors.
	 */
	public override void lockRoom()
	{
		locked = true;
		SoundManager.Instance.unlockDoorFunction();
		
		door.SetActive(true);

	}
	
	/*
	 * Add the vents to the room.
	 * Parameter newVents is a list of the vent GameObjects inside this room.
	 */
	public override void setSpawnPoints(List<GameObject> newVents)
	{
		vent = newVents[0];
	}
	
	/*
	 * Add the doors to the room.
	 * Parameter newDoors is a list of the door GameObjects inside this room.
	 */
	public override void setDoors(List<GameObject> newDoors)
	{
		door = newDoors[0];
	}
	
	/*
	 * Returns the list of vents in this room.
	 */
	public override List<GameObject> getSpawnPoints()
	{
		return new List<GameObject>(){vent};
	}
}

