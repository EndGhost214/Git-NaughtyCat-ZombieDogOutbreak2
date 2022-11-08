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
        time.TimeScale = 0f;
        videoPlayer.SetActive(true);
    }

    public void HideVideo()
    {
        videoPlayer.SetActive(false);
        time.TimeScale = 1f;
        game.SetActive(true);
    }
}
