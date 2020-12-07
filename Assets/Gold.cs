using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{

    public Text playergold;
    public PLAYER_SCRIPT player;


    private void Start()
    {
        playergold.text = player.coin.ToString();
        
    }
    public void Load()
    {
        float[] loadedStats = SaveLoadManager.LoadPlayer();

        player.coin = loadedStats[2];
    }
}
