using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFunctions : MonoBehaviour
{
    
    public GameObject bulletModel;
    public Transform transform;


    public void dropItem(){

        Vector3 position = transform.position; //position of enemy
        //GameObject bullets = Instantiate(bulletModel,position,Quarternion.identity); //bullet drop
        //bullets.SetActive(true);
    }

   

}
