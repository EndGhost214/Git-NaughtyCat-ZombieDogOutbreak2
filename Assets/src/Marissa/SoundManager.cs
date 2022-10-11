using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : Singleton<SoundManager>{

    //Random rnd=new Random();

    //zombiedog

    private string recentlyPlayed;

    public string GetrecentlyPlayed(){

        return recentlyPlayed;
    }




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
            recentlyPlayed="zombieSound1";

        }
        else if(play==2){
            zombieSound2.Play();
            recentlyPlayed="zombieSound2";
        }
        else if(play==3){
            zombieSound3.Play();
            recentlyPlayed="zombieSound3";
        }
        else if(play==4){
            //no sound
             recentlyPlayed="NONE";
        }
        
    }

    //zombie hurt sounds
    [SerializeField]
    private AudioSource zombieHurt1;

    [SerializeField]
    private AudioSource zombieHurt2;

    //determines what sound will be played
    public void ZombieHurtFunction(){
        int play = Random.Range(1,10);
       
        if (play>3 && play<=10){
            zombieHurt2.Play();
            recentlyPlayed="zombieHurt2";
        }
        else if(play==1 || play==2){
            zombieHurt1.Play();
            recentlyPlayed="zombieHurt1";
        }
    }

    //Player
   
   //meow

    [SerializeField]
    private AudioSource catMeow1;

    public void catMeowFunction(){

        catMeow1.Play();

    }


    //walking sound
    [SerializeField]
    private AudioSource catWalk;

    public void catWalkFunction(){

        catWalk.Play();

    }

    //random cat sounds while existing




    //Other

    
  
}

