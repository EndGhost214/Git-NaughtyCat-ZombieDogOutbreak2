/*
 * SmallRoomFactory.cs
 * Carson Sloan
 * Provides the set up information for rooms with one door and one vent.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Class that extends AbstractRoomFactory. Implements the abstract setUp method, which adds
 * an entry to the roomInfo dictionary for each small room to be created on the map. Does
 * not override the virtual createRoom metod in AbstractRoomFactory.
 */
public class SmallRoomFactory : AbstractRoomFactory
{
	/*
	 * Sets the door and vent positions for the exam rooms, the closet, and  thehallway, then
	 * adds them to roomInfo. Called once by Awake in AbstractRoomFactory.
	 */
	protected override void setUp()
	{
		// Create new Positions object for the first exam room
		Positions exam1 = new Positions("Exam1");
		// Add the door and vent positions
		exam1.door.Add(new Vector3(-21.3620663f, 11.2799358f, -0.116151907f));
		exam1.spawn.Add(new Vector3(-25.5799999f, 19.6299992f, 0));
		// Set the door rotation
		exam1.rotated.Add(false);
		// Set the parent GameObject position
		exam1.home = new Vector3(16.5747395f, -10.4444351f, 0.225589991f);
		
		Positions exam2 = new Positions("Exam2");
		exam2.door.Add(new Vector3(-21.3920536f, 26.0399303f, -0.116151907f));
		exam2.spawn.Add(new Vector3(-31.7800007f, 23.9599991f, 0));
		exam2.rotated.Add(false);
		exam2.home = new Vector3(16.5747395f,-10.4444351f,0.225589991f);
		
		Positions closet = new Positions("Closet");
		closet.door.Add(new Vector3(38.7700005f, -6.19000006f, -0.116151907f));
		closet.spawn.Add(new Vector3(43.2700005f, -8.39000034f, 0));
		closet.rotated.Add(false);
		closet.home = new Vector3(16.5747395f, -10.4444351f, 0.225589991f);
		
		Positions hallway = new Positions("Hallway");
		hallway.door.Add(new Vector3(-21.3920536f, 26.0399303f, -0.116151907f));
		hallway.spawn.Add(new Vector3(-32.8800011f, 20.5200005f, 0));
		hallway.rotated.Add(false);
		hallway.home = new Vector3(36.9599991f, 12.0600004f, 0.225589991f);
		
		// Add the new Positions objects to the dictionary
		addToDictionary(exam1);
		addToDictionary(exam2);
		addToDictionary(closet);
		addToDictionary(hallway);
	}
}

