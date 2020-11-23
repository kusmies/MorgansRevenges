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
    public void New(int index)
    {
        Debug.Log("click");
        foreach (ItemEntry item in XMLManager.ins.itemDB.list)
        {
            if(item.ID ==1)
            {
                item.value = 1;
                item.got = false;
                item.name = "BronzeRing";
                item.currency = Currency.Gold;
                item.price = 4;
            }
            if (item.ID == 2)
            {
                item.value = 2;
                item.got = false;
                item.name = "SilverRing";
                item.currency = Currency.Gold;
                item.price = 8;
            }
            if (item.ID == 3)
            {
                item.value = 1;
                item.got = false;
                item.name = "SteelHelm";
                item.currency = Currency.Gold;
                item.price = 2;
            }
            if (item.ID == 4)
            {
                item.value = 2;
                item.got = false;
                item.name = "SteelShield";
                item.currency = Currency.Gold;
                item.price = 4;
            }

        }

        XMLManager.ins.SaveItems();

        player.MaxHealth = 12;
        player.MaxMana = 4;
        player.coin = 0;
        SaveLoadManager.SavePlayer(player);
        SceneManager.LoadScene(index);

    }
    public void Load(int index)
    {
        float[] loadedStats = SaveLoadManager.LoadPlayer();
        XMLManager.ins.LoadItems();

        player.MaxHealth = loadedStats[0];
        player.MaxMana = loadedStats[1];
        player.coin = loadedStats[2];
        SceneManager.LoadScene(index);

    }

}
