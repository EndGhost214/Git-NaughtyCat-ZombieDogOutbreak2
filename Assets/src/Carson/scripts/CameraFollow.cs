using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.getPlayerObject();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, gameObject.transform.position.z);
    }
}