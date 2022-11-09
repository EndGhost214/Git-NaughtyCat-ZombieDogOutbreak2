using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that defines the general attributes and behavior for room objects
public class Room : MonoBehaviour
{
	private List<Vector3> spawnPoints;
	private List<GameObject> doors;
	//private GameObject doorPrefab;
	public string name;
	private bool locked = true;
	
	void Awake() {
		spawnPoints = new List<Vector3>();
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
		// Play
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
	public void setSpawnPoints(List<Vector3> p) {
		foreach (Vector3 point in p) {
			spawnPoints.Add(transform.TransformPoint(point));
		}
	}
	
	public void setDoors(List<GameObject> d) {
		doors = d;
	}
	
	public List<Vector3> getSpawnPoints() {
		return spawnPoints;
	}
	
	
}
