/*
 * BaseDog.cs
 * Molly Meadows
 * Description: This class is a child of the Zombie Dog class. It sets the base stats of a zombie dog (health, damage done to player, and its speed). 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Description: his class is a child of the Zombie Dog class. It sets the base stats of a zombie dog (health, damage done to player, and its speed) which is an
 * override of the methods in the dog class
 *
 * Member Variables:
 * protected float baseh: the starting health stat
 * protected float based: the starting damage stat
 * protected float bases: the starting speed stat
 *
*/
public class BaseDog : ZombieDog
{
    //base variables for each zombie dog
    protected float baseh = 100f;
    protected float based = 5f;
    protected float bases = 1.5f;

    //never actually gets called here(sets stats in ZombieDog ObObjectSpawn())
    public BaseDog()
    {
        damage = SetDamage();
        speed = SetSpeed();
        health = SetHealth();
    }

    //Returns the base damage (5)
    protected override float SetDamage()
    {
        return based;
    }
    
    //returns the base health (100)
    protected override float SetHealth()
    {
        return baseh;
    }

    //returns the base speed (1.5)
    protected override float SetSpeed()
    {
        return bases;
    }

    /*Sets the stats of the Zombie dog
     *
     * ZombieDog dog parameter
     *
     * No Code, will be set in ZombieDog class
    */
    public override void SetDog(ZombieDog dog)
    {
    }

}

