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
                item.chestdropped = false;
                item.name = "BronzeRing";
                item.description = "A bronze ring that increases mana by one.";
                item.currency = Currency.Gold;
                item.price = 2;
            }
            if (item.ID == 2)
            {
                item.value = 2;
                item.got = false;
                item.chestdropped = false;

                item.name = "SilverRing";
                item.description = "A silver ring that increases mana by two.";
                item.currency = Currency.Gold;
                item.price = 4;
            }
            if (item.ID == 3)
            {
                item.value = 1;
                item.got = false;
                item.chestdropped = false;

                item.name = "SteelHelm";
                item.description = "A steel helmet that increases health by one.";

                item.currency = Currency.Gold;
                item.price = 2;
            }
            if (item.ID == 4)
            {
                item.value = 2;
                item.got = false;
                item.chestdropped = false;
                item.name = "SteelShield";
                item.description = "A steel shield that increases health by two.";
                item.currency = Currency.Gold;
                item.price = 4;
            }


            if (item.ID == 5)
            {
                item.value = 1;
                item.got = false;
                item.chestdropped = false;
                item.name = "Dagger";
                item.description = "A dagger that increases the players damage by one.";
                item.currency = Currency.Gold;
                item.price = 2;
            }
            if (item.ID == 6)
            {
                item.value = 2;
                item.got = false; 
                item.chestdropped = false;
                item.name = "Long Sword";
                item.description = "A  long sword that increases the players damage by two.";

                item.currency = Currency.Gold;
                item.price = 4;
            }
        }

        foreach (PermItemEntry item in XMLManager.ins.PitemDB.list)
        {
            if(item.ID ==1)
            {
                item.value = 0;
                item.unlocked = false;

                item.name = "FireRune";
                item.description = "A rune crackiling with magic, unlocks the fireball uses the O key to fire. This item is permanent.";
                item.currency = Currency.Gold;
                item.price = 5;
            }
            if (item.ID == 2)
            {
                item.value = 0;
                item.unlocked = false;

                item.name = "IceRune";
                item.description = "A rune ice cold with arcanic energy, unlocks the frost wave uses the S key and  O key to summon it. This item is permanent.";
                item.currency = Currency.Gold;
                item.price = 5;
            }

            if (item.ID == 3)
            {
                item.value = 4;
                item.unlocked = false;

                item.name = "MithrilBangil";
                item.description = "An enchanted Bangil that makes the user feel stronger.This item is permanent.";
                item.currency = Currency.Gold;
                item.price = 10;
            }

            if (item.ID == 4)
            {
                item.value = 4;
                item.unlocked = false;

                item.name = "ruby bracelet";
                item.description = "A bracelet empowered by magic. This item is permanent.";
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
