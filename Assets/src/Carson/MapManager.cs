using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {
	[SerializeField]
	GameObject StartMenu;
	
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }
	
	public List<Vector3> GetSpawnPoints() {
		return new List<Vector3>();
	}
	
	public void StartGame() {
		StartMenu.SetActive(false);
	}
}
