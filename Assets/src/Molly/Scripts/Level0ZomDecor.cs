using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0ZomDecor : ZombieDog
{
    protected int health;
    protected float speed;
    protected int damage;

    private ZombieDog ZomDog;
    public Level0ZomDecor(ZombieDog dog)
    {
        ZomDog = dog;
    }

    //figure out how to append on to the base stats
    protected override int SetDamage(){
        return 10;
    }
    protected override int SetHealth(){
        return 10;
    }
    protected override float SetSpeed(){
        return .5f;
    }
}
