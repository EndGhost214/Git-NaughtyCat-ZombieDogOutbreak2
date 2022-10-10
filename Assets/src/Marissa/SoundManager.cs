using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : Singleton<SoundManager>{

    //Random rnd=new Random();

    //zombiedog

    [SerializeField]
    private AudioSource zombieSound1;

    [SerializeField]
    private AudioSource zombieSound2;

    [SerializeField]
    private AudioSource zombieSound3;
    

    public void ZombieSoundFunction(){
        int play = Random.Range(1,4);
        
        if (play==1){
            zombieSound1.Play();
        }
        else if(play==2){
            zombieSound2.Play();
        }
        else if(play==3){
            zombieSound3.Play();
        }
        else if(play==4){
            //no sound
        }
    }


    //Player


    //Other

    
  
}

