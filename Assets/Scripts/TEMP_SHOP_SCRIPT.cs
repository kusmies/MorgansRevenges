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
public class TEMP_SHOP_SCRIPT : MonoBehaviour
{
    public int ITEMID;
    List<int> list = new List<int>();
    public Sprite[] itemsprites;
    public Image itemspriterenderer;
    public PLAYER_SCRIPT player;
    public Text Name, price,description;
    public bool buyonce;
    private void Awake()
    {
        Load();


    }
    void Start()
    {
        Display();

        list = new List<int>(new int[XMLManager.ins.itemDB.list.Count]);

        for (int j = 1; j < XMLManager.ins.itemDB.list.Count; j++)
        {
            for (int i = 0; i < XMLManager.ins.itemDB.list.Count; i++)
            {
                list.Add(i);
            }

            ITEMID = Random.Range(0, XMLManager.ins.itemDB.list.Count);
            int randomNumber = list[ITEMID];
            Debug.Log(randomNumber);


        }

        XMLManager.ins.LoadItems();

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
        player.MaxHealth = loadedStats[0];
        player.MaxMana = loadedStats[1];
        player.coin = loadedStats[2];
    }
    public void cost()
    {
       
        list.RemoveAt(ITEMID);


        if (buyonce == false)
        {

            foreach (ItemEntry item in XMLManager.ins.itemDB.list)
            {

         
                //makes the item if the ID equals the bronze ID and its not been obtained previously
                if (ITEMID == item.ID && item.ID ==1)
                {

                    if (player.coin >= item.price)
                    {
                        if (item.got == false)
                        {


                            Debug.Log(player.MaxHealth);

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

                 if (ITEMID == item.ID && item.ID == 2)
                {
                    if (player.coin >= item.price)
                    {
                        if (item.got == false)
                        {
                            Debug.Log(player.MaxHealth);

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

                 if (ITEMID == item.ID && item.ID == 3)
                {
                    if (player.coin >= item.price)
                    {
                        if (item.got == false)
                        {
                            Debug.Log(player.MaxHealth);

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

                 if (ITEMID == item.ID && item.ID == 4)
                {
                    if (player.coin >= item.price)
                    {
                        if (item.got == false)
                        {
                            Debug.Log(player.MaxHealth);

                            player.MaxHealth += item.value;


                            //subtracts the bronze price from the player total
                            player.coin -= item.price;
                            item.got = true;
                            XMLManager.ins.SaveItems();

                            SaveLoadManager.SavePlayer(player);
                        }
                    }

                  
                }
                if (ITEMID == item.ID && item.ID == 5)
                {
                    if (player.coin >= item.price)
                    {
                        if (item.got == false)
                        {
                            Debug.Log(player.SwordDamage);

                            player.SwordDamage += item.value;


                            //subtracts the bronze price from the player total
                            player.coin -= item.price;
                            item.got = true;
                            XMLManager.ins.SaveItems();

                            SaveLoadManager.SavePlayer(player);
                        }
                    }


                }
                if (ITEMID == item.ID && item.ID == 6)
                {
                    if (player.coin >= item.price)
                    {
                        if (item.got == false)
                        {
                            Debug.Log(player.MaxHealth);

                            player.SwordDamage += item.value;


                            //subtracts the bronze price from the player total
                            player.coin -= item.price;
                            item.got = true;
                            XMLManager.ins.SaveItems();

                            SaveLoadManager.SavePlayer(player);
                        }
                    }


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
            if (ITEMID == item.ID)
            {
                Name.text = item.name;
                price.text = "Gold: " + item.price.ToString();
                description.text = item.description.ToString();
                if (ITEMID == 5)

                {
                    itemspriterenderer.sprite = itemsprites[4];
                }
            }
            if (ITEMID == item.ID)
            {
                Name.text = item.name;
                price.text = "Gold: " + item.price.ToString();
                description.text = item.description.ToString();
                if (ITEMID == 6)

                {
                    itemspriterenderer.sprite = itemsprites[5];
                }
            }

            if (buyonce == true)
            {
                if (player.coin >= item.price)
                {
                    Name.text = "Sold Out";
                    itemspriterenderer.sprite = itemsprites[6];
                    price.text = "Please Come Again!";
                    description.text = "";
                }

                if(player.coin <item.price)
                {
                    Name.text = "Sorry you're short.";
                    price.text = "Come back with more gold!";
                    description.text = "";

                }
            }
        }

   

    }



   
}


