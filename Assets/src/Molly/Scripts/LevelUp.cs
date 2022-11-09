using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
