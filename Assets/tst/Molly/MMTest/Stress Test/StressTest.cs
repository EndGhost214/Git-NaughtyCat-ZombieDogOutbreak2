using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StressTest : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI heal;

    
    ZombieDog dog1;
     
    // Start is called before the first frame update
    void Start()
    {
        //instantiate dog
        Instantiate(dog1, new Vector3(0, 0, 0), Quaternion.identity);
        
        //dog with normal stats
        dog1 = dog1.GetComponent<BaseDog>();
        Debug.Log("Health of Dog Start: " + dog1.health);
        //dog1 = new BaseDog(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        //continuously wrap the decorator over a dog 
        //dog1 = new LevelUp(dog1);
        dog1 = dog1.gameObject.AddComponent<LevelUp>() as LevelUp;
        Debug.Log("Health of Dog: " + dog1.health);
        heal.SetText("Health = " + dog1.health);
    }
}

