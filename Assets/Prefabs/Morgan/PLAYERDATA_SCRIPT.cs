using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PLAYERDATA_SCRIPT {

    public int coin;

    public PLAYERDATA_SCRIPT(PLAYER_SCRIPT player)
    {
        coin = player.coin;
    }

}
