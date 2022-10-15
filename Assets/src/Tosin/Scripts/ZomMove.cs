using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomMove : MonoBehaviour
{
    //public ZomSpawn zomSpawn;
    private Rigidbody2D rb;
    public Collision2D collision;
    public Vector3 boundsPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
    }
    public void Bounce(Collision2D collision)
    {
        //Vector3 zomPosition = transform.position;
        boundsPosition = collision.transform.position;
        float positionX = Random.Range(-2.0f, 2.0f);
        float positionY = Random.Range(-2.0f, 2.0f);
        MoveZom(new Vector2(positionX, positionY));
    }
    public IEnumerator Launch()
    {
        yield return new WaitForSeconds(1);
    }
    public void MoveZom(Vector2 direction)
    {
        //direction = direction.normalized;
        float zomSpeed = 4;
        rb.velocity = direction * zomSpeed;
    }

    /*//detects collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bound1" || collision.gameObject.name == "Bound2" || collision.gameObject.name == "Bound3" || collision.gameObject.name == "Bound4")
        {
            //Bounce(collision);
        }
        rb.velocity = new Vector2(Random.Range(-25, 25), Random.Range(-20, 20));
    }
    */
}
