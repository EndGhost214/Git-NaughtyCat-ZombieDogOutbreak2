
using UnityEngine;

public class PlayerInvintory : MonoBehaviour
{
    private bool invHeart = false;
    private bool invTuft = false;

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
    }
}
