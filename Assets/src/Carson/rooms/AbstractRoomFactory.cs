using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractRoomFactory : MonoBehaviour
{
	public abstract Room createRoom(string name);
	protected abstract void setDoor();
}
