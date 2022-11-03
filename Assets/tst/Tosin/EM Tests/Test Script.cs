using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TestScript
{
    [OneTimeSetUp]
    public void LoadScene()
    {
        SceneManager.LoadScene("Cutscene#1");
    }

    [Test]
    public void CutSceneTest1()
    {
        Assert.That(8, Is.InRange(2,100));
    }

    // [Test]
    // public void Bounds1()
    // {
    //     private b1 = GameObject.Find("Bound1").transform.position;
    //     Assert.That(b1.hasChanged, false);
    // }
}
