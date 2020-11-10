
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

public static class SAVESYSTEM 
{
   
    public static void SavePlayer(PLAYER_SCRIPT player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Player.morg";
        FileStream stream = new FileStream(path, FileMode.Create);


        PLAYERDATA_SCRIPT data = new PLAYERDATA_SCRIPT(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static PLAYERDATA_SCRIPT LoadPlayer()
    {
        string path = Application.persistentDataPath + "/Player.morg";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

           PLAYERDATA_SCRIPT data = formatter.Deserialize(stream)as PLAYERDATA_SCRIPT;

            stream.Close();

            return data;

        }
        else
        {
            UnityEngine.Debug.LogError("save file not found in" + path);
            return null;
        }
    }
}
