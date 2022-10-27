using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    //variables 
    public int health = 100;
    public int damage;
    public float speed;

    //remove the dog from the map
    public void Death(){
        Debug.Log("This Dog is dead");
        //Call Marissa's item drop function
        //ItemFunctions.Instance.ItemDrop();

        GetComponent<LootBag>().InstantiateLoot(transform.position);

        Destroy(this.gameObject);
        //call random item drop function 
            //Drop();
        //return a -1 to the list of dogs
    }


}
