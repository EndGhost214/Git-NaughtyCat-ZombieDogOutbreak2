using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFunctions : MonoBehaviour
{
    
    public GameObject[] itemDrops;

   private void ItemDrop(){
        for(int i=0; i<itemDrops.Length; i++){

            Instantiate(itemDrops[i], transform.position, Quaternion.identity); 
        }
   }

}
