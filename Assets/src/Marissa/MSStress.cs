using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MSStress : MonoBehaviour
{

    [SerializeField]
    ZombieDog basicDog;
    // Start is called before the first frame update
    private int dogCount;
    public Text Count;
    void Start()
    {
        
    }


    private float cooldown=0;
    // Update is called once per frame
    void Update()
    {
        

        if(Time.time >= cooldown){

        cooldown=Time.time+1f/5;
        Instantiate(basicDog, new Vector3(0, 0, 0), Quaternion.identity);
        basicDog.Death();
        dogCount=dogCount +1;
        Count.text = "Item Count: " + dogCount;

        }

    }
}