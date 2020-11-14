using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public static class SaveLoadManager
{
    // Start is called before the first frame update
    public static void SavePlayer(PLAYER_SCRIPT player)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/player.sav", FileMode.Create);

        PlayerData data = new PlayerData(player);

        bf.Serialize(stream, data);
        stream.Close();

    }
    public static float[] LoadPlayer()
    {
        if (File.Exists(Application.persistentDataPath + "/player.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/player.sav", FileMode.Open);
            PlayerData data = bf.Deserialize(stream) as PlayerData;

            stream.Close();
            return data.stats;
        }

        else
        {
            Debug.LogError("Nothing");
            return new float[4];
        }
    }
}


[Serializable]
public class PlayerData
{
    public float[] stats;
  
    public PlayerData(PLAYER_SCRIPT player)
    {
        stats = new float[4];

        stats[0] = player.health;
        stats[1] = player.mana;
        stats[2] = player.coin;
    }


}