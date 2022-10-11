using System.Collections;
using System.Collections.Generic;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine;

public class MMTestHealth : MonoBehaviour
{
   //Checks to see if the constructor is setting the health equal to 100
   //Will throw warning due to new keyword
   [Test]
    public void Check_Health_Is_100(){
    
    ZombieDog t1 = new ZombieDog();
    //assertStatement
    Assert.AreEqual(100, t1.GetHealth());
    }
   
   //Checks to see if the damage function will take 50 off of the health of the instance of the zombie dog
   //Will throw warnings due to new keyword
   //In future TakeDamage will connect to users weapon collision
   [Test]
   public void Take_50_Damage(){
    ZombieDog t1 = new ZombieDog();
    //assertStatement
    t1.TakeDamage();
    Assert.AreEqual(50, t1.GetHealth());
   }
}
