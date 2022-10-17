using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{


    [SerializeField]
    private float walkspeed = 5f;

    private Rigidbody2D body;

    [SerializeField]
    private GameObject playerObject;



   protected virtual GameObject GetPlayerObject()
    {
        return GameObject.Find("Player");
    }


    protected virtual void Awake()
    {
        playerObject = GetPlayerObject();
        body = playerObject.GetComponent<Rigidbody2D>();
        

    }


    private void FixedUpdate()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float VerticalalInput = Input.GetAxis("Vertical");


        //Flip player when moving left and right
        if (horizontalInput > 0.01f)
        {
            playerObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontalInput < -0.01f)
        {
            playerObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        body.velocity = new Vector2(horizontalInput * walkspeed, VerticalalInput * walkspeed);

    }



    // Start is called before the first frame update
    void Start()
    {
        playerObject.transform.position = new Vector3(0, 0, 0);
    }


}
