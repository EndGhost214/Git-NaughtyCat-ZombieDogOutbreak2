/*
 * ObjectPooler.cs
 * Bryce Hendrickson
 * ObjectPooler script that will act as a customizable interface for our pooled objects
 */
using System.Collections.Generic;
using UnityEngine;

/*
 * ObjectPooler class to initalize our object pools
 * 
 * Member variables:
 * Pool - a class instance of an object pool
 * tag - name of the pooled object
 * prefab - prefab of the pooled object
 * size - number of pooled objects
 * pools - list of current object pools
 * poolDictionary - dictonary that ties our tag string to a prefab
 * container - a transform used by the game manager
 * Instance - instance of our ObjectPooler as a singleton
 * Awake() - called when the object pooler is first activated
 * Start() - called before any update function
 * SpawnFromPool (string tag, Vector3 position, Quaternion rotation) - spawns a prefab in from the object pool
 */
public class ObjectPooler : MonoBehaviour
{

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public static ObjectPooler Instance;

    [SerializeField]
    private Transform container;

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;

    }
    
    #region Singleton

    //Awake setting the instance to this for the singleton pattern
    public void Awake()
    {
        Instance = this;
    }

    #endregion

    //Start called before any update function, sets up all object poolers
    private void Start()
    {
        //Allocating space for our poolDictonary
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        
        //Foreach loop to set up each of our pools
        foreach (Pool pool in pools)
        {
            //Allocating space for our objectpool
            Queue<GameObject> objectPool = new Queue<GameObject>();
            
            //For loop to clone each prefab in the pool based on the pool size
            for(int i = 0; i< pool.size; i++)
            {
               GameObject obj = Instantiate(pool.prefab, container, false);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            //adding out pool to the poolDictonary
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    //SpawnFromPool spawns in a prefab from the pool using normal instanciate parameters
    public GameObject SpawnFromPool (string tag, Vector3 position, Quaternion rotation)
    {
        //Error if spawning unknown tag
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist");
            return null;
        }

        //setting our object to the oject from our pool dictionary
        GameObject objectToSpawn =  poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        //Setting pooledObj to our objectToSpawn to accsess our OnObjectSpawn from the IPooledObject interface
        IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();

        if(pooledObj != null)
        {
            //Spawn function for the given prefab
            pooledObj.OnObjectSpawn();
        }

        //Queuing back our object from the poolDictionary
        poolDictionary[tag].Enqueue(objectToSpawn);

        //Returning the spawned gameobject
        return objectToSpawn;
    }
}
