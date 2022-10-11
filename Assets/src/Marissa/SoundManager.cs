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
    
    //zombie exisiting sound
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

    //zombie hurt
    [SerializeField]
    private AudioSource zombieHurt1;

    [SerializeField]
    private AudioSource zombieHurt2;

    public void ZombieHurtFunction(){
        int play = Random.Range(1,10);
       
        if (play>3 && play<=10){
            zombieHurt2.Play();
        }
        else if(play==1 || play==2){
            zombieHurt1.Play();
        }
    }

    //Player
   
    //walking sound
    [SerializeField]
    private AudioSource catWalk;

    public void catWalkFunction(){

        catWalk.Play();

    }

    //Other

    
  
}

