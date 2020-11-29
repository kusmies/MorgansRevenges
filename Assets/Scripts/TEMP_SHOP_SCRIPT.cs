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
public class TEMP_SHOP_SCRIPT : MonoBehaviour
{
    public int ITEMID;

    public Sprite[] itemsprites;
    public Image itemspriterenderer;
    public PLAYER_SCRIPT player;
    public Text Name, price,description;
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
                            item.got = true;
                            XMLManager.ins.SaveItems();

                            SaveLoadManager.SavePlayer(player);
                        }

                    }

                   

                }
                //makes the item if the ID equals the silver ID and its not been obtained previously

                else if (ITEMID == item.ID)
                {
                    if (player.coin >= item.price)
                    {
                        if (item.got == false)
                        {

                            player.MaxMana += item.value;

                            //subtracts the bronze price from the player total
                            player.coin -= item.price;
                            item.got = true;
                            XMLManager.ins.SaveItems();

                            SaveLoadManager.SavePlayer(player);
                        }
                    }
                  
                }
                //makes the item if the ID equals the steelhelm ID and its not been obtained previously

                else if (ITEMID == item.ID)
                {
                    if (player.coin >= item.price)
                    {
                        if (item.got == false)
                        {

                            player.MaxHealth += item.value;


                            //subtracts the bronze price from the player total
                            player.coin -= item.price;
                            item.got = true;
                            XMLManager.ins.SaveItems();

                            SaveLoadManager.SavePlayer(player);
                        }

                    }

                  

                }
                //makes the item if the ID equals the steelshield ID and its not been obtained previously

                else if (ITEMID == item.ID)
                {
                    if (player.coin >= item.price)
                    {
                        if (item.got == false)
                        {
                            player.MaxHealth += item.value;


                            //subtracts the bronze price from the player total
                            player.coin -= item.price;
                            item.got = true;
                            XMLManager.ins.SaveItems();

                            SaveLoadManager.SavePlayer(player);
                        }
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

    public void Display()
    {
        foreach (ItemEntry item in XMLManager.ins.itemDB.list)
        {


            //makes the item if the ID equals the bronze ID and its not been obtained previously
            if (ITEMID == item.ID)
            {
                Name.text = item.name;
                price.text = "Gold: " + item.price.ToString();
                description.text=  item.description.ToString();
                if (ITEMID == 1)

                {
                    itemspriterenderer.sprite = itemsprites[0];
                }
            }
            if (ITEMID == item.ID)
            {
                Name.text = item.name;
                price.text = "Gold: " + item.price.ToString();
                description.text =  item.description.ToString();
                if (ITEMID == 2)

                {
                    itemspriterenderer.sprite = itemsprites[1];
                }

            }
            if (ITEMID == item.ID)
            {
                Name.text = item.name;
                price.text = "Gold: " + item.price.ToString();
                description.text =  item.description.ToString();
                if (ITEMID == 3)

                {
                    itemspriterenderer.sprite = itemsprites[2];
                }
            }
            if (ITEMID == item.ID)
            {
                Name.text = item.name;
                price.text = "Gold: " + item.price.ToString();
                description.text =  item.description.ToString();
                if (ITEMID == 4)

                {
                    itemspriterenderer.sprite = itemsprites[3];
                }
            }

        }

        if (buyonce ==true)
        {
            Name.text = "Sold Out";
            itemspriterenderer.sprite = itemsprites[4];
            price.text = "Please Come Again!";
            description.text = "";
        }

    }
}

