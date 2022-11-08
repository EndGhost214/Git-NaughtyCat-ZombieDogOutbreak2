using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoShow : MonoBehaviour
{
    public GameObject videoPlayer;
    public GameObject game;

    public void ShowVideo()
    {
        game.SetActive(false);
        Time.timeScale = 0f;
        videoPlayer.SetActive(true);
    }

    public void HideVideo()
    {
        videoPlayer.SetActive(false);
        Time.timeScale = 1f;
        game.SetActive(true);
    }
}
