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

public class PERM_SHOP_SCRIPT : MonoBehaviour
{
    public int ID;


    public Sprite[] itemsprites;
    public Image itemspriterenderer;
    public PLAYER_SCRIPT player;
    public Text Name, price, description, playergold;
    public bool buyonce;

    private void Awake()
    {

    }
    void Start()
    {
        Display();

        XMLManager.ins.PermLoadItems();


        ID = Random.Range(1, XMLManager.ins.PitemDB.list.Count);


        Load();
        Debug.Log(player.coin);
    }
    void Update()
    {
        Display();
    }

    public void Save()
    {
        XMLManager.ins.PermSaveItems();

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
            foreach (PermItemEntry permitem in XMLManager.ins.PitemDB.list)
            {

                if (ID == permitem.ID && permitem.ID == 1)
                {
                    if (player.coin >= permitem.price)
                    {
                        if (permitem.unlocked == false)
                        {

                            player.MaxHealth += permitem.value;

                            player.coin -= permitem.price;
                            ID = 6;
                            permitem.unlocked = true;
                            XMLManager.ins.PermSaveItems();

                            SaveLoadManager.SavePlayer(player);
                        }




                    }

                }

                if (ID == permitem.ID && permitem.ID == 2)
                {
                    if (player.coin >= permitem.price)
                    {
                        if (permitem.unlocked == false)
                        {


                            player.MaxHealth += permitem.value;
                            //subtracts the bronze price from the player total
                            player.coin -= permitem.price;
                            ID = 6;
                            permitem.unlocked = true;
                            XMLManager.ins.PermSaveItems();

                            SaveLoadManager.SavePlayer(player);
                        }



                    }
                }

                if (ID == permitem.ID && permitem.ID == 3)
                {
                    if (player.coin >= permitem.price)
                    {
                        if (permitem.unlocked == false)
                        {


                            player.MaxHealth += permitem.value;
                            //subtracts the bronze price from the player total
                            player.coin -= permitem.price;
                            ID = 6;
                            permitem.unlocked = true;
                            XMLManager.ins.PermSaveItems();

                            SaveLoadManager.SavePlayer(player);
                        }



                    }
                }
                if (ID == permitem.ID && permitem.ID == 4)
                {
                    if (player.coin >= permitem.price)
                    {
                        if (permitem.unlocked == false)
                        {


                            player.MaxHealth += permitem.value;
                            //subtracts the bronze price from the player total
                            player.coin -= permitem.price;
                            ID = 6;
                            permitem.unlocked = true;
                            XMLManager.ins.PermSaveItems();

                            SaveLoadManager.SavePlayer(player);
                        }


                    }

                }

                if (ID == permitem.ID && permitem.ID == 5)
                {
                    if (player.coin >= permitem.price)
                    {
                        if (permitem.unlocked == false)
                        {


                            player.MaxMana += permitem.value;
                            //subtracts the bronze price from the player total
                            player.coin -= permitem.price;
                            ID = 6;
                            permitem.unlocked = true;
                            XMLManager.ins.PermSaveItems();

                            SaveLoadManager.SavePlayer(player);
                        }


                    }

                }


                buyonce = true;

            }







        }


        if (ID == 6)
        {


            Debug.Log("SoldOut");
        }

    }



    




    public void Display()
    {
        playergold.text = "Your Money " + player.coin.ToString();
        foreach (PermItemEntry permitem in XMLManager.ins.PitemDB.list)
        {
            if (ID == permitem.ID)
            {
                Name.text = permitem.name;
                price.text = "Gold: " + permitem.price.ToString();
                description.text = permitem.description.ToString();
                if (ID == 1)

                {
                    itemspriterenderer.sprite = itemsprites[0];
                }
            }
            if (ID == permitem.ID)
            {
                Name.text = permitem.name;
                price.text = "Gold: " + permitem.price.ToString();
                description.text = permitem.description.ToString();
                if (ID == 2)

                {
                    itemspriterenderer.sprite = itemsprites[1];
                }
            }
            if (ID == permitem.ID)
            {
                Name.text = permitem.name;
                price.text = "Gold: " + permitem.price.ToString();
                description.text = permitem.description.ToString();
                if (ID == 3)

                {
                    itemspriterenderer.sprite = itemsprites[2];
                }

               
            }

            if (ID == permitem.ID)
            {
                Name.text = permitem.name;
                price.text = "Gold: " + permitem.price.ToString();
                description.text = permitem.description.ToString();
                if (ID == 4)

                {
                    itemspriterenderer.sprite = itemsprites[3];
                }


            }
            if (ID == permitem.ID)
            {
                Name.text = permitem.name;
                price.text = "Gold: " + permitem.price.ToString();
                description.text = permitem.description.ToString();
                if (ID == 5)

                {
                    itemspriterenderer.sprite = itemsprites[4];
                }


            }
            if (buyonce == true)
            {
                if (player.coin >= permitem.price)
                {
                    Name.text = "Sold Out";
                    itemspriterenderer.sprite = itemsprites[5];
                    price.text = "Please Come Again!";
                    description.text = "";
                }

                if (player.coin < permitem.price)
                {
                    Name.text = "Sorry you're short.";
                    price.text = "Come back with more gold!";
                    description.text = "";

                }
            }

        }
    }
    }



       

     
    
