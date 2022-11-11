/*
 * Room.cs
 * Carson Sloan
 * Script to be attached to each room container GameObject to manage its doors and vents.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Class that defines the general attributes and behavior for map rooms.
 * 
 * PUBLIC PROPERTIES:
 * name - the name of the room
 *
 * PRIVATE PROPERTIES:
 * doors - list of all doors inside the room
 * vents - list of all vents inside the room
 * locked - whether the doors are enabled and the vents are disabled
 */
public class Room : MonoBehaviour
{
	public new string name; // overrides the property Object.name

	private List<GameObject> doors;
	private List<GameObject> vents;
	private bool locked = true; // true means the doors are locked and spawning is disabled
	
	/*
	 * Called by Unity when the script is loaded for the first time to initialize lists.
	 */
	public void Awake()
	{
		vents = new List<GameObject>();
		doors = new List<GameObject>();
	}

	/*
	 * Sets the locked property to false, plays the unlock noise, and disables the doors.
	 */
	public void unlockRoom()
	{
		locked = false;
		SoundManager.Instance.unlockDoorFunction();
		
		// Disable all doors in this room
		foreach (GameObject d in doors)
		{
			d.SetActive(false);
		}
	}
	
	/*
	 * Sets the locked property to true, plays the unlock noise, and enables the doors.
	 */
	public void lockRoom()
	{
		locked = true;
		SoundManager.Instance.unlockDoorFunction();
		
		// Reenable all doors in this room
		foreach (GameObject d in doors)
		{
			d.SetActive(true);
		}
	}
	
	/*
	 * Returns whether this room is locked.
	 */
	public bool isLocked()
	{
		return locked;
	}
	
	/*
	 * Add the vents to the room.
	 * Parameter newVents is a list of the vent GameObjects inside this room.
	 */
	public void setSpawnPoints(List<GameObject> newVents)
	{
		vents.AddRange(newVents);
	}
	
	/*
	 * Add the doors to the room.
	 * Parameter newDoors is a list of the door GameObjects inside this room.
	 */
	public void setDoors(List<GameObject> newDoors)
	{
		doors.AddRange(newDoors);
	}
	
	/*
	 * Returns the list of vents in this room.
	 */
	public List<GameObject> getSpawnPoints()
	{
		return vents;
	}
}

