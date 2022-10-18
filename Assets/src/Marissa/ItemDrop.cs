using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : Singleton
{

    private Rigidbody2D itemRb;
    public float dropForce = 5;

    // Start is called before the first frame update
    void Start()
    {
        
        itemRb = GetComponent<Rigidbody2D>();
        itemRb.AddForce(Vector2.up * dropForce, ForceMode2D.Impulse);

    }

   
}
