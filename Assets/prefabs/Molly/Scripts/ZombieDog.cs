using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDog : Dog
{
    //serialized field for sound management class
    [SerializeField]
    private 
    
    // default constructor
    public ZombieDog(){
        transform.position(0,0,0);
    }

    //constructor that takes inital spawn position
    public ZombieDog(Vector2 pos){
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
