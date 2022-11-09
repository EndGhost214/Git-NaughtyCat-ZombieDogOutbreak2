/*
*DontDestroyAudio.cs
*Marissa Samayoa
*to make sure the background music doesn't stop when scenes change
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*class that prevents the background audio from stopping when the scenen changes
*member variables:
* transform.gameObject - so you can place the bg audio in the inspector
*/

public class DontDestroyAudio : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
