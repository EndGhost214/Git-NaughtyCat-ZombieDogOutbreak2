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
    
    public GameObject droppedItemPrefab;
    public List<Loot> lootList = new List<Loot>();


    /*
    *function to determine which item gets dropped
    *no parameter
    *drops the item
    */
    Loot GetDroppedItem()
    {
        int randomNumber = Random.Range(1,101);
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


        /*
        *function to spawn the loot where the dog last was
        *spawn position parameter
        *spawns the item where the zomdog was
        */
        public void InstantiateLoot(Vector3 spawnPosition)
        {
            Loot droppedItem = GetDroppedItem();
            if(droppedItem != null)
            {
                GameObject lootGameObject = Instantiate(droppedItemPrefab,spawnPosition,Quaternion.identity);
                lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;
            }
        }


    }
   

