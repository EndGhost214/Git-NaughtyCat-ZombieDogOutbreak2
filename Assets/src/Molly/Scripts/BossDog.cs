using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDog : Dog
{
    // Start is called before the first frame update
    void Start()
    {
        damage = 100f;
        health = 500f;
        speed = 10f;
    }

    //called on a fixed frame rate
    void FixedUpdate()
    {
        if (health <= 0)
        {
            Death();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamage((float) collision.gameObject.GetComponent<Bullet>().getDamage());
    }

    //override the death method since it doesn't match the object pooler
    public override void Death()
    {
        Destroy(this);
    }

}
