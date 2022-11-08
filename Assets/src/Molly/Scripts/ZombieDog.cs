using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Pathfinding;

public class ZombieDog : Dog, IDogP
{  
    //will hold the position of the zombie dog
    private Vector3 pos;

    //will hold the animation variables to be set
    private Animator animate;

    // default constructor
    public ZombieDog()
	{
    }

    //constructor that takes inital spawn position
    public ZombieDog(Vector3 pos)
	{
        this.pos = pos;
    }

    void Awake() {
        animate = gameObject.GetComponent<Animator>();
    }

    // called from DogPool
    public void onObjectSpawn()
    {
        //initiate sound upon spawning
        SoundManager.Instance.zombieSoundFunction();
        //get the animator components in the object animate in order to set animations accordingly
        animate = gameObject.GetComponent<Animator>();

        //set the basic variables of the dogs
        damage = SetDamage();
        speed = SetSpeed();
        health = SetHealth();

        //debug statements to see values of dog
        Debug.Log("Damage: " + damage);
        Debug.Log("speed: " + speed);
        Debug.Log("health: " + health);

        //set the speed of the dog (will be dependent on the levelup class)
        animate.SetFloat("Speed", speed);
        animate.SetBool("isAttack", false);
        animate.SetFloat("Health", health);
    }

    //updates not based on frames
    void FixedUpdate()
    {
        //set the speed and the health
        animate.SetFloat("Health", health);

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
            if(health >= 0f)
            {
                animate.SetBool("isAttack", true);
            }
        }
        if(collision.gameObject.tag == "Bullet")
        {
            //hurt sound 
            SoundManager.Instance.zombieHurtFunction();
            //take the damage of the bullet
            TakeDamage((float) collision.gameObject.GetComponent<Bullet>().getDamage());

            //if the health is at zero
            if(health<=0)
            {
                speed = 0;
                animate.Play("DeathAnim",  -1, 0f);
                animate.SetFloat("Speed", 0f);
                animate.SetBool("isAttack", false);
                //Debug.Log("here");
                Invoke("Death", 1);
            }
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

