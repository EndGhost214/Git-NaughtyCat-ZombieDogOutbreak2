/*
 * Room.cs
 * Carson Sloan
 * Interface to be implemented by small and large rooms.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Class that defines the general attributes for map rooms.
 * 
 * PUBLIC PROPERTIES:
 * name - the name of the room
 *
 * PROTECTED PROPERTIES:
 * locked - whether the doors are enabled and the vents are disabled
 */
public abstract class Room : MonoBehaviour
{
	public new string name; // hide the property Object.name
	protected bool locked = true; // true means the doors are locked and spawning is disabled
	
	/*
	 * Returns whether this room is locked.
	 */
	public bool isLocked()
	{
		return locked;
	}
	
	// Abstract methods to be implemented for specific Room types
	public abstract void unlockRoom();
	public abstract void lockRoom();
	public abstract void setSpawnPoints(List<GameObject> newVents);
	public abstract void setDoors(List<GameObject> newDoors);
	public abstract List<GameObject> getSpawnPoints();
}