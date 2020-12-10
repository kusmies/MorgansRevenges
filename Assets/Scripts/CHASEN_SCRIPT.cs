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

     void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();

        }
    }
    public void changeScene(int index)
    {
        Scene currScene = SceneManager.GetActiveScene();

        if (currScene.name == titlescreenName)
        {

            player.MaxHealth = 12;
            player.MaxMana = 12;
            player.coin = 0;
            player.SwordDamage = 0;
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
                item.displayed = false;
                item.chestdropped = false;
                item.name = "Bronze Ring";
                item.description = "Magic +1";
                item.currency = Currency.Gold;
                item.price = 2;
            }
            if (item.ID == 2)
            {
                item.value = 2;
                item.got = false;
                item.chestdropped = false;
                item.displayed = false;

                item.name = "Silver Ring";
                item.description = "Magic +2";
                item.currency = Currency.Gold;
                item.price = 4;
            }
            if (item.ID == 3)
            {
                item.value = 1;
                item.got = false;
                item.chestdropped = false;
                item.displayed = false;

                item.name = "Steel Helm";
                item.description = "Health +1";

                item.currency = Currency.Gold;
                item.price = 2;
            }
            if (item.ID == 4)
            {
                item.displayed = false;

                item.value = 2;
                item.got = false;
                item.chestdropped = false;
                item.name = "Steel Shield";
                item.description = "Health +2";
                item.currency = Currency.Gold;
                item.price = 4;
            }


            if (item.ID == 5)
            {
                item.displayed = false;

                item.value = 1;
                item.got = false;
                item.chestdropped = false;
                item.name = "Dagger";
                item.description = "Sword Damage +1";
                item.currency = Currency.Gold;
                item.price = 2;
            }
            if (item.ID == 6)
            {
                item.displayed = false;

                item.value = 2;
                item.got = false; 
                item.chestdropped = false;
                item.name = "Long Sword";
                item.description = "Sword Damage +2";

                item.currency = Currency.Gold;
                item.price = 4;
            }
        }

        foreach (PermItemEntry item in XMLManager.ins.PitemDB.list)
        {
            if(item.ID ==1)
            {
                item.displayed = false;

                item.value = 0;
                item.unlocked = false;

                item.name = "Fire Rune";
                item.description = "Permanent: press O to throw a Fireball. Destroys some walls Costs 4 Magic.";
                item.currency = Currency.Gold;
                item.price = 5;
            }
            if (item.ID == 2)
            {
                item.displayed = false;

                item.value = 0;
                item.unlocked = false;

                item.name = "Ice Rune";
                item.description = "Permanent: press Down and O to unleash a Frost Wave. Freezes bodies of water. Costs 3 Magic.";
                item.currency = Currency.Gold;
                item.price = 5;
            }
            if (item.ID == 3)
            {
                item.displayed = false;

                item.value = 0;
                item.unlocked = false;

                item.name = "Wind Rune";
                item.description = "Permanent: able to jump while in air once by pressing space bar. Costs 1 magic.";
                item.currency = Currency.Gold;
                item.price = 5;
            }
            if (item.ID == 4)
            {
                item.displayed = false;

                item.value = 4;
                item.unlocked = false;

                item.name = "Mitril Bangil";
                item.description = "Health +4 Permanently";
                item.currency = Currency.Gold;
                item.price = 10;
            }

            if (item.ID == 5)
            {
                item.displayed = false;

                item.value = 4;
                item.unlocked = false;

                item.name = "Ruby Bracelet";
                item.description = "Magic +4 Permanently";
                item.currency = Currency.Gold;
                item.price = 10;
            }
        }
            XMLManager.ins.SaveItems();

        XMLManager.ins.PermSaveItems();
        player.MaxHealth = 12;
        player.MaxMana = 12;
        player.coin = 0;
        player.SwordDamage = 0;
        SaveLoadManager.SavePlayer(player);
        SceneManager.LoadScene(index);

    }

  
    public void Load(int index)
    {
        float[] loadedStats = SaveLoadManager.LoadPlayer();
        XMLManager.ins.LoadItems();
        XMLManager.ins.PermLoadItems();
        player.MaxHealth = loadedStats[0];
        player.MaxMana = loadedStats[1];
        player.coin = loadedStats[2];
        player.SwordDamage = loadedStats[3];
        SceneManager.LoadScene(index);

    }

}
