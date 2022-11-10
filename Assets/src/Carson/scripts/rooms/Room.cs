using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that defines the general attributes and behavior for room objects
public class Room : MonoBehaviour
{
	public new string name;

	//private List<Vector3> spawnPoints;
	private List<GameObject> doors;
	private List<GameObject> vents;
	private bool locked = true;
	
	void Awake() {
		vents = new List<GameObject>();
	}

	public void unlockRoom() {
		locked = false;
		SoundManager.Instance.unlockDoorFunction();
		foreach (GameObject d in doors) {
			d.SetActive(false);
		}
	}
	
	public void lockRoom() {
		locked = true;
		SoundManager.Instance.unlockDoorFunction();
		foreach (GameObject d in doors) {
			d.SetActive(true);
		}
	}
	
	public bool isLocked() {
		return locked;
	}
	
	/*
	 * Add the provided list of spawn points to the room.
	 * Spawn points are first converted from local space relative to the GameObject
	 * this script is attached to into world space.
	 */
	public void setSpawnPoints(List<GameObject> newVents) {
		vents.AddRange(newVents);
	}
	
	public void setDoors(List<GameObject> d) {
		doors = d;
	}
	
	public List<GameObject> getSpawnPoints() {
		return vents;
	}
	
	
}
