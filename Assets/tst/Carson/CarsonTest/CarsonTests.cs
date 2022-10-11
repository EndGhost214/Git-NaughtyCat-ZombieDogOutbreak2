using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

public class CarsonTests : MonoBehaviour {
	[Test]
	public void spawnPlayer() {
		GameManager.Instance.StartGame(1);
		
		Assert.AreNotEqual(null, GameManager.Instance.GetPlayer());
	}
	
	[Test]
	public void spawnDog() {
		Dog testDog = new ZombieDog();
		
		Assert.AreNotEqual(null, GameManager.Instance.GetPlayer());
	}
}
