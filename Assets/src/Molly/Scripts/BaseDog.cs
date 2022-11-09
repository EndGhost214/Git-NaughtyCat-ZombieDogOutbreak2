using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseDog : ZombieDog
{
    //base variables for each zombie dog
    protected float baseh = 100;
    protected float based = 5;
    protected float bases = 1.5f;

    public BaseDog()
    {
        damage = SetDamage();
        speed = SetSpeed();
        health = SetHealth();
    }

    protected override float SetDamage()
    {
        return based;
    }
    protected override float SetHealth()
    {
        return baseh;
    }
    protected override float SetSpeed()
    {
        return bases;
    }
    public override void SetDog(ZombieDog dog)
    {
    }

}

