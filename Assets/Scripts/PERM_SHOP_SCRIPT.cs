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
    public PERM_SHOP_SCRIPT permitemshop;
    public Image itemspriterenderer;


    public List<int> storeslots = new List<int>();



    private int IDassigner;

    public Sprite[] itemsprites;
    public PLAYER_SCRIPT player;
    public Text Name, price, description;
    public bool buyonce;
    public bool openslot;

    private void Awake()
    {
        Roll();
        permitemshop = this;
    }
    void Start()
    {
        foreach (PermItemEntry item in XMLManager.ins.PitemDB.list)
        {
            if (item.ID == 1)
            {
                item.displayed = false;
            }
            if (item.ID == 2)
            {
                item.displayed = false;
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
         
        }

        XMLManager.ins.PermLoadItems();


        ID = IDassigner;


        Load();
        Debug.Log(player.coin);
    }
    void Update()
    {
        ID = IDassigner;
        if (openslot == false)
        {
            Cost();
        }
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

    public int Roll()
    { //function to find a job



        if (storeslots.Count == 0)
        { //if list is empty
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
            foreach (PermItemEntry item in XMLManager.ins.PitemDB.list)
            {

                if (ID == item.ID && item.ID == 1)
                {


                    if (item.unlocked == false && item.displayed == false)
                    {
                        item.displayed = true;

                        openslot = true;
                        itemspriterenderer.sprite = itemsprites[0];


                        XMLManager.ins.PermSaveItems();

                        //subtracts the bronze price from the player total

                        Name.text = item.name;
                        price.text = "Gold: " + item.price.ToString();
                        description.text = item.description.ToString();


                    }
                    else if (item.unlocked == true || item.displayed == true && buyonce == false)
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
                        itemspriterenderer.sprite = itemsprites[5];

                        description.text = "Come Again";
                        item.unlocked = true;
                        SaveLoadManager.SavePlayer(player);

                        XMLManager.ins.PermSaveItems();

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



                    if (item.unlocked == false && item.displayed == false)
                    {
                        openslot = true;

                        itemspriterenderer.sprite = itemsprites[1];



                        //subtracts the bronze price from the player total
                        item.displayed = true;
                        Name.text = item.name;
                        price.text = "Gold: " + item.price.ToString();
                        description.text = item.description.ToString();



                    }
                    else if (item.unlocked == true || item.displayed == true && buyonce == false)
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
                        itemspriterenderer.sprite = itemsprites[5];

                        description.text = "Come Again";
                        item.unlocked = true;

                        XMLManager.ins.PermSaveItems();

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


                    if (item.unlocked == false && item.displayed == false)
                    {
                        openslot = true;
                        itemspriterenderer.sprite = itemsprites[2];



                        item.displayed = true;

                        Name.text = item.name;
                        price.text = "Gold: " + item.price.ToString();
                        description.text = item.description.ToString();



                    }
                    else if (item.unlocked == true || item.displayed == true && buyonce == false)
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
                        itemspriterenderer.sprite = itemsprites[5];

                        description.text = "Come Again";
                        item.unlocked = true;

                        XMLManager.ins.PermSaveItems();

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


                    if (item.unlocked == false && item.displayed == false)
                    {
                        openslot = true;
                        itemspriterenderer.sprite = itemsprites[3];


                        item.displayed = true;


                        Name.text = item.name;
                        price.text = "Gold: " + item.price.ToString();
                        description.text = item.description.ToString();




                    }
                    else if (item.unlocked == true || item.displayed == true && buyonce == false)
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
                        itemspriterenderer.sprite = itemsprites[5];

                        description.text = "Come Again";
                        item.unlocked = true;

                        XMLManager.ins.PermSaveItems();

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


                    if (item.unlocked == false && item.displayed == false)
                    {
                        openslot = true;

                        itemspriterenderer.sprite = itemsprites[4];

                        item.displayed = true;

                        Name.text = item.name;
                        price.text = "Gold: " + item.price.ToString();
                        description.text = item.description.ToString();


                    }
                    else if (item.unlocked == true || item.displayed == true && buyonce == false)
                    {
                        Roll();

                    }

                    if (player.coin >= item.price && buyonce == true)
                    {
                        item.ID = 5;
                        player.coin -= item.price;

                        player.MaxMana += item.value;
                        Name.text = "Thank you";
                        price.text = "";
                        itemspriterenderer.sprite = itemsprites[5];

                        description.text = "Come Again";
                        item.unlocked = true;
                        SaveLoadManager.SavePlayer(player);

                        XMLManager.ins.PermSaveItems();

                    }
                    if (player.coin <= item.price && buyonce == true)
                    {
                        Name.text = "You're short";
                        price.text = "";
                        description.text = "ComeBack with more money";
                        Debug.Log("readingIt");
                    }
                }
               


                if (storeslots.Count== 0)
                {
                    Name.text = "Sold Out";
                    price.text = "";
                    itemspriterenderer.sprite = itemsprites[5];

                    description.text = "Our Apologies";
                }



            }

        }


    }
}
    



       

     
    
