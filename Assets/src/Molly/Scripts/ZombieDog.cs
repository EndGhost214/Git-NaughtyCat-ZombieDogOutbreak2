/*
 * ZombieDog.cs
 * Molly Meadows
 * Description: This is a child class script of Dog. This does all the animations of the zombie dog sprites and handles the collisions. It also includes the functionality
 * called from DogPool in order to set the stats of the dog when they are spawned into the scene.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Description: This class handles the initialization of the variables for each zombie dog sprite when they get spawned. 
 * There are also collision functions inside this class that handles when a sprite collides with a bullet or player prefab.
 *
 * Member Variables:
 * private Animator animate: sets the variables in the zombie dog sprite animator
 *  private CapsuleCollider2D mcollider
*/
public class ZombieDog : Dog, IDogP
{  
    //will hold the animation variables to be set
    private Animator animate;

    private CapsuleCollider2D mcollider;

    void Awake() {
        animate = gameObject.GetComponent<Animator>();
        mcollider = gameObject.GetComponent<CapsuleCollider2D>();
    }

    //called from DogPool
    public void OnObjectSpawn()
    {
        //enable the collider
        mcollider = gameObject.GetComponent<CapsuleCollider2D>();
        mcollider.enabled = true;
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
            TakeDamage((float) collision.gameObject.GetComponent<Bullet>().GetDamage());

            //if the health is at zero
            if(health<=0)
            {
                speed = 0;
                animate.Play("DeathAnim",  -1, 0f);
                animate.SetFloat("Speed", 0f);
                animate.SetBool("isAttack", false);
                //Debug.Log("here");
                //disables the collider so dogs can run past them
                
                mcollider.enabled = !mcollider.enabled;
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

