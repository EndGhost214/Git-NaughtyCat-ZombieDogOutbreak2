using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSpawner : MonoBehaviour
{
    void FixedUpdate(){
        //Debug.Log(gameObject.transform.position);
        if (Input.GetKeyDown(KeyCode.L))
        DogPool.Instance.SpawnFromDogPool("ZombieDog", gameObject.transform.position, Quaternion.identity);
    } 
}
