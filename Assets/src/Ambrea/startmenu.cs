/*
 * startmenu.cs
 * 
 * This script is for the start menu. 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startmenu : MonoBehaviour
{
    //Starts the game
    public void PlayGame()
    {
        SceneManager.LoadScene(0);
    }

    //Exits the game
    public void QuitGame()
    {
        Application.Quit();
    }

}
