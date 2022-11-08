using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPooler : MonoBehaviour
{
    
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

            //cretae each of the objects in the queue
            for(int i=0;i<pool.size;i++)
            {
                GameObject obj = Instantiate(pool.prefab); //instantiates the item
                obj.SetActive(false); //disables it so you cant see it yet
                objectPool.Enqueue(obj);  //add it to the end of our queue
            }

            //add the pool to the dictionary
            poolDictionary.Add(pool.tag, objectPool);

        }


    }

    //taking inactive cubes and spawning them in the world
    public GameObject spawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
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
        IItemPooledObject pooledObj = objectToSpawn.GetComponent<IItemPooledObject>();

        //makes this optional
        if (pooledObj != null)
        {
            pooledObj.onItemSpawn();
        }

        //add it back to the queue to be reused later
        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }


}
