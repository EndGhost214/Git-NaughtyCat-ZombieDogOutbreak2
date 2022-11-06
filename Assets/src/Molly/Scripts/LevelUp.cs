using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class LevelUp : ZombieDog
{

    private ZombieDog ZomDog;

    /*void Awake(){
        ZombieDog dog = GameObject.Find("ZombieDog").GetComponent<ZombieDog>();
        ZomDog = dog;
    }*/

    public override void SetDog(ZombieDog dog)
    {
        ZomDog = dog;
        damage = SetDamage();
        speed = SetSpeed();
        health = SetHealth();
    }

    //figure out how to append on to the base stats
    protected override float SetDamage()
    {
        return ZomDog.damage + 5f;
    }
    protected override float SetHealth()
    {
        return ZomDog.health + 10f;
    }
    protected override float SetSpeed()
    {
        return ZomDog.speed + 0.1f;
    }
}
