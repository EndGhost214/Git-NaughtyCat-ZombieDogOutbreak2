using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalPlayer : Player
{

    private Player _player;
    public SurvivalPlayer(Player player)
    {
        _player = player;
        SetHealth(100);
    }

    //setting player skin to the survivalplayer prefab
    protected override GameObject GetPlayerObject()
    {
        return GameObject.Find("SurvivalPlayer");
    }

    private uint healthActual;


        public uint GetHealth()
        {
            return healthActual;
        }

        public void SetHealth(uint h)
        {
            healthActual = h;
        }
        public void DamagePlayer(uint damage)
        {
            uint newHealth = GetHealth() - damage;
            SetHealth(newHealth);

        }


}
