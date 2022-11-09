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
*itemPooler - stores the item pools
*/
public class LootBag : MonoBehaviour
{
    

    //to be able to store the pool
    ItemPooler itemPooler;

        /*
        *function to spawn the loot where the dog last was
        *spawn position parameter
        *spawns the item where the zomdog was
        */
        public void InstantiateLoot(Vector3 spawnPosition)
        {
            
                //picks a number 1-70
                int randomNumber = Random.Range(1,71);

                if(randomNumber>=1 && randomNumber<=45)
                {
                    //spawns the bullet from the item pool
                    ItemPooler.Instance.spawnFromPool("Bullet", transform.position, Quaternion.identity);
                }
                if(randomNumber>=46 && randomNumber<=50)
                {
                    //spawns the tuft from the item pool
                    ItemPooler.Instance.spawnFromPool("Tuft", transform.position, Quaternion.identity);
                }
                if(randomNumber>=51 && randomNumber<=61)
                {
                    //spawns the heart from the item pool
                    ItemPooler.Instance.spawnFromPool("Heart", transform.position, Quaternion.identity);
                }


               
        }


    }
   

