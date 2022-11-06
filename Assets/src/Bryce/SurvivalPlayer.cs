/*
 * SurvivalPlayer.cs
 * Bryce Hendrickson
 * A decorator class that will assign the player with health and control of the survival player prefab.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Surival Player decorator class to assign health and control of survival player prefab
 * 
 * Member variables:
 * _player - Player type intake for constructor
 * healthActual - variable to store the health of the player
 * SurvivalPlayer(Player player) - constructor
 * GameObject GetPlayerObject() - decorator override to set the controllable prefab to the survival player
 * GetHealth() - returns current health
 * SetHealth(float h) - sets health
 * DamagePlayer(float damage) - subtracts health from player
 */
public class SurvivalPlayer : Player
{

    private Player _player;
    private float healthActual;

    //constructor sets health to 100 and sets player type to control player
    public SurvivalPlayer(Player player)
    {
        _player = player;
        SetHealth(100);
    }

    //setting player to the survivalplayer prefab
    protected override GameObject GetPlayerObject()
    {
        return GameObject.Find("SurvivalPlayer");
    }


    //Returns health as float
    public float GetHealth()
    {
        return healthActual;
    }

    //Sets health, takes in a float
    public void SetHealth(float h)
    {
        healthActual = h;
    }

    //Damages player, takes in a float. Does not do anything if damage is less than 1
    public void DamagePlayer(float damage)
    {

        if(damage < 1)
        {
            return;
        }

        float newHealth = GetHealth() - damage;

        if(newHealth >= 0)
        {
            SetHealth(0);
            Time.timeScale = 0f;
            return;
        }

        SetHealth(newHealth);

    }


}
