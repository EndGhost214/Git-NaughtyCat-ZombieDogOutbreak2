using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

// Test class for the Game and Map manager scripts.
public class CarsonTests : MonoBehaviour {
	
	// Start the game in normal difficulty and test if a player was created
	[Test]
	public void spawnPlayer() {
		GameManager.Instance.startGame(1); // start the game
		// Make sure the player getter works and the player reference isn't null
		Assert.AreNotEqual(null, GameManager.Instance.getPlayerObject());
	}
	
	// Start the game in normal difficulty and test if the inital wave of dogs is created
	[Test]
	public void spawnDog() {
		GameManager.Instance.startGame(1);
		Assert.AreEqual(0, GameManager.Instance.enemiesLeft());
	}
}
