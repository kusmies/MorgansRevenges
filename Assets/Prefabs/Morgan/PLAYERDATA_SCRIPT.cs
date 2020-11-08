using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PLAYERDATA_SCRIPT
{
    //the player intigers
    public int level;
    public Slider hp;
    public Slider mana;
    public int soul;
    public int money;
    public float[] position;

    public PLAYERDATA_SCRIPT(PLAYER_SCRIPT player)
    {
        //saves the player data
        soul = player.soul;
        mana = MP_SCRIPT.mana.Mp;
        hp = player.Hp;
        money = player.coin;
        position = new float[3];

        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

    }

}
