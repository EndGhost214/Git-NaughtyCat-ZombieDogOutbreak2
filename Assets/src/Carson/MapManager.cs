using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {
	//[SerializeField]
	//private GameObject StartMenu;
	
	private List<Vector3> spawnPoints = new List<Vector3>();
	
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }
	
	public List<Vector3> GetSpawnPoints() {
		return spawnPoints;
	}
	
	public void StartGame() {
		Debug.Log("Game started");
		//StartMenu.SetActive(false);
		
		spawnPoints.Add(new Vector3(0, 0, 0));
	}
}
