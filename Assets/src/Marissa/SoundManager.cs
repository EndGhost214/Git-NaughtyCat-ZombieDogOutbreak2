using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : Singleton<SoundManager>{





    [SerializeField]
    private AudioSource zombieSound1;
    //Player

    public void ZombieSoundFunction(){
        zombieSound1.Play();

    }


    //ZombieDog

    
  
}

