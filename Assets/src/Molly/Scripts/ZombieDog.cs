using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDog : Dog
{
    //serialized field for sound management class
    [SerializeField]
    private Rigidbody2D ZomDogRB;
    
    //other variables
    private Vector3 pos;
   
    // default constructor
    public ZombieDog()
	{
        
    }

    //constructor that takes inital spawn position
    public ZombieDog(Vector3 pos)
	{
        this.pos = pos;
        //call dog noise sound from marissa's function
        //SoundManager.Instance.ZombieSoundFunction();
    }

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = pos;
        SoundManager.Instance.zombieSoundFunction();
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

    void FixedUpdate(){
        //update animation and which way it is facing dependent on movement with A*
    }

    //if player walks into dog area, move
    void OnCollisionEnter2D(Collision2D collision)
	{
        Debug.Log("testing");
        if(collision.gameObject.tag == "Player"){
            Debug.Log("player is in dog zone");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
	{
        if(collision.gameObject.tag == "Player"){
            Debug.Log("player exited dog zone");
        }
    }

    //Deals Damage to the player
    //Decorator/depends on the level of the dog
    public void DealDamage(int damage)
	{
        health -= damage;
        
    }

    //temporary damage function
    public int TakeDamage()
	{
        health-=50;
        return health;
    }

    //set functions that don't do much
    protected virtual int SetDamage()
	{
        return damage;
    }
    protected virtual int SetHealth()
	{
        return health;
    }
    protected virtual float SetSpeed()
	{
        return speed;
    }
    public virtual void SetDog(ZombieDog dog)
	{
    }
}
