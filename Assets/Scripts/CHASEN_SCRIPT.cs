using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CHASEN_SCRIPT : MonoBehaviour
{
   public PLAYER_SCRIPT player;

    public bool onTitle = true;
    string titlescreenName = "TitleScreen";

    //This function changes the scene. It needs to be attached to an object in the current scene in order to function.
    //When we call this script we need to parse in the index number of the scene we want.

    public void changeScene(int index)
    {
        Scene currScene = SceneManager.GetActiveScene();

        if (currScene.name == titlescreenName)
        {

            player.MaxHealth = 12;
            player.MaxMana = 4;
            player.coin = 0;
            SaveLoadManager.SavePlayer(player);

            PlayerPrefs.DeleteAll();
            Debug.Log("Deleted everything");
        }
        
        SceneManager.LoadScene(index);
    }
    public void Load()
    {
        float[] loadedStats = SaveLoadManager.LoadPlayer();

        player.MaxHealth = loadedStats[0];
        player.MaxMana = loadedStats[1];
        player.coin = loadedStats[2];
    }

}
