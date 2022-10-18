using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1ZomDecor : ZombieDog
{
   protected int health;
   protected int damage;
   protected float speed;

   void Start(){
        health = this.baseh + 5;
        damage = this.based + 5;
        speed = this.bases + 0.1f;
   }
}
