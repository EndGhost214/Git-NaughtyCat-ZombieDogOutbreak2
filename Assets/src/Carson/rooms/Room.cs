using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that defines the general attributes and behavior for room objects
public class Room : MonoBehaviour
{
	private List<Vector3> spawnPoints;
	private GameObject doorPrefab;
	private string name;
	private int id;
	private bool locked;
	
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
		doorPrefab.SetActive(false);
	}
	
	public void lockRoom() {
		locked = true;
		doorPrefab.SetActive(true);
	}
	
	public bool isLocked() {
		return locked;
	}
	
	public void setSpawnPoints(List<Vector3> p) {
		spawnPoints = p;
	}
}
