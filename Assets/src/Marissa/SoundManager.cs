using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : Singleton<SoundManager>{




private static SoundManager _instance;


public static SoundManager Instance
{
  
    get{

        return _instance;
    }
}
    [SerializeField]
    private AudioSource zombieSound1;
    //Player

    public void ZombieSoundFunction(){
        zombieSound1.Play();

    }


    //ZombieDog

    
    public override void Awake(){

        _instance=this;
    }

}

