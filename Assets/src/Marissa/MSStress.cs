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

    // Update is called once per frame
    void Update()
    {
        


        Instantiate(basicDog, new Vector3(0, 0, 0), Quaternion.identity);
        basicDog.Death();
        dogCount=dogCount +1;
        Count.text = "Item Count: " + dogCount;

       

    }
}