using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Abstract class defining the methods and fields implemented by all child classes.
 */
public abstract class AbstractRoomFactory : MonoBehaviour
{
	protected class Positions {
		public string roomName {get;}
		public List<Vector3> spawn {get;}
		public List<Vector3> door {get;}
		
		public Positions(string name) {
			spawn = new List<Vector3>();
			door = new List<Vector3>();
			roomName = name;
		}
	}
	
	protected Dictionary<string, Positions> roomInfo;
	
	void Awake() {
		setUp();
	}
	
	protected abstract void setUp();
	
	// Function to create a new room and return a reference to its script component
	public abstract Room createRoom(string name);
}
