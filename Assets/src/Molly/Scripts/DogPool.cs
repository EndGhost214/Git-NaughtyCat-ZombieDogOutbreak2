using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//got object pooler code from: https://youtu.be/tdSmKaJvCoA 

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

    //create a class to keep the stats of the pool
    [System.Serializable]
    public class lDogPool{
        public int size = 30;
        public string tag = "ZombieDog";
        public GameObject prefab;
    }

    //way to work around the singleton pattern
    #region Singleton

    public static DogPool Instance;

    void Awake() {
        Instance = this;
    }
    #endregion

    // Start is called before the first frame update
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

    //will spawn the dogs from the queue, need to get the position and rotation from carson's function
    //need to make a reset so that the level component only adds as many scripts as there are rounds and not exponentially
    public GameObject SpawnFromDogPool (string tag, Vector3 position, Quaternion rotation)
    {
        //Debug.Log(tag);
        //checks to see if the tag is in the pool, if not runs a debug log and returns a null game object
        if(!dogPoolDictionary.ContainsKey(tag))
        {
            Debug.Log("Error tag not found");
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
        round = 2;
        if (round > 1)
        {
            Debug.Log("Here" + " Round: " + round);
            for (int i = 0; i < round; i++) {
                Debug.Log("i: "+ i);
                //wrap the levelup script onto the dog
                ZombieDog dogTemp = dog.gameObject.AddComponent<LevelUp>();
                dogTemp.SetDog(dog);

                dog = dogTemp;
                //dog.SetDog(dog);
            }
        }
        
        //objectToSpawn = dog;
        //return the object
        return objectToSpawn;
    }
}

 