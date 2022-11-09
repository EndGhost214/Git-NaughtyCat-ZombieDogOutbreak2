using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dog : MonoBehaviour
{
    //variables 
    public float health;
    public float damage;
    public float speed;

    //remove the dog from the map
    public virtual void Death()
    {
        Debug.Log("This Dog is dead");
        //Call Marissa's item drop function
        //ItemFunctions.Instance.ItemDrop();
        if(gameObject.activeInHierarchy==true)
        {
            gameObject.GetComponent<LootBag>().InstantiateLoot(transform.position);
        }
        
        gameObject.SetActive(false);
    }

    //temporary damage function
    public virtual float TakeDamage(float damage)
	{
        health-=damage;
        return health;
    }
}

