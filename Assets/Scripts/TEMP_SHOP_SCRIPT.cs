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
using System.Linq;
using System;
using System.Runtime.InteropServices;

public class TEMP_SHOP_SCRIPT : MonoBehaviour
{
   public TEMP_SHOP_SCRIPT tempitemshop;
    public Image itemspriterenderer;

    public Text Name, price, description;
  

    public int ID;

 

    private int IDassigner;

    public List<int> storeslots= new List<int>();
    public static int previousitem = -1;
    public Sprite[] itemsprites;
    public PLAYER_SCRIPT player;
    public bool buyonce;
    public bool openslot;
    void Awake()
    {
        tempitemshop = this;

        Roll();


    }


   
void Start()
    {
        foreach (ItemEntry item in XMLManager.ins.itemDB.list)
        {
            if (item.ID == 1)
            {

                item.displayed = false;


            }
            if (item.ID == 2)
            {
               
            }
            if (item.ID == 3)
            {
                item.displayed = false;
               
            }
            if (item.ID == 4)
            {
                item.displayed = false;
                
            }
            if (item.ID == 5)
            {
                item.displayed = false;
              
            }
            if (item.ID == 6)
            {
                item.displayed = false;
               
            }
        }

        XMLManager.ins.LoadItems();
        ID = IDassigner;

    }

    public void Save()
    {
        XMLManager.ins.PermSaveItems();

        SaveLoadManager.SavePlayer(player);
    }

    private void Update()
    {
        ID = IDassigner;
        if (openslot == false)
        {
            Cost();
        }
    }
    public int Roll()
    { //function to find a job



        if (storeslots.Count == 0)
        { //if list is empty
            storeslots.Clear();
        }
        else
        { //if not
            IDassigner = storeslots[UnityEngine.Random.Range(0, storeslots.Count)]; //get a random

        }
        storeslots.Remove(IDassigner); //remove from list


        return IDassigner;

    }

    public void Click()
    {
        buyonce = true;
        Cost();
    }
    public void Cost()
    {

        {
            foreach (ItemEntry item in XMLManager.ins.itemDB.list)
            {

                if (ID == item.ID && item.ID == 1)
                {


                    if (item.got == false && item.displayed == false)
                    {
                        item.displayed = true;

                        openslot = true;
                        itemspriterenderer.sprite = itemsprites[0];



                        //subtracts the bronze price from the player total

                        Name.text = item.name;
                        price.text = "Gold: " + item.price.ToString();
                        description.text = item.description.ToString();


                    }
                    else if (item.got == true || item.displayed == true && buyonce == false)
                    {
                        Roll();

                    }

                    if (player.coin >= item.price && buyonce == true)
                    {
                        item.ID = 1;

                        player.MaxMana += item.value;
                        //subtracts the bronze price from the player total
                        player.coin -= item.price; 
                        Name.text = "Thank you";
                        price.text = "";
                        itemspriterenderer.sprite = itemsprites[6];

                        description.text = "Come Again";
                        item.got = true;
                        SaveLoadManager.SavePlayer(player);

                        XMLManager.ins.SaveItems();

                    }
                    if (player.coin <= item.price && buyonce == true)
                    {
                        Name.text = "You're short";
                        price.text = "";
                        description.text = "ComeBack with more money";
                        Debug.Log("readingIt");
                    }

                }

                if (ID == item.ID && item.ID == 2)
                {



                    if (item.got == false && item.displayed == false)
                    {
                        openslot = true;

                        itemspriterenderer.sprite = itemsprites[1];



                        //subtracts the bronze price from the player total
                        item.displayed = true;
                        Name.text = item.name;
                        price.text = "Gold: " + item.price.ToString();
                        description.text = item.description.ToString();
                       


                    }
                    else if (item.got == true || item.displayed == true && buyonce == false)
                    {
                        Roll();

                    }

                    if (player.coin >= item.price && buyonce == true)
                    {
                        item.ID = 2;
                        player.coin -= item.price;
                        SaveLoadManager.SavePlayer(player);

                        player.MaxMana += item.value;
                        Name.text = "Thank you";
                        price.text = "";
                        itemspriterenderer.sprite = itemsprites[6];

                        description.text = "Come Again";
                        item.got = true;

                        XMLManager.ins.SaveItems();

                    }
                    if (player.coin <= item.price && buyonce == true)
                    {
                        Name.text = "You're short";
                        price.text = "";
                        description.text = "ComeBack with more money";
                        Debug.Log("readingIt");
                    }

                }
                if (ID == item.ID && item.ID == 3)
                {


                    if (item.got == false && item.displayed == false)
                    {
                        openslot = true;
                        itemspriterenderer.sprite = itemsprites[2];



                        item.displayed = true;

                        Name.text = item.name;
                        price.text = "Gold: " + item.price.ToString();
                        description.text = item.description.ToString();
                       


                    }
                    else if (item.got == true || item.displayed == true && buyonce == false)
                    {
                        Roll();

                    }

                    if (player.coin >= item.price && buyonce == true)
                    {

                        item.ID = 3;
                        player.coin -= item.price;
                        SaveLoadManager.SavePlayer(player);

                        player.MaxHealth += item.value;
                        Name.text = "Thank you";
                        price.text = "";
                        itemspriterenderer.sprite = itemsprites[6];

                        description.text = "Come Again";
                        item.got = true;

                        XMLManager.ins.SaveItems();

                    }
                    if (player.coin <= item.price && buyonce == true)
                    {
                        Name.text = "You're short";
                        price.text = "";
                        description.text = "ComeBack with more money";
                        Debug.Log("readingIt");
                    }

                }
                if (ID == item.ID && item.ID == 4)
                {


                    if (item.got == false && item.displayed == false)
                    {
                        openslot = true;
                        itemspriterenderer.sprite = itemsprites[3];


                        item.displayed = true;


                        Name.text = item.name;
                        price.text = "Gold: " + item.price.ToString();
                        description.text = item.description.ToString();
                      



                    }
                    else if (item.got == true || item.displayed == true && buyonce == false)
                    {
                        Roll();

                    }

                    if (player.coin >= item.price && buyonce == true)
                    {

                        item.ID = 4;
                        player.coin -= item.price;
                        SaveLoadManager.SavePlayer(player);

                        player.MaxHealth += item.value;
                        Name.text = "Thank you";
                        price.text = "";
                        itemspriterenderer.sprite = itemsprites[6];

                        description.text = "Come Again";
                        item.got = true;

                        XMLManager.ins.SaveItems();

                    }
                    if (player.coin <= item.price && buyonce == true)
                    {
                        Name.text = "You're short";
                        price.text = "";
                        description.text = "ComeBack with more money";
                        Debug.Log("readingIt");
                    }
                }
                if (ID == item.ID && item.ID == 5)
                {


                    if (item.got == false && item.displayed == false)
                    {
                        openslot = true;

                        itemspriterenderer.sprite = itemsprites[4];

                        item.displayed = true;

                        Name.text = item.name;
                        price.text = "Gold: " + item.price.ToString();
                        description.text = item.description.ToString();
                       

                    }
                    else if (item.got == true || item.displayed == true && buyonce == false)
                    {
                        Roll();

                    }

                    if (player.coin >= item.price && buyonce == true)
                    {
                        item.ID = 5;
                        player.coin -= item.price;

                        player.SwordDamage += item.value;
                        Name.text = "Thank you";
                        price.text = "";
                        itemspriterenderer.sprite = itemsprites[6];

                        description.text = "Come Again";
                        item.got = true;
                        SaveLoadManager.SavePlayer(player);

                        XMLManager.ins.SaveItems();

                    }
                    if (player.coin <= item.price && buyonce == true)
                    {
                        Name.text = "You're short";
                        price.text = "";
                        description.text = "ComeBack with more money";
                        Debug.Log("readingIt");
                    }
                }
                if (ID == item.ID && item.ID == 6)
                {


                    if (item.got == false && item.displayed == false)
                    {
                        openslot = true;

                        item.displayed = true;
                        itemspriterenderer.sprite = itemsprites[5];




                        Name.text = item.name;
                        price.text = "Gold: " + item.price.ToString();
                        description.text = item.description.ToString();
                      

                    }


                    else if (item.got == true || item.displayed == true && buyonce == false)
                    {
                        Roll();

                    }

                    if (player.coin >= item.price && buyonce == true)
                    {
                        item.ID = 6;
                        player.coin -= item.price;
                        SaveLoadManager.SavePlayer(player);

                        player.SwordDamage += item.value;
                        Name.text = "Thank you";
                        price.text = "";
                        itemspriterenderer.sprite = itemsprites[6];

                        description.text = "Come Again";
                        item.got = true;

                        XMLManager.ins.SaveItems();

                    }
                    if (player.coin <= item.price && buyonce == true)
                    {
                        Name.text = "You're short";
                        price.text = "";
                        description.text = "ComeBack with more money";
                        Debug.Log("readingIt");
                    }

                }





            }

            }


        }
    }





 

