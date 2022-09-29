using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDog : Dog
{
    //serialized field for sound management class
    [SerializeField]
    private GameObject ZomDog;
    //[SerializeField]
    //private SoundManager sounds;

    //other variables
    /*
    private int health;
    private int speed;
    */
    
    // default constructor
    public ZombieDog(){
        transform.position = new Vector3(0,0,0);
    }

    //constructor that takes inital spawn position
    public ZombieDog(Vector3 pos){
        transform.position = pos;
        //call dog noise sound from marissa's function
        SoundManager.Instance.ZombieSoundFunction();
    }

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.ZombieSoundFunction();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //if player walks into dog area, move
    void OnTriggerEnter2D(Collider2D collision){
        Debug.Log("testing");
        if(collision.gameObject.tag == "Player"){
            Debug.Log("player is in dog zone");
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            Debug.Log("player exited dog zone");
        }
    }
}
