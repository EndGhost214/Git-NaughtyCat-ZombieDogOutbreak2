/*
 * DogPool.cs
 * Molly Meadows
 * Description: This is the object pooler pattern for the zombie dogs. This is also where the levelup component gets decorated onto the dog sprite.
 * got object pooler code from: https://youtu.be/tdSmKaJvCoA
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Description: Object pooler class that will allow for the zombie dogs to be dequeued/enqueued when instantiated/killed so that it takes less memory.
 * Contains where the level up gets called
 *
 * Member Variables:
 * private ZombieDog dog: allows for the code to get/add and remove the components from the enqueued zombie dog sprite.
 * public List<lDogPool> dogPools: A list of dog sprites
 * private Transform container: puts the sprites in the enemy GameObject in the hierarchy of the scene
 * public Dictionary<string, Queue<GameObject>> dogPoolDictionary: Dictionary that holds a tag and a queue of zombie dog game objects.
 * public static DogPool Instance: and instance of the class DogPool, description below
*/
public class DogPool : MonoBehaviour
{
    //create a zombie dog instance to decorate the level up components
    private ZombieDog dog;

    //list of pools from pool class
    public List<lDogPool> dogPools;

    //serialized field for hierarchy container
    [SerializeField]
    private Transform container;

    //object pooler using a dictionary
    public Dictionary<string, Queue<GameObject>> dogPoolDictionary;

    /*
     * Description: This class instantiates the size of the list and its components for the object pool
     *
     * Member Variables:
     * public int size: size of elements in the list
     * public string tag: string that holds the tag for the sprites in the queue
     * public GameObject prefab: holds the zombie dog sprite prefab
    */
    [System.Serializable]
    public class lDogPool{
        public int size = 30;
        public string tag = "ZombieDog";
        public GameObject prefab;
    }

    //Singleton pattern that declares an instance when spawned into the hierarchy at start of game (#region creates drop down)
    #region Singleton

    public static DogPool Instance;

    void Awake() {
        Instance = this;
    }
    #endregion

    /* 
     * Start is called before the first frame update. 
     * creates the dictionary of game objects.
     * sets all dogs as inactive in the hierarchy
     * adds the dogs to the dictionary
    */
    void Start()
    {
        //create an instance of the pool using the GameObject class
        dogPoolDictionary = new Dictionary<string, Queue<GameObject>>();

        //defines the queue of dogs
        foreach(lDogPool dogPool in dogPools)
        {
            //create a new queue called object pool
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for( int i = 0; i < dogPool.size; i++)
            {
                //set in the container in the hierarchy and put in local space
                GameObject obj = Instantiate(dogPool.prefab, container, false);
                //sets the object false in the hierarchy
                obj.SetActive(false);
                //push the object onto the queue
                objectPool.Enqueue(obj);
            }
            //Debug.Log(dogPool.tag);

            //add the object to the dictionary
            dogPoolDictionary.Add(dogPool.tag, objectPool);
        }
    }

    /*  
     * Dequeues the sprite form the dictionary, sets it active in the hierarchy
     * and sets the correct number of levelup components to the dequeued sprite
     * 
     * Parameters: string tag to show the dictionary, the position and rotation of the sprite for spawn point
    */
    public GameObject SpawnFromDogPool (string tag, Vector3 position, Quaternion rotation)
    {
        //Debug.Log(tag);
        //checks to see if the tag is in the pool, if not runs a debug log and returns a null game object
        if(!dogPoolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Error tag not found");
            return null;
        }

        //dequeue the object
        GameObject objectToSpawn = dogPoolDictionary[tag].Dequeue();

        //set active in hierarchy
        objectToSpawn.SetActive(true);

        //set the position from the given information
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        //put the object back in the queue to spawn
        dogPoolDictionary[tag].Enqueue(objectToSpawn);

        //remove all level up components from the current dog
        LevelUp[] objs = objectToSpawn.GetComponents<LevelUp>();
        foreach (LevelUp obj in objs) {
            Destroy(obj);
        }
        
        //get base dog component from the objectToSpawn
        dog = objectToSpawn.GetComponent<BaseDog>();

        if(dog != null)
        {
            dog.OnObjectSpawn();
        }

        //if the round is greater than 1, wrap a level up script onto the dog for the number of rounds
        int round =  GameManager.Instance.getRound();
        //round = 2;
        if (round > 1)
        {
            //Debug.Log("Here" + " Round: " + round);
            for (int i = 0; i < round; i++) {
                Debug.Log("i: "+ i);

                //wrap the levelup script onto the dog
                ZombieDog dogTemp = dog.gameObject.AddComponent<LevelUp>();
                dogTemp.SetDog(dog);

                dog = dogTemp;
            }
        }
    
        //return the object
        return objectToSpawn;
    }
}

 