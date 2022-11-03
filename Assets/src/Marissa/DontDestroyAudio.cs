/*
*DontDestroyAudio.cs
*Marissa Samayoa
*to make sure the background music doesn't stop when scenes change
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAudio : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
