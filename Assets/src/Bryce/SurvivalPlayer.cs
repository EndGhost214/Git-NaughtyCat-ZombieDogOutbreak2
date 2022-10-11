using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalPlayer : Player
{

    [SerializeField]
    private float walkspeed = 5f;
   
    [SerializeField]
    private GameObject SrvPlayer;

    private Rigidbody2D body;
    
    private class Health
    {
        private uint healthActual;

        public Health()
        {

        }

        public Health(uint h)
        {
            healthActual = h;
        }

        public uint GetHealth()
        {
            return healthActual;
        }

        public void SetHealth(uint h)
        {
            healthActual = h;
        }
        public void DamagePlayer(uint damage)
        {
            uint newHealth = GetHealth() - damage;
            SetHealth(newHealth);

        }



    }


    private void Awake()
    {
        body = SrvPlayer.GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float VerticalalInput = Input.GetAxis("Vertical");


        //Flip player when moving left and right
        if (horizontalInput > 0.01f)
        {
            SrvPlayer.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontalInput < -0.01f)
        {
            SrvPlayer.transform.localScale = new Vector3(-1, 1, 1);
        }
        body.velocity = new Vector2(horizontalInput * walkspeed, VerticalalInput * walkspeed);

    }

    public SurvivalPlayer()
    {
       // transform.position = new Vector3(0, 0, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        SrvPlayer.transform.position = new Vector3(0, 0, 0);
    }


}
