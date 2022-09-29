using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component {
	private static T _instance;
	public static T Instance {
		get {
			if (_instance == null) {
				_instance = FindObjectOfType<T>();
				if (_instance == null) {
					GameObject newGO = new GameObject();
					_instance = newGO.AddComponent<T>();
				}
			}
			return _instance;
		}
	}
	
	public virtual void Awake() {
		_instance = this as T;
	}
}
