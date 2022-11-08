using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Abstract class defining the methods and fields implemented by all child classes.
 */
public abstract class AbstractRoomFactory : MonoBehaviour
{
	// Function to create a new room and return a reference to its script component
	public abstract Room createRoom(string name);
}
