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

    private float healthActual;


        public float GetHealth()
        {
            return healthActual;
        }

        public void SetHealth(float h)
        {
            healthActual = h;
        }
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
