using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarsonStressTest : MonoBehaviour {
	[SerializeField]
	private TextMeshProUGUI counter;
	
	private List<Dog> dogs;
	
	[SerializeField]
	private ZombieDog basicDog;
	
    // Start is called before the first frame update
    void Start()
    {
        dogs = new List<Dog>();
    }

    // Update is called once per frame
    void Update()
    {
		counter.text = "" + dogs.Count;
        dogs.Add(Instantiate(basicDog, new Vector3(Random.Range(-5, 5), Random.Range(-2, 2), 0), Quaternion.identity));
    }
}
