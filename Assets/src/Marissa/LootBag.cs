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
*droppedItemPrefab - the prefab for the item that was dropped
*lootList - list that contains items
*
*
*/
public class LootBag : MonoBehaviour
{
    [SerializeField]
    public GameObject tuftPrefab;

    [SerializeField]
    public GameObject heartPrefab;

    [SerializeField]
    public GameObject bulletPrefab;
    //public List<Loot> lootList = new List<Loot>();


    /*
    *function to determine which item gets dropped
    *no parameter
    *drops the item
    */
    
    /*
    Loot GetDroppedItem()
    {
        //int randomNumber = Random.Range(1,101);

        

        /*
        List<Loot> possibleItems = new List<Loot>();

        foreach(Loot item in lootList)
        {
            if(randomNumber<=item.dropChance)
            {
                possibleItems.Add(item);
            }
        }

        if(possibleItems.Count >0)
        {
            Loot droppedItem= possibleItems[Random.Range(0,possibleItems.Count)];
            return droppedItem;
        }
            return null;
        }
        */
        
        /*
        *function to spawn the loot where the dog last was
        *spawn position parameter
        *spawns the item where the zomdog was
        */
        public void InstantiateLoot(Vector3 spawnPosition)
        {
            //Loot droppedItem = GetDroppedItem();
            
                int randomNumber = Random.Range(1,70);

                if(randomNumber>=1 && randomNumber<=45)
                {
                    GameObject lootGameObject = Instantiate(bulletPrefab,spawnPosition,Quaternion.identity);
                    
                }
                if(randomNumber>=46 && randomNumber<=50)
                {
                    GameObject lootGameObject = Instantiate(tuftPrefab,spawnPosition,Quaternion.identity);
                    
                }
                if(randomNumber>=51 && randomNumber<=61)
                {
                    GameObject lootGameObject = Instantiate(heartPrefab,spawnPosition,Quaternion.identity);
                    
                }


                //GameObject lootGameObject = Instantiate(droppedItemPrefab,spawnPosition,Quaternion.identity);
                //lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;
           
        }


    }
   

