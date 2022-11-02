/*
 * pausemenu.cs
 * 
 * This script is for the pause menu. 
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool GamePaused = false;


    //access pause menu by space bar
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GamePaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    //enter pause screen
    public void pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;

    }


    //resume
    public void resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;

    }


    //restart game
    public void restartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    //exit the game
    public void exitGame()
    {
        Application.Quit();
    }
    
}
