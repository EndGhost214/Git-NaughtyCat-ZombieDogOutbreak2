using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that defines the general attributes and behavior for room objects
public class Room : MonoBehaviour
{
	private List<Vector3> spawnPoints;
	private List<GameObject> doors;
	//private GameObject doorPrefab;
	private string name;
	private int id;
	private bool locked = true;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
