using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradedLootBag : MonoBehaviour
{
    

    //to be able to store the pool
    ItemPooler itemPooler;

        /*
        *function to spawn the loot where the dog last was
        *spawn position parameter
        *spawns the item where the zomdog was
        */
        public virtual void InstantiateLoot(Vector3 spawnPosition)
        {
            
              
            //spawns the each of the items from the item pool
            ItemPooler.Instance.spawnFromPool("Bullet", spawnPosition, Quaternion.identity);
            ItemPooler.Instance.spawnFromPool("Heart", spawnPosition, Quaternion.identity);    
            ItemPooler.Instance.spawnFromPool("Tuft", spawnPosition, Quaternion.identity);
               
        }


    }