/*
 * Player.cs
 * Bryce Hendrickson
 * Movement script for all players
 */
using UnityEngine;


/*
 * Player movement script for all players
 * 
 * Member variables:
 * walkSpeed -walk speed of the player
 * body - rigidbody of the player
 * playerOject - object of the player
 * movement - x and y values for the players movement
 * random - random number 1-100 for player meow sound
 */
public class Player : MonoBehaviour
{

    [SerializeField]
    private float walkSpeed = 5f;
    private Rigidbody2D body;

    [SerializeField]
    private GameObject playerObject;
    private Vector2 movement;

    private int random;

    //Awake function called when the gameobject is first spawned
    protected virtual void Awake()
    {
        playerObject = GetPlayerObject();
        body = playerObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        body.MovePosition(body.position + movement * walkSpeed * Time.fixedDeltaTime);

        random = Random.Range(0, 100);
        if(random >= 90)
        {
            SoundManager.Instance.catMeowFunction();
        }

    }

    protected virtual GameObject GetPlayerObject()
    {
        return GameObject.Find("Player");
    }

}
