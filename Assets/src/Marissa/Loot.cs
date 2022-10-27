/*
*Loot.cs
*Marissa Samayoa
*creates spot in inspector to add in item sprites for drops
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]

/*
*class that creates spots in the inspector for items
*member variables:
*lootSprite - the item sprite
*lootName - the name of the item
*dropChance - the chance of the item dropping
*Loot() - constructor
*/

public class Loot : ScriptableObject
{
    public Sprite lootSprite;
    public string lootName;
    public int dropChance;

    public Loot(string lootName,int dropChance)
    {
        this.lootName=lootName;
        this.dropChance=dropChance;

    } 

}