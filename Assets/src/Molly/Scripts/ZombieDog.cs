using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDog : Dog
{
    //serialized field for sound management class
    [SerializeField]
    private Rigidbody2D ZomDog;
    
    [SerializeField]
    private int health;

    //other variables
    private Vector3 pos;
    private int damage;
    private float speed;

    protected virtual void Awake(){
        damage = SetDamage();
        speed = SetSpeed();
        health = SetHealth();
    }

    protected virtual int SetDamage(){
        return based;
    }
    protected virtual int SetHealth(){
        return baseh;
    }
    protected virtual float SetSpeed(){
        return bases;
    }

    // default constructor
    public ZombieDog(){
        pos = new Vector3(0,0,0);
    }

    //constructor that takes inital spawn position
    public ZombieDog(Vector3 pos){
        this.pos = pos;
        //call dog noise sound from marissa's function
        SoundManager.Instance.ZombieSoundFunction();
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = pos;
        SoundManager.Instance.ZombieSoundFunction();
    }

    // Update is called once per frame
    void Update()
    {
        //BOUNDARY TEST: GO TO DOG SCRIPT TO SEE THE DEATH FUNCTION
        //HEALTH IS SERIALIZED FIELD SO THAT YOU CAN CHANGE HEALTH AT RUN TIME
        if(health==0){
            Death();    
        }
    }
    //if player walks into dog area, move
    void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("testing");
        if(collision.gameObject.tag == "Player"){
            Debug.Log("player is in dog zone");
        }
    }

    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){
            Debug.Log("player exited dog zone");
        }
    }

    //returns the dogs health
    public int GetHealth(){
        return health;
    }

    //sets the health of the dog
    public void SetHealth(int heal){
        health = heal;
    }

    //Deals Damage to the player
    //Decorator/depends on the level of the dog
    public void DealDamage(int damage){
        int temp = GetHealth() - damage;
        SetHealth(temp);
    }

    //temporary damage function
    public int TakeDamage(){
        health-=50;
        return health;
    }
}
