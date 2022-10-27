using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

public class MSTestScript : MonoBehaviour
{
    [Test]

    public void checkZombieSoundFunction(){

        SoundManager.Instance.zombieSoundFunction();
        string check=SoundManager.Instance.GetrecentlyPlayed();
        
        int flag=0;

        if(check=="zombieSound1" || check=="zombieSound2" || check=="zombieSound3" || check=="NONE"){
          flag=1;  
        }
        Debug.Log(check);
        Assert.AreEqual(flag,1);
      
    }

     [Test]

    public void checkzombieHurtFunction(){

        SoundManager.Instance.ZombieHurtFunction();
        string check=SoundManager.Instance.GetrecentlyPlayed();
        
        int flag=0;

        if(check=="zombieHurt1" || check=="zombieHurt2"){
          flag=1;  
        }
        Debug.Log(check);
        Assert.AreEqual(flag,1);
      
    }






}

