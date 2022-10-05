using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
    // Update is called once per frame
    void Update()
    {
        //to skip cutscene
        if (Input.GetKeyDown("k"))
        {
            SceneManager.LoadScene(1); //an example scene ID
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}
