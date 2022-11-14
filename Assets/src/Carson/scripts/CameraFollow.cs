/*
 * CameraFollow.cs
 * Carson Sloan
 * Control the camera position to keep the player on screen.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Class to control the main game camera to ensure it follows the player object.
 *
 * PUBLIC PROPERTIES:
 * moving - set by Tosin's cutscene to disable this script while the camera must be repositioned
 *
 * PRIVATE PROPERTIES:
 * player - player GameObject provided by GameManager for the camera to follow
 */
public class CameraFollow : MonoBehaviour
{
	public bool moving = false;
	
	private GameObject player;

    /*
	 * Start is called before the first frame update by Unity.
	 */
    public void Start()
    {
        player = GameManager.Instance.getPlayerObject();
    }

    /*
	 * Update is called once per frame by Unity.
	 */
    public void Update()
    {
		// As long as a cutscene doesn't need to move the camera, set the camera position to the player position
		if (!moving)
		{
			gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, gameObject.transform.position.z);
		}
    }
}

