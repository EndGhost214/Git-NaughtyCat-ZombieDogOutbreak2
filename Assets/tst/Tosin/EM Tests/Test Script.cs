using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Tests
{

    public class TestScript : MonoBehaviour
    {
        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("Cutscene#1");
        }
        [UnityTest]
        public IEnumerator Bounds1()
        {
            yield return 50;
        }
    }
}
