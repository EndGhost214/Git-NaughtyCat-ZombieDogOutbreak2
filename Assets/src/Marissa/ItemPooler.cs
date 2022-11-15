/*
*ItemPooler.cs
*Marissa Samayoa
*contains the item pool scripts
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
*class that creates item pool for items and moves them between the queue and game
*member variables:
* ItemPool - details of the item pool
* container - for scene organization with the item pool
*/
public class ItemPooler : MonoBehaviour
{
    //for scene organization with the item pool
    [SerializeField]
    Transform container;

    /*
    *class that contains the item pool details
    *member variables:
    * tag - to be able to call the item
    * prefab - the prefab for the item
    * size - size of that pool of items
    */

    [System.Serializable]   //makes it visible in inspector
    public class ItemPool
    {

        public string tag;  //to be able to call the item
        public GameObject prefab;  //the prefab youre going to use
        public int size;  //size of the pool

    }

    //allows it to collapse
    #region Singleton 
    //allowing the easy access of grabbing the ItemPooler
    public static ItemPooler Instance;

    private void Awake()
    {
        Instance = this;

    }

    #endregion

    public List<ItemPool> pools; //creates a list of pools



    //creates dictionary
    //dictonaries are used to store the pool and you can tag them individually
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //creates a new dictionary to work with
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        //loop through all of the pools
        foreach (ItemPool pool in pools)
        {
            //create a queue of objects
            Queue<GameObject> objectPool = new Queue<GameObject>();

            //create each of the objects in the queue
            for(int i=0;i<pool.size;i++)
            {
                GameObject obj = Instantiate(pool.prefab, container, false); //instantiates the item
                obj.SetActive(false); //disables it so you cant see it yet
                objectPool.Enqueue(obj);  //add it to the end of our queue
            }

            //add the pool to the dictionary
            poolDictionary.Add(pool.tag, objectPool);

        }


    }

    /* function taking inactive items and spawning them in the world
    *
    * parameters:
    * tag - which item pool you want
    * position - where the item will spawn
    * roatation - the rotation of the item to spawn
    *
    * spawns the item then adds it back to the queue to be reused
    */
    public GameObject spawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        //makes sure the item pool we're calling exists
        if(!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesnt exist");
            return null;
        }
       
        //get the prefab we want to spawn
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();  //gets us the appropriate queue and dequeues the item

        objectToSpawn.SetActive(true); //activates the item
        objectToSpawn.transform.position = position; //gets the position of where to spawn
        objectToSpawn.transform.rotation = rotation;  //gets the rotation of the item
    

        //searches the interface
        GameObject pooledObj = objectToSpawn;

       

        //add it back to the queue to be reused later
        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }


}
