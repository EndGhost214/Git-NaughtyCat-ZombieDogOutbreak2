using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogPool : MonoBehaviour
{
    private ZombieDog dog;

    // Start is called before the first frame update
    void Start()
    {
        dog = GameObject.Find("ZombieDogSprite").GetComponent<ZombieDog>();

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
