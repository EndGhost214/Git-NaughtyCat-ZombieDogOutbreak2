/*
 * DogSpawner.cs
 * Molly Meadows
 * Description: Temporary Class to demonstrate the spawning of the zombie dogs.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DogSpawner : MonoBehaviour
{
[SerializeField]
private GameObject bossDog;

    void Start(){
        DogPool.Instance.SpawnFromDogPool("ZombieDog", gameObject.transform.position, Quaternion.identity);
        Instantiate(bossDog, gameObject.transform.position, Quaternion.identity);
    }
    void FixedUpdate(){
        //Debug.Log(gameObject.transform.position);
        if (Input.GetKeyDown(KeyCode.L))
        DogPool.Instance.SpawnFromDogPool("ZombieDog", gameObject.transform.position, Quaternion.identity);
    } 
}

