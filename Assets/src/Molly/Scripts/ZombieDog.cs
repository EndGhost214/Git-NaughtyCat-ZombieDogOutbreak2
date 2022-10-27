using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ZombieDog : Dog
{
    //serialized field for sound management class
    [SerializeField]
    private Rigidbody2D ZomDogRB;
    
    //other variables
    private Vector3 pos;
    private Animator animate;
    private AIPath aiPath;
   
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
        animate = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animate.SetFloat("Speed", speed);
        animate.SetInteger("Health", health);

        //if the dog is moving to the right, then flip it, visa versa for left
        /*if(aiPath.desiredVelocity.x >= 0.01f){
            transform.localScale = new Vector3(-1f,1f,1f);
        }else if (aiPath.desiredVelocity.x <= -0.01f){
            transform.localScale = new Vector3(1f,1f,1f);
        }
        */
        //if the dog is moving down/up, flip it accordingly

        //BOUNDARY TEST: GO TO DOG SCRIPT TO SEE THE DEATH FUNCTION
        //HEALTH IS SERIALIZED FIELD SO THAT YOU CAN CHANGE HEALTH AT RUN TIME
        if(health==0){
            Death();    
        }
    }

    //if player walks into dog area, move
    void OnCollisionEnter2D(Collision2D collision)
	{
        //Debug.Log("testing");
        if(collision.gameObject.tag == "Player"){
            Debug.Log("player is in dog zone");
            //set animate to bite
        }
        if(collision.gameObject.tag == "Bullet"){
            SetHealth(health-=5);
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
