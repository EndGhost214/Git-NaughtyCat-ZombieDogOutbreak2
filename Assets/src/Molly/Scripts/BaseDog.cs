using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BaseDog : ZombieDog
{
    
    //base variables for each zombie dog
    protected int baseh = 100;
    protected int based = 5;
    protected float bases = 0.5f;

    public BaseDog(){
        damage = SetDamage();
        speed = SetSpeed();
        health = SetHealth();
    }

    protected override int SetDamage(){
        return based;
    }
    protected override int SetHealth(){
        return baseh;
    }
    protected override float SetSpeed(){
        return bases;
    }
    public override void SetDog(ZombieDog dog){
    }

}
