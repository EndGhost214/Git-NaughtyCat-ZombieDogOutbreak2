using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singlton pattern to be inherited by other classes
public class Singleton<T> : MonoBehaviour where T : Component {
	protected static T _instance;
	
	//Reference to the instance accessible by other classes
	public static T Instance {
		get {
			// If the instance reference is null, try to find the object
			if (_instance == null) {
				_instance = FindObjectOfType<T>();
				
				// If the singleton hasn't been created yet
				if (_instance == null) {
					GameObject newObject = new GameObject();
					_instance = newObject.AddComponent<T>();
				}
			}
			return _instance;
		}
	}
	
	// When the script is loaded
	public virtual void Awake() {
		_instance = this as T;
	}
}
