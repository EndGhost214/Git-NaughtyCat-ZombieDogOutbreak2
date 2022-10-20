using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : ZombieDog
{

    private ZombieDog ZomDog;

    public LevelUp(ZombieDog dog)
    {
        ZomDog = dog;
    }

    //figure out how to append on to the base stats
    protected override int SetDamage()
    {
        return ZomDog.damage + 5;
    }
    protected override int SetHealth()
    {
        return ZomDog.health + 10;
    }
    protected override float SetSpeed()
    {
        return ZomDog.speed + 0.1f;
    }
}
