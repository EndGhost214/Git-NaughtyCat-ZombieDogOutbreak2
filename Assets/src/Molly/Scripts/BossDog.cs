using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossDog : Dog
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.bossGrowlFunction();
        damage = 100f;
        health = 500f;
        speed = 5f;
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
        if(collision.gameObject.tag == "Bullet")
        {
            TakeDamage((float) collision.gameObject.GetComponent<Bullet>().GetDamage());
            SoundManager.Instance.bossHurtFunction();
        }
        if(collision.gameObject.tag == "Player")
        {
            GameManager.Instance.getPlayer().DamagePlayer(damage);
            SoundManager.Instance.bossAttackFunction();
        }
    }

    //override the death method since it doesn't match the object pooler
    public override void Death()
    {   
        Debug.Log("The boss dog is dead");
        Destroy(this);
    }

}

