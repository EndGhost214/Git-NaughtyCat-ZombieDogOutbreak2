/*
 * LargeRoomFactory.cs
 * Carson Sloan
 * Creates the rooms that have two doors and two vents.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class that extends AbstractRoomFactory. Implements the abstract setUp method, which adds
 * an entry to the roomInfo dictionary for each large room to be created on the map.
 */
public class LargeRoomFactory : AbstractRoomFactory
{
	/*
	 * Sets the door and vent positions for the Laboratory and Kitchen, and adds them to roomInfo.
	 * Called once by Awake in AbstractRoomFactory.
	 */
	protected override void setUp()
	{
		// Initialize positions object
		Positions lab = new Positions("Laboratory");
		// Set door positions
		lab.door.Add(new Vector3(18.4099998f, 16.2800007f, -0.115999997f));
		lab.door.Add(new Vector3(-3.55999994f, 5.55999994f, -0.225589991f));
		// Set vent positions
		lab.spawn.Add(new Vector3(-12.0600004f, 3.81999993f, -0.225590006f));
		lab.spawn.Add(new Vector3(37.7999992f , 9f, 0f));
		// Set door rotations
		lab.rotated.Add(false);
		lab.rotated.Add(true);
		// Set parent GameObject position for translating vent positions to world space for spawning
		lab.home = new Vector3(16.5747f, -10.4444f, 0.22559f);
		
		// Set up Kitchen positions
		Positions kitchen = new Positions("Kitchen");
		kitchen.door.Add(new Vector3(5.67000008f, 27.2700005f, -0.116151907f));
		kitchen.door.Add(new Vector3(35.9599991f, 27.2199993f, -0.116151907f));
		kitchen.spawn.Add(new Vector3(27.2000008f, 39.5999985f, 0));
		kitchen.spawn.Add(new Vector3(3.4000001f, 37.5999985f, 0));
		kitchen.rotated.Add(true);
		kitchen.rotated.Add(true);
		kitchen.home = new Vector3(16.5747395f, -10.4444351f, 0.225589991f);
		
		// Add the new rooms to the dictionary
		addToDictionary(lab);
		addToDictionary(kitchen);
	}
	
	/*
	 * Instantiates a new copy of the basic room prefab, makes a copy of its vent and door, and sets the
	 * positions of each child object. The attached room script is initialized as well, then returned.
	 * Parameter name is the key to use in the dictionary to find the Positions, and to set in the Room class.
	 */
	public override Room createRoom(string name)
	{
		// Create new room GameObject
		GameObject newRoom = Instantiate(roomPrefab, roomInfo[name].home, Quaternion.identity);
		newRoom.name = name;
		Room room = newRoom.GetComponent<Room>(); // get the attached room script
		room.name = name;
		
		// Get a copy of the spawnPoints in the dictionary
		List<Vector3> spawnPoints = new List<Vector3>();
		spawnPoints.AddRange(roomInfo[name].spawn);
		
		// Get a copy of the doorPositions in the dictionary
		List<Vector3> doorPositions = new List<Vector3>();
		doorPositions.AddRange(roomInfo[name].door);

		// Store the vents in a list so their animations can be individually controlled later
		List<GameObject> vents = new List<GameObject>();

		// Get the prefab vent
		vents.Add(newRoom.transform.Find("vent").gameObject);
		vents[0].transform.position = newRoom.transform.TransformPoint(spawnPoints[0]);
		vents.Add(Instantiate(vents[0], newRoom.transform.TransformPoint(spawnPoints[1]), Quaternion.identity, newRoom.transform));
		
		// Store the doors in a list so the map manager can open them
		List<GameObject> doors = new List<GameObject>();
		// Get the prefab door
		doors.Add(newRoom.transform.Find("door").gameObject);
		doors[0].transform.position = newRoom.transform.TransformPoint(doorPositions[0]);
		// Make a copy for the second door
		doors.Add(Instantiate(doors[0], newRoom.transform.TransformPoint(doorPositions[1]), Quaternion.identity, newRoom.transform));
		
		// Rotate doors by 90 degrees if required
		for (int i = 0; i < 2; i++)
		{
			if (roomInfo[name].rotated[i])
			{
				doors[i].transform.Rotate(0, 0, 90);
			}
		}
		
		// Update the room script
		room.setSpawnPoints(vents);
		room.setDoors(doors);
		return room;
	}
}
