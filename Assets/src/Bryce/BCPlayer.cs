using UnityEngine;

public class BCPlayer : Player
{

    private Player _player;
    public BCPlayer(Player player)
    {
        _player = player;
        
    }
    protected override GameObject GetPlayerObject()
    {
        return GameObject.Find("BCPlayer");
    }

}
