using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that defines the general attributes and behavior for room objects
public class Room : MonoBehaviour
{
	protected List<Vector3> spawnPoints;
	protected string name;
	protected int id;
	protected bool locked;
	
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
	}
	
	public void lockRoom() {
		locked = true;
	}
	
	public bool isLocked() {
		return locked;
	}
}
