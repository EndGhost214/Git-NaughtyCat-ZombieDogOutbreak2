
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "heartdrop")
        {
            invHeart = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "tuftdrop")
        {
            invTuft = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "cure")
        {
            invCure = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "serum")
        {
            invSerum = true;
            Destroy(collision.gameObject);
        }
    }
}
