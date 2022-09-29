using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDogClass : DogClass
{
    
    // default constructor
    public ZombieDogClass(){

    }

    //constructor that takes inital spawn position
    public ZombieDogClass(Vector2 pos){
        transform.position = pos;
        //call dog noise sound from marissa's function
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
