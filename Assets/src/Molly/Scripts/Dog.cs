using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

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
        gameObject.GetComponent<LootBag>().InstantiateLoot(transform.position);
        //GetComponent<LootBag>().InstantiateLoot(transform.position);

        gameObject.SetActive(false);
        //call random item drop function 
            //Drop();
        //return a -1 to the list of dogs
    }

    //temporary damage function
    public float TakeDamage(float damage)
	{
        health-=damage;
        return health;
    }


}
