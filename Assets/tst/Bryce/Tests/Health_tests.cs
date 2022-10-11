using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
public class Health_tests : MonoBehaviour
{



    [Test]
    public void checkPlayerHealthisFull()
    {
        SurvivalPlayer bob = new SurvivalPlayer();
        uint check;
        check = bob.GetHealth();
        Assert.AreEqual(check, 100);
    }

    [Test]
    public void checkPlayerHealthAfterDamage()
    {

        SurvivalPlayer bob = new SurvivalPlayer();
        uint check;
        bob.DamagePlayer(50);
        check = bob.GetHealth();
        Assert.AreEqual(check, 50);
    }
}
