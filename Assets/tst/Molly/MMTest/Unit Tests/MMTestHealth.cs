using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;



public class MMTestHealth : MonoBehaviour
{
   //Checks to see if the constructor is setting the health equal to 100
   //Will throw warning due to new keyword
   [Test]
    public void Check_Health_Is_100(){
    
    ZombieDog t1 = new BaseDog();
    //assertStatement
    Assert.AreEqual(100, t1.health);
    }
   
   //Checks to see if the damage function will take 50 off of the health of the instance of the zombie dog
   //Will throw warnings due to new keyword
   //In future TakeDamage will connect to users weapon collision
   [Test]
   public void Take_50_Damage(){
    ZombieDog t1 = new BaseDog();
    //assertStatement
    t1.TakeDamage(50);
    Assert.AreEqual(50, t1.health);
   }

   //Oral Exam Test Plan to test out the LevelUp Decorator Script differences with the base dog stats

   //test the health of the base dog vs the level up dog vs Boss Dog
   [Test]
   //Testing the take full health of baseDog
   public void Take_Full_Health_Base(){
      ZombieDog baseHealth = new BaseDog();
      baseHealth.TakeDamage(100f);
      Assert.AreEqual(0, baseHealth.health);
   }

   [Test]
   //testing the full health of the LevelUpDog
   public void Take_Full_Health_LevelUp(){
      ZombieDog levelHealth = new BaseDog();
      ZombieDog dogTemp = new LevelUp();
      dogTemp.SetDog(levelHealth);
      levelHealth = dogTemp;
      levelHealth.TakeDamage(100f);
      Assert.AreNotEqual(0, levelHealth.health);
   }

    [Test]
   //Testing the take full health of baseDog
   public void Take_Full_Health_Boss(){
      Dog bossHealth = new BossDog();
      bossHealth.TakeDamage(100f);
      Assert.AreNotEqual(0, bossHealth.health);
   }

   //test the damage of the base dog vs the level up dog vs boss dog
   [Test]
   //Testing the take full damage of baseDog
   public void Take_Full_Damage_Base(){
      ZombieDog baseDamage = new BaseDog();
      baseDamage.TakeDamageTest(5f);
      Assert.AreEqual(0, baseDamage.damage);
   }

   [Test]
   //testing the take full damage of LevelUp Dog
   public void Take_Full_Damage_LevelUp(){
      ZombieDog levelDamage = new BaseDog();
      ZombieDog dogTemp = new LevelUp();
      dogTemp.SetDog(levelDamage);
      levelDamage = dogTemp;
      levelDamage.TakeDamageTest(5f);
      Assert.AreNotEqual(0, levelDamage.damage);
   }

   [Test]
   //Testing the take full damage of baseDog
   public void Take_Full_Damage_Boss(){
      Dog bossDamage = new BossDog();
      bossDamage.TakeDamageTest(5f);
      Assert.AreNotEqual(0, bossDamage.damage);
   }

   //test the speed of the base dog vs the level up dog vs boss dog
   [Test]
   //Testing the take full speed of baseDog
   public void Take_Full_Speed_Base(){
      ZombieDog baseSpeed = new BaseDog();
      baseSpeed.TakeSpeed(1.5f);
      Assert.AreEqual(0, baseSpeed.speed);
   }

   [Test]
   //testing the take full speed of LevelUp Dog
   public void Take_Full_Speed_LevelUp(){
      ZombieDog levelSpeed = new BaseDog();
      ZombieDog dogTemp = new LevelUp();
      dogTemp.SetDog(levelSpeed);
      levelSpeed = dogTemp;
      levelSpeed.TakeSpeed(1.5f);
      Assert.AreNotEqual(0, levelSpeed.speed);
   }

   [Test]
   //Testing the take full speed of bossDog
   public void Take_Full_Speed_Boss(){
      Dog bossSpeed = new BossDog();
      bossSpeed.TakeSpeed(1.5f);
      Assert.AreNotEqual(0, bossSpeed.speed);
   }
}
