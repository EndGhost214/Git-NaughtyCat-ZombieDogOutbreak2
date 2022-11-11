/*
 * Singleton.cs
 * Carson Sloan
 * Basic class to help other classes follow the Singleton pattern.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Singleton pattern to be inherited by other classes.
 *
 * PUBLIC PROPERTIES:
 * Instance - reference to the component in the scene of the inheriting class
 *
 * PROTECTED PROPERTIES:
 * _instance - reference to the inheriting class for Instance to point to
 */
public class Singleton<T> : MonoBehaviour where T : Component
{
	// Reference to the static instance property accessible by other classes
	public static T Instance
	{
		get // only define the getter for the property
		{
			// If the instance reference is null, try to find the object
			if (_instance == null)
			{
				_instance = FindObjectOfType<T>();
				
				// If the singleton hasn't been created yet, add the script to the managers GameObject
				if (_instance == null)
				{
					_instance = GameObject.Find("Controller Scripts").transform.Find("Managers").gameObject.AddComponent<T>();
				}
			}
			
			return _instance;
		}
	}
	
	protected static T _instance;
	
	/*
	 * Called by Unity when the script is loaded for the first time, to set the instance property.
	 */
	public virtual void Awake() {
		_instance = this as T; // set _instance (and Instance) to this instantiation of the class
	}
}

