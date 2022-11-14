/*
 * AbstractRoomFactory.cs
 * Carson Sloan
 * Abstract class defining general behavior for room factories, implementing the AbstractFactory pattern.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * AbstractFactory class defining the methods and fields implemented by all child factories.
 *
 * PUBLIC PROPERTIES:
 * roomPrefab - a reference to the basic room to make copies of
 *
 * PROTECTED PROPERTIES:
 * roomInfo - a dictionary holding Positions objects identified by string keys
 * Positions - class that contains all room creation data
 */
public abstract class AbstractRoomFactory : MonoBehaviour
{
	public GameObject roomPrefab; // assigned by the MapManager when the factory is created
	
	protected Dictionary<string, Positions> roomInfo;
	
	/*
	 * Simple class used to hold all of the Vector3 positions and general data 
	 * that are needed in the creation of each room.
	 *
	 * PUBLIC PROPERTIES:
	 * roomName - name of the room (get only)
	 * home - position of the parent GameObject
	 * rotated - list of bools corresponding to each door
	 * spawn - list of positions for the vents
	 * door - list of positions for the doors
	 */
	protected class Positions
	{
		public string roomName {get;}
		public Vector3 home;
		public List<bool> rotated {get;} // if true, the door will be rotated 90 degrees
		public List<Vector3> spawn {get;}
		public List<Vector3> door {get;}
		
		/*
		 * Constructor for a new Positions object that sets the name and initializes the lists.
		 * Parameter name is the room name.
		 */
		public Positions(string name)
		{
			rotated = new List<bool>();
			spawn = new List<Vector3>();
			door = new List<Vector3>();
			roomName = name;
		}
	}
	
	
	/*
	 * Unity method that is called when the script loads for the first time.
	 */
	public void Awake()
	{
		roomInfo = new Dictionary<string, Positions>();
		setUp(); // call the setUp method implemented by the child factories
	}
	
	/*
	 * Instantiates a new copy of the basic room prefab, gets the existing vent and door, and sets the
	 * positions of each child object. The attached room script is initialized as well, then returned.
	 * Parameter name is the key to use in the dictionary to find the Positions, and to set in the Room class.
	 */
	public virtual Room createRoom(string name)
	{
		// Create new room GameObject
		GameObject newRoom = Instantiate(roomPrefab, roomInfo[name].home, Quaternion.identity);
		newRoom.name = name;
		Room room = newRoom.AddComponent<SmallRoom>(); // attach the proper Room script
		room.name = name;
		
		// Get a copy of the spawnPoints in the dictionary
		List<Vector3> spawnPoints = new List<Vector3>();
		spawnPoints.AddRange(roomInfo[name].spawn);
		
		// Get a copy of the doorPositions in the dictionary
		List<Vector3> doorPositions = new List<Vector3>();
		doorPositions.AddRange(roomInfo[name].door);

		// Store the vents in a list so the map manager can control them
		List<GameObject> vents = new List<GameObject>();
		// Get the prefab vent
		vents.Add(newRoom.transform.Find("vent").gameObject);
		vents[0].transform.position = newRoom.transform.TransformPoint(spawnPoints[0]);
		
		// Store the doors in a list so the map manager can open them
		List<GameObject> doors = new List<GameObject>();
		// Get the prefab door
		doors.Add(newRoom.transform.Find("door").gameObject);
		doors[0].transform.position = newRoom.transform.TransformPoint(doorPositions[0]);
		// Rotate the door by 90 degrees if needed
		if (roomInfo[name].rotated[0])
		{
			doors[0].transform.Rotate(0, 0, 90);
		}
		
		// Update the room script
		room.setSpawnPoints(vents);
		room.setDoors(doors);
		return room;
	}
	
	/*
	 * Child classes which implement setUp should populate roomInfo with the rooms they are responsible
	 * for creating. If any Positions object added to roomInfo has lists of Count > 1, override
	 * createRoom to implement handling for the extra positions.
	 */
	protected abstract void setUp();
	
	/*
	 * Adds the provided positions object to the dictionary, with its roomName property as the key.
	 * Parameter newPos is the object to be added.
	 */
	protected void addToDictionary(Positions newPos)
	{
		roomInfo.Add(newPos.roomName, newPos);
	}
}

