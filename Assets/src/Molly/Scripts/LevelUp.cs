using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : ZombieDog
{
    /*protected int health;
    protected float speed;
    protected int damage;*/

    private ZombieDog ZomDog;
    public LevelUp(ZombieDog dog)
    {
        ZomDog = dog;
    }

    //figure out how to append on to the base stats
    protected override int SetDamage()
    {
        return this.based + 5;
    }
    protected override int SetHealth()
    {
        return this.baseh + 10;
    }
    protected override float SetSpeed()
    {
        return this.bases + .1f;
    }
}
