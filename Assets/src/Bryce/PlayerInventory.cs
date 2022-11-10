
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private bool invHeart = false;
    private bool invTuft = false;
    private bool invCure = false;
    private bool invSerum = false;

    public bool hasHeart()
    {
        return invHeart;
    }

    public bool hasTuft()
    {
        return invTuft;
    }

    public bool hasCure()
    {
        return invCure;
    }

    public bool hasSerum()
    {
        return invSerum;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "heartdrop")
        {
            invHeart = true;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "tuftdrop")
        {
            invTuft = true;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "cure")
        {
            invCure = true;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "serum")
        {
            invSerum = true;
            other.gameObject.SetActive(false);
        }
    }
}
