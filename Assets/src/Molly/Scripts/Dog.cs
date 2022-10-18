using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    //base variables for each zombie dog
    protected int baseh = 100;
    protected int based = 5;
    protected float bases = .5f;


    //remove the dog from the map
    public void Death(){
        Debug.Log("This Dog is dead");
        //Call Marissa's item drop function
        ItemFunctions.Instance.ItemDrop();
        Destroy(this.gameObject);
        //call random item drop function 
            //Drop();
        //return a -1 to the list of dogs
    }


}
