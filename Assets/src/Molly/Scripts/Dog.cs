using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    //remove the dog from the map
    public void Death(){
        Debug.Log("This Dog is dead");
        Destroy(this.gameObject);
        //call random item drop function 
            //Drop();
        //return a -1 to the list of dogs
    }
}
