using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;
using System.Xml.Linq;
//using UnityEditor.Build.Content;
using System.Runtime.Serialization;
using JetBrains.Annotations;
using UnityEngine.UI;
public class SHOP_SCRIPT : MonoBehaviour
{
    public int ITEMID;
    public PLAYER_SCRIPT player;
    public Text Name, price, gold;
    public bool buyonce;

    private void Awake()
    {
        
    }
    void Start()
    {
        Display();
        XMLManager.ins.LoadItems();
        ITEMID = Random.Range(1, 5);

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


       if (buyonce == false)
        {

            foreach (ItemEntry item in XMLManager.ins.itemDB.list)
            {

          
                //makes the item if the ID equals the bronze ID and its not been obtained previously
                if (ITEMID == item.ID)
                {

                    if (player.coin >= item.price)
                    {
                        if (item.got == false)
                        {


                            player.MaxMana += item.value;
                            //subtracts the bronze price from the player total
                            player.coin -= item.price;
                             ITEMID = 6;
                            item.got = true;
                            XMLManager.ins.SaveItems();

                            SaveLoadManager.SavePlayer(player);
                        }

                    }

                    else
                    {
                        ITEMID = 6;
                    }

                }
                //makes the item if the ID equals the silver ID and its not been obtained previously

                else if (ITEMID == item.ID)
                {
                    if (player.coin >= item.price)
                    {
                        if (item.got == false)
                        {

                            ITEMID = 6;
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
                        ITEMID = 6;
                    }
                }
                //makes the item if the ID equals the steelhelm ID and its not been obtained previously

                else if (ITEMID == item.ID)
                {
                    if (player.coin >= item.price)
                    {
                        if (item.got == false)
                        {
                             ITEMID = 6;

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
                        ITEMID = 6;
                    }

                }
                //makes the item if the ID equals the steelshield ID and its not been obtained previously

                else if (ITEMID == item.ID)
                {
                    if (player.coin >= item.price)
                    {
                        if (item.got == false)
                        {
                            ITEMID = 6;
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
                        ITEMID = 6;
                    }

                }
                else
                {
                    Debug.Log("cant buy");

                }

                buyonce = true;

            }
        }

       if(ITEMID ==6)
        {


            Debug.Log("SoldOut");
        }

    }

    public void Display()
    {
        gold.text = "Gold: " + player.coin.ToString();

        foreach (ItemEntry item in XMLManager.ins.itemDB.list)
        {


            //makes the item if the ID equals the bronze ID and its not been obtained previously
            if (ITEMID == item.ID)
            {
                Name.text = item.name;
                price.text = "Cost: " + item.price.ToString();

            }
            if (ITEMID == item.ID)
            {
                Name.text = item.name;
                price.text = "Cost: " + item.price.ToString();

            }
            if (ITEMID == item.ID)
            {
                Name.text = item.name;
                price.text = "Cost: " + item.price.ToString();

            }
            if (ITEMID == item.ID)
            {
                Name.text = item.name;
                price.text = "Cost: " + item.price.ToString();

            }

            

        }

        if (ITEMID == 6)
        {
            Name.text = "Sold Out";
            price.text = "Please Come Again!";

        }

    }
}

