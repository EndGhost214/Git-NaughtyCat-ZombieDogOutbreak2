/*
 * BossDog.cs
 * Molly Meadows
 * Description: This class is a child of the Dog class. Its purpose is to set the stats of the boss dog and has the functions to be interactive with the players weapons.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Description: This is a child of the dog class. It handles the functionality of the boss dog sprite
 * 
 * Member Variables:
 * N/A (defined in other classes)
*/
public class BossDog : Dog
{
    // Start is called before the first frame update and sets the stats of the boss dog
    void Start()
    {
        //calls a sound when instantiated
        SoundManager.Instance.bossGrowlFunction();
        damage = 100f;
        health = 500f;
        speed = 3f;
    }

    //called on a fixed frame rate, if the health is less than or equal to zero, the object will call the death function
    void FixedUpdate()
    {
        if (health <= 0)
        {
            Death();
        }
    }

    /*
     * If the sprite collides with other prefabs 
     *
     * parameter of a collision type
     *
     * takes or deals damage based on what it has collided with
    */
    void OnCollisionEnter2D(Collision2D collision)
    {
        //if the collision was a bullet, it will reduce its health with whatever damage the bullet has
        if(collision.gameObject.tag == "Bullet")
        {
            TakeDamage((float) collision.gameObject.GetComponent<Bullet>().GetDamage());
            SoundManager.Instance.bossHurtFunction();
        }

        //if the collision is with the player, damage the player with the damage stat
        if(collision.gameObject.tag == "Player")
        {
            GameManager.Instance.getPlayer().DamagePlayer(damage);
            SoundManager.Instance.bossAttackFunction();
        }
    }

    //override the death method since it doesn't match the object pooler, destroys the prefab
    public override void Death()
    {   
        Debug.Log("The boss dog is dead");
        Destroy(gameObject);
    }

}

