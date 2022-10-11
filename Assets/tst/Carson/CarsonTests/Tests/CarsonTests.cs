using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

public class CarsonTests : MonoBehaviour {
	[Test]
	public void spawn_dog_in_wall() {
		GameManager.Instance.StartGame(1);
		Assert.AreNotEqual(null, GameManager.Instance.GetPlayer());
	}
}
