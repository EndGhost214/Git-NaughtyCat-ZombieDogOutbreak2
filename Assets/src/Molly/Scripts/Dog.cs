/*
 * Dog.cs
 * Molly Meadows
 * Description: This is the parent class of ZombieDog and BossDog. 
 * This is where the stats are declared and both of the children share a death function and TakeDamage function.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Description: This class handles the common functions death and take damage of the enemy sprites. 
 * Contains the health damage speed variables that will be set in child classes.
 * 
 * Member Variables:
 * public float health: sets the health of the zombie dog based on the round
 * public float damage: sets the damage of the zombie dog based on the round
 * public float speed: sets the speed of the zombie dog based on the round
 *
*/
public class Dog : MonoBehaviour
{
    //variables 
    public float health;
    public float damage;
    public float speed;

    private UpgradedLootBag bag;

    //Set the ZombieDog Sprite as inactive in the hierarchy. 
    public virtual void Death()
    {
        //Debug.Log("This Dog is dead");
        if(gameObject.activeInHierarchy==true)
        {
            bag = new LootBag();
            //calls the drop item function
            //gameObject.GetComponent<LootBag>().InstantiateLoot(transform.position);
            bag.InstantiateLoot(gameObject.transform.position);
        }
        
        gameObject.SetActive(false);
    }

    /*
     * reduces health of sprite by the amount in the bullet prefab
     *
     * paramater is a float of how much damage is being taken
     *
     * returns the new damaged health
    */
    public virtual float TakeDamage(float damage)
	{
        health-=damage;
        return health;
    }
}

