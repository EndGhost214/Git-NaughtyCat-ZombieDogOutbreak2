using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoShow : MonoBehaviour
{
    public GameObject videoPlayer;
    public GameObject game;

    public void ShowVideo()
    {
        videoPlayer.SetActive(false);
        videoPlayer.SetActive(true);
    }

    public void HideVideo()
    {
        videoPlayer.SetActive(false);
        videoPlayer.SetActive(true);
    }
}
