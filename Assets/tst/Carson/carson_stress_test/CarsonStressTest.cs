using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarsonStressTest : MonoBehaviour {
	[SerializeField]
	private TextMeshProUGUI counter;
	
	private List<Dog> dogs;
	private float dps;
	private float startTime;
	private int dogCount;
	
	[SerializeField]
	private ZombieDog basicDog;
	
    // Start is called before the first frame update
    void Start() {
        dogs = new List<Dog>();
		startTime = Time.time;
		dogCount = 0;
    }

    // Update is called once per frame
    void Update() {
		dogCount++; // number of dogs in the last second
		dps = dogCount / (Time.time - startTime);
		
		// Reset timer and counter every second
		if (Time.time - startTime > 1) {
			startTime = Time.time;
			dogCount = 0;
		}
		
		counter.text = "Total: " + dogs.Count + "\nDPS: " + dps + "\n" + (dps <= 3 ? "Stress Achieved" : null);
		
        dogs.Add(Instantiate(basicDog, new Vector3(Random.Range(-10, 10), Random.Range(-4, 4), 0), Quaternion.identity));
		// Randomly nudge one dog every frame
		dogs[(int) Random.Range(0, dogs.Count - 1)].GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-25, 25), Random.Range(-15, 15)), ForceMode2D.Impulse);
    }
}
