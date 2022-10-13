using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : Singleton<SoundManager>{

   

    //zombiedog--------------------------------------

    private string recentlyPlayed;

    public string GetrecentlyPlayed(){

        return recentlyPlayed;
    }




    [SerializeField]
    private AudioSource zombieSound1; //mc zombie

    [SerializeField]
    private AudioSource zombieSound2; //cod zombie

    [SerializeField]
    private AudioSource zombieSound3; //dog growl
    
    //zombie exisiting sound
    public void ZombieSoundFunction(){
        int play = Random.Range(1,100);
        
        if (play>=1 && play<=10){
            zombieSound1.Play();
            recentlyPlayed="zombieSound1";

        }
        else if(play>=11 && play<=20){
            zombieSound2.Play();
            recentlyPlayed="zombieSound2";
        }
        else if(play>=21 && play<=75){
            zombieSound3.Play();
            recentlyPlayed="zombieSound3";
        }
        else if(play>=76 && play<=100){
            //no sound
             recentlyPlayed="NONE";
        }
        
    }

    //zombie hurt sounds
    [SerializeField]
    private AudioSource zombieHurt1;  //mc zombie hurt

    [SerializeField]
    private AudioSource zombieHurt2; //puppy whine

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

    //zombie boss--------------------------------------




    //Player---------------------------------------------
   
   //meow

    [SerializeField]
    private AudioSource catMeow1;
    [SerializeField]
    private AudioSource catMeow2;

    public void catMeowFunction(){
        int play = Random.Range(1,2);
        if(play==1){
            catMeow1.Play();
        }
        else if(play==2){
            catMeow2.Play();
        }

    }


    //walking sound
    [SerializeField]
    private AudioSource catWalk;  //squidward walk

    public void catWalkFunction(){

        catWalk.Play();

    }

    



    //shoots
    [SerializeField]
    private AudioSource gunSound1;

    public void gunSoundFunction(){

        gunSound1.Play();
    }

    //slashes
    [SerializeField]
    private AudioSource knifeSlash;

    public void knifeSoundFunction(){

        knifeSlash.Play();
    }

    //gets hurt

    [SerializeField]
    private AudioSource catHurt1; //roblox oof
    [SerializeField]
    private AudioSource catHurt2; //cat hurt real
    [SerializeField]
    private AudioSource catHurt3; //cat hurt real
    
    public void catHurtSoundFunction(){

        int play = Random.Range(1,10);

        if(play==1){
            catHurt1.Play();
        }
        else if(play>=2 && play<=7){
            catHurt2.Play();
        }
        else if(play>=8 && play<=10){
            catHurt3.Play();
        }
    }

    //Other-----------------------------------------

    //background music


    //unlock door


    //create cure


    //sprinklers



  
}

