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

    /*
     *This function sets the stats of the sprite passed in
     *
     *Parameter: Zombie dog sprite
     *
     * Uses the dynamically bound functions below to set the stats
    */
    public override void SetDog(ZombieDog dog)
    {
        ZomDog = dog;
        damage = SetDamage();
        speed = SetSpeed();
        health = SetHealth();
    }
    
    //sets the damage of the dog to 5 more than the existing damage
    protected override float SetDamage()
    {
        return ZomDog.damage + 5f;
    }

    //sets the health to 10 more than the existing health
    protected override float SetHealth()
    {
        return ZomDog.health + 10f;
    }

    //sets the speed to .1 more than the existing speed
    protected override float SetSpeed()
    {
        return ZomDog.speed + 0.1f;
    }
}

