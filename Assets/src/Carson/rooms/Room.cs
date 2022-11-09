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
	
	public void setSpawnPoints(List<Vector3> p) {
		spawnPoints = p;
	}
	
	public void setDoors(List<GameObject> d) {
		doors = d;
	}
	
	public List<Vector3> getSpawnPoints() {
		return spawnPoints;
	}
	
	
}
