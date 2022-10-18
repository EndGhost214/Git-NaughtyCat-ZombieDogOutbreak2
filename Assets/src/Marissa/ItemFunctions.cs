using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFunctions : Singleton<>
{
    
    public GameObject[] itemDrops;

   public void ItemDrop(){
        for(int i=0; i<itemDrops.Length; i++){

            Instantiate(itemDrops[i], transform.position, Quaternion.identity); 
        }
   }

}
