/*
*SoundManager.cs
*Marissa Samayoa
*to manage the sounds and make accessible to other developers
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : Singleton<SoundManager>
{

   

    //zombiedog--------------------------------------

    private string recentlyPlayed;
    //for testing if the sound was played - boundary test
    void GetrecentlyPlayed()
    {

        Debug.Log(recentlyPlayed);
    }

    
    float nextTime=0;
    void FixedUpdate()
    {
        
        
        if(Time.time>=nextTime)
        {   
            Debug.Log(recentlyPlayed);
            nextTime=Time.time +3f;
        }
    }
    
    [SerializeField]
    private AudioSource zombieSound1; //mc zombie

    [SerializeField]
    private AudioSource zombieSound2; //cod zombie

    [SerializeField]
    private AudioSource zombieSound3; //dog growl
    
    //zombie exisiting sound

    /*
    *function to play zombie exisiting sounds
    *no parameter
    *generates a random number between 1-100 which determines which zombie sound will be played
    */
    public void zombieSoundFunction()
    {
        int play = Random.Range(1,100);
        
        if (play>=1 && play<=10)
        {
            zombieSound1.Play();
            recentlyPlayed="zombieSound1";
            //Debug.Log("zombieSound1");
        }
        else if(play>=11 && play<=20)
        {
            zombieSound2.Play();
            recentlyPlayed="zombieSound2";
        }
        else if(play>=21 && play<=75)
        {
            zombieSound3.Play();
            recentlyPlayed="zombieSound3";
        }
        else if(play>=76 && play<=100)
        {
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
     
    /*
    *function to play zombie hurt sounds
    *no parameter
    *generates a random number between 1-10 which determines which zombie sound will be played
    */
    public void zombieHurtFunction()
    {
        int play = Random.Range(1,10);
       
        if (play>3 && play<=10)
        {
            zombieHurt2.Play();
            recentlyPlayed="zombieHurt2";
        }
        else if(play==1 || play==2)
        {
            zombieHurt1.Play();
            recentlyPlayed="zombieHurt1";
        }
    }


    //zombie boss--------------------------------------

    //growl
    [SerializeField]
    private AudioSource bossGrowl;

     /*
    *function to play boss growl sound
    *no parameter
    *plays the sound
    */
    public void bossGrowlFunction()
    {
        bossGrowl.Play();
        recentlyPlayed="bossGrowl";
    }


    //attack
    [SerializeField]
    private AudioSource bossAttack;

     /*
    *function to play boss attack sound
    *no parameter
    *plays the sound
    */
    public void bossAttackFunction()
    {
        bossAttack.Play();
        recentlyPlayed="bossAttack";
    }


    //hurt
    [SerializeField]
    private AudioSource bossHurt;

     /*
    *function to play boss hurt sound
    *no parameter
    *plays the sound
    */
    public void bossHurtFunction()
    {
        bossHurt.Play();
        recentlyPlayed="bossHurt";
    }


    //Player---------------------------------------------
   
   //meow

    [SerializeField]
    private AudioSource catMeow1;
    [SerializeField]
    private AudioSource catMeow2;

     /*
    *function to play cat meow sounds
    *no parameter
    *generates a random number between 1-2 which determines which cat sound will be played
    */
    public void catMeowFunction()
    {
        int play = Random.Range(1,2);
        if(play==1)
        {
            catMeow1.Play();
            recentlyPlayed="catMeow1";
        }
        else if(play==2)
        {
            catMeow2.Play();
            recentlyPlayed="catMeow2";
        }

    }


    //pick item up
    [SerializeField]
    private AudioSource pickUp;

     /*
    *function to play cat pickup sound
    *no parameter
    *plays the sound
    */
    public void pickUpFunction()
    {
        pickUp.Play();
        recentlyPlayed="pickUp";
    }


    //walking sound
    [SerializeField]
    private AudioSource catWalk;  //squidward walk

     /*
    *function to play cat walk sound
    *no parameter
    *plays the sound
    */
    public void catWalkFunction()
    {

        catWalk.Play();
        recentlyPlayed="catWalk";

    }

    
    //shoots
    [SerializeField]
    private AudioSource gunSound1;

    [SerializeField]
    private AudioClip gunClip;

     /*
    *function to play cat gun sound
    *no parameter
    *plays the sound
    */
    public void gunSoundFunction(){

        
        gunSound1.PlayOneShot(gunClip, 0.7F);
        recentlyPlayed="gunClip";
        //Debug.Log("gunClip");
    }

    [SerializeField]
    private AudioSource gunReload;

    /*
    *function to play cat gun reload sound
    *no parameter
    *plays the sound
    */
    public void gunReloadSoundFunction(){

        gunReload.Play();
        recentlyPlayed="gunReload";
    }

    [SerializeField]
    private AudioSource gunEmpty;

    /*
    *function to play cat gun empty sound
    *no parameter
    *plays the sound
    */
    public void gunEmptySoundFunction(){

        gunEmpty.Play();
        recentlyPlayed="gunEmpty";
    }



    //slashes
    [SerializeField]
    private AudioSource knifeSlash;

     /*
    *function to play cat knife sound
    *no parameter
    *plays the sound
    */
    public void knifeSoundFunction(){

        knifeSlash.Play();
        recentlyPlayed="knifeSlash";
    }


    //gets hurt

    [SerializeField]
    private AudioSource catHurt1; //roblox oof
    [SerializeField]
    private AudioSource catHurt2; //cat hurt real
    [SerializeField]
    private AudioSource catHurt3; //cat hurt real
    
     /*
    *function to play cat hurt sounds
    *no parameter
    *generates a random number between 1-10 which determines which cat sound will be played
    */
    public void catHurtSoundFunction(){

        int play = Random.Range(1,10);

        if(play==1){
            catHurt1.Play();
            recentlyPlayed="catHurt1";
        }
        else if(play>=2 && play<=7){
            catHurt2.Play();
            recentlyPlayed="catHurt2";
        }
        else if(play>=8 && play<=10){
            catHurt3.Play();
            recentlyPlayed="catHurt3";
        }
    }


    //Other-----------------------------------------

    //background music


    //unlock door

    [SerializeField]
    private AudioSource unlockDoor;

     /*
    *function to play cat unlock sound
    *no parameter
    *plays the sound
    */
    public void unlockDoorFunction(){
        unlockDoor.Play();
        recentlyPlayed="unlockDoor";
    }


    //create cure

    [SerializeField]
    private AudioSource createCure;

     /*
    *function to play create cure sound
    *no parameter
    *plays the sound
    */
    public void createCureFunction(){
        createCure.Play();
        recentlyPlayed="createCure";
    }


    //sprinklers
    [SerializeField]
    private AudioSource playSprinkler;

     /*
    *function to play sprinkler sound
    *no parameter
    *plays the sound
    */
    public void playSprinklerFunction(){
        playSprinkler.Play();
        recentlyPlayed="playSprinkler";
    }


}

