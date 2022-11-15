/*
 * CarsonTests.cs
 * Carson Sloan
 * Unit tests for my scripts.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

/*
 * Test class for the Game and Map manager scripts.
 *
 * PRIVATE PROPERTIES:
 * room - Room object for testing
 */
public class CarsonTests : MonoBehaviour
{
	private Room room;
	
	/*
	 * Create a new room, add a vent to it with position (1, 0, 0), get all room vents, and check that the position is correct.
	 */
	[Test]
	public void addSpawnPoint()
	{
		setUp();
		
		GameObject vent = new GameObject();
		vent.transform.position = new Vector3(1, 0, 0);
		
		room.setSpawnPoints(new List<GameObject>(){vent});
		
		Assert.AreEqual(1, room.getSpawnPoints()[0].transform.position.x);
	}
	
	/*
	 * Create a new room, call the lock function, and check that it's locked.
	 */
	[Test]
	public void lockRoom()
	{
		setUp();
		
		room.lockRoom();
		
		Assert.AreEqual(true, room.isLocked());
	}
	
	/*
	 * Create a new room, call the unlock function, and check that it's not locked.
	 */
	[Test]
	public void unlockRoom()
	{
		setUp();
		
		room.unlockRoom();
		
		Assert.AreEqual(false, room.isLocked());
	}
	
	/*
	 * Called before tests to set up rooms for testing.
	 */
	private void setUp()
	{
		room = new SmallRoom();
		room.setDoors(new List<GameObject>(){new GameObject()});
	}
}

