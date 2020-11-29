using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;
using System.Xml.Linq;
using UnityEditor.Build.Content;
using System.Runtime.Serialization;
using JetBrains.Annotations;
using UnityEngine.UI;

public class PERM_SHOP_SCRIPT : MonoBehaviour
{
    public int PERMITEMID;

    public int TEMPITEMID;

    public Sprite[] itemsprites;
    public Image itemspriterenderer;
    public PLAYER_SCRIPT player;
    public Text Name, price, description,playergold;
    public bool buyonce;

    private void Awake()
    {

    }
    void Start()
    {
        Display();

        XMLManager.ins.PermLoadItems();

        XMLManager.ins.LoadItems();

        PERMITEMID = 1;

        TEMPITEMID = Random.Range(1, 5);

        Load();
        Debug.Log(player.coin);
    }
    void Update()
    {
        Display();
    }

    public void Save()
    {
        XMLManager.ins.SaveItems();
        SaveLoadManager.SavePlayer(player);
    }
    public void Load()
    {
        float[] loadedStats = SaveLoadManager.LoadPlayer();

        player.coin = loadedStats[2];
    }
    public void cost()
    {
        foreach (PermItemEntry permitem in XMLManager.ins.PitemDB.list)
        {

            if(PERMITEMID == permitem.ID)
            {
                if (player.coin >= permitem.price)
                {
                    if (permitem.unlocked == false)
                    {


                        player.MaxMana += permitem.value;
                        //subtracts the bronze price from the player total
                        player.coin -= permitem.price;
                        TEMPITEMID = 6;
                        permitem.unlocked = true;
                        XMLManager.ins.PermSaveItems();

                        SaveLoadManager.SavePlayer(player);
                    }

                }


            }



            if (buyonce == false && permitem.unlocked ==true)
            {

                foreach (ItemEntry item in XMLManager.ins.itemDB.list)
                {


                    //makes the item if the ID equals the bronze ID and its not been obtained previously
                    if (TEMPITEMID == item.ID)
                    {

                        if (player.coin >= item.price)
                        {
                            if (item.got == false)
                            {


                                player.MaxMana += item.value;
                                //subtracts the bronze price from the player total
                                player.coin -= item.price;
                                TEMPITEMID = 6;
                                item.got = true;
                                XMLManager.ins.SaveItems();

                                SaveLoadManager.SavePlayer(player);
                            }

                        }

                        else
                        {
                            TEMPITEMID = 6;
                        }

                    }
                    //makes the item if the ID equals the silver ID and its not been obtained previously

                    else if (TEMPITEMID == item.ID)
                    {
                        if (player.coin >= item.price)
                        {
                            if (item.got == false)
                            {

                                TEMPITEMID = 6;
                                player.MaxMana += item.value;

                                //subtracts the bronze price from the player total
                                player.coin -= item.price;
                                item.got = true;
                                XMLManager.ins.SaveItems();

                                SaveLoadManager.SavePlayer(player);
                            }
                        }
                        else
                        {
                            TEMPITEMID = 6;
                        }
                    }
                    //makes the item if the ID equals the steelhelm ID and its not been obtained previously

                    else if (TEMPITEMID == item.ID)
                    {
                        if (player.coin >= item.price)
                        {
                            if (item.got == false)
                            {
                                TEMPITEMID = 6;

                                player.MaxHealth += item.value;


                                //subtracts the bronze price from the player total
                                player.coin -= item.price;
                                item.got = true;
                                XMLManager.ins.SaveItems();

                                SaveLoadManager.SavePlayer(player);
                            }

                        }

                        else
                        {
                            TEMPITEMID = 6;
                        }

                    }
                    //makes the item if the ID equals the steelshield ID and its not been obtained previously

                    else if (TEMPITEMID == item.ID)
                    {
                        if (player.coin >= item.price)
                        {
                            if (item.got == false)
                            {
                                TEMPITEMID = 6;
                                player.MaxHealth += item.value;


                                //subtracts the bronze price from the player total
                                player.coin -= item.price;
                                item.got = true;
                                XMLManager.ins.SaveItems();

                                SaveLoadManager.SavePlayer(player);
                            }
                        }

                        else
                        {
                            TEMPITEMID = 6;
                        }

                    }
                    else
                    {
                        Debug.Log("cant buy");

                    }

                    buyonce = true;

                }
            }
        }

        if (TEMPITEMID == 6)
        {


            Debug.Log("SoldOut");
        }

    }

    public void Display()
    {
        playergold.text = player.coin.ToString();
        foreach (PermItemEntry permitem in XMLManager.ins.PitemDB.list)
        {
            if (PERMITEMID == permitem.ID)
            {
                Name.text = permitem.name;
                price.text = "Gold: " + permitem.price.ToString();
                description.text = permitem.description.ToString();
                if (PERMITEMID == 1)

                {
                    itemspriterenderer.sprite = itemsprites[0];
                }
            }

            foreach (ItemEntry item in XMLManager.ins.itemDB.list)
            {


                //makes the item if the ID equals the bronze ID and its not been obtained previously
                if (TEMPITEMID == item.ID &&permitem.unlocked == true)
                {
                    Name.text = item.name;
                    price.text = "Gold: " + item.price.ToString();
                    description.text = item.description.ToString();
                    if (TEMPITEMID == 1)

                    {
                        itemspriterenderer.sprite = itemsprites[1];
                    }
                }
                if (TEMPITEMID == item.ID && permitem.unlocked == true)
                {
                    Name.text = item.name;
                    price.text = "Gold: " + item.price.ToString();
                    description.text = item.description.ToString();
                    if (TEMPITEMID == 2)

                    {
                        itemspriterenderer.sprite = itemsprites[2];
                    }

                }
                if (TEMPITEMID == item.ID && permitem.unlocked == true)
                {
                    Name.text = item.name;
                    price.text = "Gold: " + item.price.ToString();
                    description.text = item.description.ToString();
                    if (TEMPITEMID == 3)

                    {
                        itemspriterenderer.sprite = itemsprites[3];
                    }
                }
                if (TEMPITEMID == item.ID && permitem.unlocked == true)
                {
                    Name.text = item.name;
                    price.text = "Gold: " + item.price.ToString();
                    description.text = item.description.ToString();
                    if (TEMPITEMID == 4)

                    {
                        itemspriterenderer.sprite = itemsprites[4];
                    }
                }

            }

            if (buyonce==true )
            {
                Name.text = "Sold Out";
                itemspriterenderer.sprite = itemsprites[5];
                price.text = "Please Come Again!";
                description.text = "";
            }

        }
    }
}
