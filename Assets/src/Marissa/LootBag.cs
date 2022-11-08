/*
*LootBag.cs
*Marissa Samayoa
*randomizes which item will be dropped
*/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
*class that contains the items and their ability to drop
*member variables:
*tuftPrefab - prefab for tuft item
*heartPrefab - prefab for heart item
*bulletPrefab - prefab for bullet item
*/
public class LootBag : MonoBehaviour
{
    [SerializeField]
    public GameObject tuftPrefab;

    [SerializeField]
    public GameObject heartPrefab;

    [SerializeField]
    public GameObject bulletPrefab;
    

        /*
        *function to spawn the loot where the dog last was
        *spawn position parameter
        *spawns the item where the zomdog was
        */
        public void InstantiateLoot(Vector3 spawnPosition)
        {
            
            
                int randomNumber = Random.Range(1,70);

                if(randomNumber>=1 && randomNumber<=45)
                {
                    Instantiate(bulletPrefab,spawnPosition,Quaternion.identity);
                    
                }
                if(randomNumber>=46 && randomNumber<=50)
                {
                    Instantiate(tuftPrefab,spawnPosition,Quaternion.identity);
                    
                }
                if(randomNumber>=51 && randomNumber<=61)
                {
                    Instantiate(heartPrefab,spawnPosition,Quaternion.identity);
                    
                }


               
        }


    }
   

