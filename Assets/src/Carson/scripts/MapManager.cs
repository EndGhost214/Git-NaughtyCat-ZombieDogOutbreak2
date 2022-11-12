/*
 * MapManager.cs
 * Carson Sloan
 * Controls and initializes map elements.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Class to create room objects and handle unlocking rooms, enemy spawnpoints and vent animations.
 * 
 * PRIVATE PROPERTIES:
 * basicRoom - room prefab to be copied by the room factories
 * vents - list of spawnable vent objects in unlocked rooms 
 * unlocked - index of the last room to be unlocked
 * spawnID - index of the last vent to be used to spawn enemies
 */
public class MapManager : Singleton<MapManager>
{
	[SerializeField]
	private GameObject basicRoom;
	
	private List<GameObject> vents;
	private List<Room> rooms;
	private int unlocked;
	private int spawnID = 0; // index of next spawnpoint to use
	
	/*
	 * Generate rooms and add them to the room list. Called by startGame in GameManger.
	 */
	public void startGame()
	{
		rooms = new List<Room>();
		unlocked = -1;
		
		// Create abstract factory variable to hold either factory type
		AbstractRoomFactory factory = gameObject.AddComponent<LargeRoomFactory>(); // make large room factory
		factory.roomPrefab = basicRoom;
		// Create the two large rooms and add them to the list
		rooms.Add(factory.createRoom("Laboratory"));
		rooms.Add(factory.createRoom("Kitchen"));

		Destroy(factory); // remove the old factory component
		factory = gameObject.AddComponent<SmallRoomFactory>(); // make small room factory
		factory.roomPrefab = basicRoom;
		// Create the four small rooms and position them in unlocked order in the list
		rooms.Insert(0, factory.createRoom("Exam room"));
		rooms.Insert(1, factory.createRoom("Surgery room"));
		rooms.Insert(3, factory.createRoom("Bathroom"));
		rooms.Add(factory.createRoom("Sprinkler room"));
		
		Destroy(factory); // remove the old factory component
	}
	
	/*
	 * Returns the next position a dog should be spawned, and controls the animations of the affected vents.
	 */
	public Vector3 nextSpawn()
	{
		// Increment counter to next spawn point in the list
		spawnID = (spawnID + 1) % (vents.Count);
		// Start the vent open animation
		vents[spawnID].GetComponent<Animator>().Play("open", 0, 0);
		// Disable the red closed texture
		vents[spawnID].GetComponent<Animator>().SetBool("spawning", false);
		// Enable the red texture for the next vent to spawn
		vents[(spawnID + 1) % (vents.Count)].GetComponent<Animator>().SetBool("spawning", true);
		return vents[spawnID].transform.position;
	}
	
	/*
	 * Unlocks the next locked room, updates the vent list and resets animations for the first wave of the new round.
	 * Returns the name of the room that was just unlocked, "" if all rooms are already unlocked.
	 */
	public string unlockRoom()
	{
		unlocked++;
		
		if (unlocked == rooms.Count)
		{
			return "";
		}
		
		rooms[unlocked].unlockRoom();
		
		updateSpawnPoints();
		
		foreach (GameObject vent in vents)
		{
			// Disable the red closed texture
			vent.GetComponent<Animator>().SetBool("spawning", false);
		}
		
		// Make the next vent to spawn red
		vents[(spawnID + 1) % (vents.Count)].GetComponent<Animator>().SetBool("spawning", true);
		
		return rooms[unlocked].name;
	}

	/*
	 * Updates the internal list of vent GameObjects that can be spawned at during the next round.
	 * Called only by unlockRoom.
	 */
	private void updateSpawnPoints()
	{
		vents = new List<GameObject>(); // reset vents
		
		// Add the vents from each unlocked room to the list
		foreach (Room room in rooms)
		{
			if (!room.isLocked())
			{
				vents.AddRange(room.getSpawnPoints());
			}
		}
	}
}

