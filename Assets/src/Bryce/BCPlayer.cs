/*
 * BCPlayer.cs
 * Bryce Hendrickson
 * Decorator extension of the Player movement script
 */
using UnityEngine;

/*
 * Decorator extension of the Player movement script
 * 
 * Member variables:
 * player - type of player for the constructor to make this a decorator class
 * BCPlayer(Player playerX) - constructor
 * GameObject GetPlayerObject() - dynamic override function that sets the usable prefab to the BCPlayer prefab
 */
public class BCPlayer : Player
{

    private Player player;

    //Constructor setting the internal player to the already instantiated player
    public BCPlayer(Player playerX)
    {
        player = playerX;
    }

    //dynamic override function that sets the usable prefab to the BCPlayer prefab for the player movement script to use
    protected override GameObject GetPlayerObject()
    {
        return GameObject.Find("BCPlayer");
    }

}
