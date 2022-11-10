/*
 * LevelUp.cs
 * Molly Meadows
 * Description: This is the class for the decorator pattern for the zombie dog sprites. It also includes dynamic binding to set the stats to slightly better than they
 * were for the round previous. 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Description: This is the decorator class that sets the base components and adds to each stat
 * 
 * Member Variables:
 * private ZombieDog ZomDog: type of zombiedog that will set the sprite to have increased stats
*/
public class LevelUp : ZombieDog
{
    private ZombieDog ZomDog;

    public override void SetDog(ZombieDog dog)
    {
        ZomDog = dog;
        damage = SetDamage();
        speed = SetSpeed();
        health = SetHealth();
    }
    
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

