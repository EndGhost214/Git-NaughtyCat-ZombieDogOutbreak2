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


    private bool isAttacking = false;
   
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

        
        animate.SetBool("isAttack", isAttacking);
        //set the speed of the dog (will be dependent on the levelup class)
        animate.SetFloat("Speed", speed);
    }

    // Update is called once per frame
    void Update()
    {
        /*Vector2 moveDirection = gameObject.GetComponent<Rigidbody2D>().velocity;
         if (moveDirection != Vector2.zero) 
         {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
         }*/
        
        //retrieves the coordinates of the direction the zombie dog is moving
        /*float horizontal = Player.transform.position.x;
        float vertical = Player.transform.position.y;
        float rotationSpeed = 720f;

        Vector2 moveDirection = new Vector2(horizontal,vertical);
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        if (moveDirection != Vector2.zero) 
         {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
         }
*/

    }

    
    void FixedUpdate()
    {
        //set the speed and the health
        
        animate.SetInteger("Health", health);
        
        

        //BOUNDARY TEST: GO TO DOG SCRIPT TO SEE THE DEATH FUNCTION
        //HEALTH IS SERIALIZED FIELD SO THAT YOU CAN CHANGE HEALTH AT RUN TIME
        if(health==0){
            //animate.SetInteger("Health", health);
            //gameObject.GetComponent<Animation>()["DeathAnim"].wrapMode = WrapMode.Once;
            //gameObject.GetComponent<Animation>().Play("DeathAnim");
            //animate.Play("DeathAnim");
            //Debug.Log("here");
            Death();
        }
        

    }

    //if player walks into dog area, move
    void OnCollisionEnter2D(Collision2D collision)
	{
        //Debug.Log("testing");
        if(collision.gameObject.tag == "Player"){
            isAttacking = true;
            Debug.Log("player is in dog zone");
            animate.SetBool("isAttack", isAttacking);
        }
        if(collision.gameObject.tag == "Bullet"){
            TakeDamage((int) collision.gameObject.GetComponent<Bullet>().getDamage());
        }
    }

    void OnCollisionExit2D(Collision2D collision)
	{  
        
        if(collision.gameObject.tag == "Player"){
            isAttacking = false;
            Debug.Log("player exited dog zone");
            animate.SetBool("isAttack", isAttacking);
        }
    }

    //Deals Damage to the player
    //Decorator/depends on the level of the dog
    public void DealDamage(int damage)
	{
        health -= damage;
        
    }

    //temporary damage function
    public int TakeDamage(int damage)
	{
        health-=damage;
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

