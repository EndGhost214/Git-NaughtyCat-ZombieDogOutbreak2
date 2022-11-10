/*
 * DemoShow.cs
 * Molly Meadows
 * Description: This is the script to show and hide the demo mode when the player is idling in the game.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Description: Shows and hides the demo video when the user is idling for 60 seconds 
 * 
 * Member Variables:
 * public GameObject videoPlayer: a gameobject type of video to be played while player is idling
 * public GameObject game: a GameObject type that the hud will dissappear or show dependent upon the video being played or not
*/
public class DemoShow : MonoBehaviour
{
    public GameObject videoPlayer;
    public GameObject game;

    //Hides the HUD, pauses the game, and plays the video
    public void ShowVideo()
    {
        game.SetActive(false);
        Time.timeScale = 0f;
        videoPlayer.SetActive(true);
    }

    //Hides the video, unpauses the game and unhides the HUD
    public void HideVideo()
    {
        videoPlayer.SetActive(false);
        Time.timeScale = 1f;
        game.SetActive(true);
    }
}

