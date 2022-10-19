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

    Vector2 movement;
    //Vector2 mousePos;

    //public Camera cam;

    


   protected virtual GameObject GetPlayerObject()
    {
        return GameObject.Find("Player");
    }


    protected virtual void Awake()
    {
        playerObject = GetPlayerObject();
        body = playerObject.GetComponent<Rigidbody2D>();
        

    }


    private void Update()
    {
        
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        //Flip player when moving left and right
        /*
        if (movement.x > 0.01f)
        {
            playerObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movement.x < -0.01f)
        {
            playerObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        */

    }

    private void FixedUpdate()
    {
       //Player vertical and horizontal movement
        body.MovePosition(body.position + movement * walkspeed * Time.fixedDeltaTime);

       // Vector2 lookDir = mousePos - body.position;

        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        //body.rotation = angle;

    }



    // Start is called before the first frame update
    void Start()
    {
        playerObject.transform.position = new Vector3(0, 0, 0);
    }


}
