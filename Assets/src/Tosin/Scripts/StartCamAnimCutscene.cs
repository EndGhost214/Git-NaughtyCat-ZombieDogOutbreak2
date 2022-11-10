/*
 * StartCamAnimCutscene.cs
 * Tosin Bangudu
 * Starts Camera Paning animation
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCamAnimCutscene : MonoBehaviour
{
    private Animator _animator;

    private void FindGameObjects()
    {
        _animator = GetComponent<Animator>(); //gets the animator for that object
    }
    //plays animation
    private void PlayAnim()
    {
        _animator.SetTrigger("OnPlayerTrigger"); //sets the trigger
        return;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //to show collision has happened
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("heyyy");
            PlayAnim();
        }
        //to remove trigger object
        if(collision.gameObject.tag == "TriggerCutScene1")
        {
            collision.gameObject.SetActive(false);
        }
        Time.timeScale = 0f;
    }
}
