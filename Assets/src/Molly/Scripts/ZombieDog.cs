using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Pathfinding;

public class ZombieDog : Dog
{
    
    //will hold the position of the zombie dog
    private Vector3 pos;

    //will hold the animation variables to be set
    private Animator animate;


    //public bool isAttacking = false;
   
    // default constructor
    public ZombieDog()
	{
    }

    //constructor that takes inital spawn position
    public ZombieDog(Vector3 pos)
	{
        this.pos = pos;
    }

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = pos;

        //initiate sound upon spawning
        SoundManager.Instance.zombieSoundFunction();
        //get the animator components in the object animate in order to set animations accordingly
        animate = gameObject.GetComponent<Animator>();

        //make sure that 
        animate.SetBool("isAttack", false);

        //set the basic variables of the dogs
        damage = SetDamage();
        speed = SetSpeed();
        health = SetHealth();

        //set the speed of the dog (will be dependent on the levelup class)
        animate.SetFloat("Speed", speed);
    }

    //updates not based on frames
    void FixedUpdate()
    {
        //set the speed and the health
        animate.SetFloat("Health", health);
        
        //BOUNDARY TEST: GO TO DOG SCRIPT TO SEE THE DEATH FUNCTION
        //HEALTH IS SERIALIZED FIELD SO THAT YOU CAN CHANGE HEALTH AT RUN TIME
        if(health<=0)
        {
            speed = 0;
            //animate.Setfloateger("Health", health);
            //gameObject.GetComponent<Animation>()["DeathAnim"].wrapMode = WrapMode.Once;
            //gameObject.GetComponent<Animation>().Play("DeathAnim");
            animate.Play("DeathAnim",  -1, 0f);
            animate.SetFloat("Speed", 0f);
            animate.SetBool("isAttack", false);
            //Debug.Log("here");
            Invoke("Death", 1);
        }
        
        //Debug.Log("Health: " + health + " Speed: " + speed + " Damage: " + damage);
    }

    //if player walks floato dog area, move
    void OnCollisionEnter2D(Collision2D collision)
	{
        //Debug.Log("testing");
        if(collision.gameObject.tag == "Player")
        {
            //isAttacking = true;
            Debug.Log("player is in dog zone");
            Debug.Log("health = " + health);
            GameManager.Instance.getPlayer().DamagePlayer(damage);
            //collision.gameObject.GetComponent<Player>().DamagePlayer(damage);
            if(health >= 0)
            {
                animate.SetBool("isAttack", true);
            }
        }
        if(collision.gameObject.tag == "Bullet")
        {
            TakeDamage((float) collision.gameObject.GetComponent<Bullet>().getDamage());
        }
    }

    void OnCollisionExit2D(Collision2D collision)
	{  
        
        if(collision.gameObject.tag == "Player")
        {
            //isAttacking = false;
            Debug.Log("player exited dog zone");
            animate.SetBool("isAttack", false);
        }
    }

    //Deals Damage to the player
    //Decorator/depends on the level of the dog
    public void DealDamage(float damage)
	{
        health -= damage;     
    }

    //set functions that don't do much
    protected virtual float SetDamage()
	{
        return damage;
    }
    protected virtual float SetHealth()
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

