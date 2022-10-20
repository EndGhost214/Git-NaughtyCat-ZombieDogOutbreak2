using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StressTest : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI heal;

    [SerializeField]
    private ZombieDog dog1;

    private ZombieDog dog2;
    private ZombieDog dog3;
     
    // Start is called before the first frame update
    void Start()
    {
        //instantiate dog
        dog2 = Instantiate(dog1, new Vector3(0, 0, 0), Quaternion.identity);
        
        //dog with normal stats
        dog2 = dog2.GetComponent<BaseDog>();
        Debug.Log("Health of Dog Start: " + dog1.health);
        //dog1 = new BaseDog(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        //continuously wrap the decorator over a dog 
        //dog1 = new LevelUp(dog1);
        dog3 = dog2.gameObject.AddComponent<LevelUp>() as LevelUp;
        dog3.SetDog(dog2);
        dog2 = dog3;
        //dog1 = dog1.GetComponent<LevelUp>();
        //Instantiate(dog1, new Vector3(0, 0, 0), Quaternion.identity);
        Debug.Log("Health of Dog: " + dog2.health);
        heal.SetText("Health = " + dog2.health);
    }
}

