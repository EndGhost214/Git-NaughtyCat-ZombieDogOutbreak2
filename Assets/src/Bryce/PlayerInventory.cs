/*
 * PlayerInventory.cs
 * Bryce Hendrickson
 * Player invintory script attached to all player prefabs
 */
using UnityEngine;

/*
 * Handles player invintory 
 * 
 * member variables:
 * invHeart
 * invTuft
 * invCure
 * invSerum
 * hasHeart()
 * hasTuft()
 * hasCure()
 * hasSerum()
 * OnTriggerEnter2D(Collider2D other)
 */
public class PlayerInventory : MonoBehaviour
{
    private bool invHeart = false;
    private bool invTuft = false;
    private bool invCure = false;
    private bool invSerum = false;

    //returns if the player has a heart in their invintory
    public bool hasHeart()
    {
        return invHeart;
    }

    //returns if the player has a tuft in their invintory
    public bool hasTuft()
    {
        return invTuft;
    }

    //returns if the player has a cure in their invintory
    public bool hasCure()
    {
        return invCure;
    }

    //returns if the player has a serum in their invintory
    public bool hasSerum()
    {
        return invSerum;
    }

    //OnTrigger allows the player to pick up objects and plays the pickup sound when an object is picked up
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "heartdrop")
        {
            SoundManager.Instance.pickUpFunction();
            invHeart = true;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "tuftdrop")
        {
            SoundManager.Instance.pickUpFunction();
            invTuft = true;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "cure")
        {
            SoundManager.Instance.pickUpFunction();
            invCure = true;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "serum")
        {
            SoundManager.Instance.pickUpFunction();
            invSerum = true;
            other.gameObject.SetActive(false);
        }
    }
}
