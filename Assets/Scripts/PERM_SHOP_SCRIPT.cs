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
    public SHOPSCENEMANAGER_SCRIPT scenemanager;
    public int ID;
    public PERM_SHOP_SCRIPT permitemshop;
    public Image itemspriterenderer;
    bool checkedonce;
    

    public List<int> storeslots = new List<int>();



    private int IDassigner;

    public Sprite[] itemsprites;
    public PLAYER_SCRIPT player;
    string Name, price, description;
    public bool buyonce;
    public bool openslot;

    private void Awake()
    {
        permitemshop = this;

        Roll();
        Load();
        foreach (PermItemEntry item in XMLManager.ins.PitemDB.list)
        {
            if (item.ID == 1)
            {
                item.displayed = false;
                XMLManager.ins.PermSaveItems();

            }
            if (item.ID == 2)
            {
                item.displayed = false;
                XMLManager.ins.PermSaveItems();

            }
            if (item.ID == 3)
            {
                item.displayed = false;
                XMLManager.ins.PermSaveItems();

            }
            if (item.ID == 4)
            {
                item.displayed = false;
                XMLManager.ins.PermSaveItems();

            }
            if (item.ID == 5)
            {
                item.displayed = false;
                XMLManager.ins.PermSaveItems();

            }

        }
    }
    void Start()
    {

        XMLManager.ins.PermLoadItems();

        ID = IDassigner;

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
        player.MaxHealth = loadedStats[0];
        player.MaxMana = loadedStats[1];
        player.coin = loadedStats[2];
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
        
            scenemanager.Name.text = Name;
            scenemanager.Price.text = price;
            scenemanager.Description.text = description;
        gameObject.GetComponent<Button>().interactable = false;


    }
    public void Cost()
    {
        {
            foreach (PermItemEntry item in XMLManager.ins.PitemDB.list)
            {

                if (ID == item.ID && item.ID == 1)
                {


                    if (item.unlocked == false  && item.displayed == false)
                    {
                        item.displayed = true;

                        openslot = true;
                        itemspriterenderer.sprite = itemsprites[0];


                        XMLManager.ins.PermSaveItems();

                        //subtracts the bronze price from the player total

                        Name = item.name;
                        price = "Gold: " + item.price.ToString();
                        description= item.description.ToString();


                    }
                    else if (item.unlocked == true || item.displayed == true && buyonce == false)
                    {
                        Roll();

                    }

                    if (player.coin >= item.price && buyonce == true && item.ID == 1)
                    {

                        player.MaxMana += item.value;
                        //subtracts the bronze price from the player total
                        player.coin -= item.price;
                        Name = "Thank you";
                        price = "";
                        itemspriterenderer.sprite = itemsprites[5];

                        description = "Come Again";
                        item.unlocked = true;

                        XMLManager.ins.PermSaveItems();
                        SaveLoadManager.SavePlayer(player);


                    }
                    if (player.coin <= item.price && buyonce == true)
                    {
                        Name = "You're short";
                        price = "";
                        description = "Come back with more money";
                    }

                }

                if (ID == item.ID && item.ID == 2)
                {



                    if (item.unlocked == false && item.displayed == false)
                    {
                        item.displayed = true;

                        openslot = true;

                        itemspriterenderer.sprite = itemsprites[1];

                        XMLManager.ins.PermSaveItems();


                        //subtracts the bronze price from the player total
                        Name = item.name;
                        price = "Gold: " + item.price.ToString();
                        description = item.description.ToString();



                    }
                    else if (item.unlocked == true || item.displayed == true && buyonce == false)
                    {
                        Roll();

                    }

                    if (player.coin >= item.price || buyonce == true && item.ID == 2)
                    {
                        player.coin -= item.price;

                        player.MaxMana += item.value;
                        Name= "Thank you";
                        price= "";
                        itemspriterenderer.sprite = itemsprites[5];

                        description = "Come Again";
                        item.unlocked = true;

                        XMLManager.ins.PermSaveItems();
                        SaveLoadManager.SavePlayer(player);


                    }
                    if (player.coin <= item.price && buyonce == true)
                    {
                        Name = "You're short";
                        price = "";
                        description = "Come back with more money";
                    }

                }
                if (ID == item.ID && item.ID == 3)
                {


                    if (item.unlocked == false && item.displayed == false)
                    {
                        item.displayed = true;

                        openslot = true;
                        itemspriterenderer.sprite = itemsprites[2];

                        XMLManager.ins.PermSaveItems();



                        Name= item.name;
                        price = "Gold: " + item.price.ToString();
                        description = item.description.ToString();



                    }
                    else if (item.unlocked == true || item.displayed == true && buyonce == false)
                    {
                        Roll();

                    }

                    if (player.coin >= item.price && buyonce == true && item.ID ==3)
                    {

                        player.coin -= item.price;

                        player.MaxHealth += item.value;
                        Name = "Thank you";
                        price = "";
                        itemspriterenderer.sprite = itemsprites[5];

                        description = "Come Again";
                        item.unlocked = true;

                        XMLManager.ins.PermSaveItems();
                        SaveLoadManager.SavePlayer(player);


                    }
                    if (player.coin <= item.price && buyonce == true)
                    {
                        Name = "You're short";
                        price = "";
                        description = "Come back with more money";
                    }

                }
                if (ID == item.ID && item.ID == 4)
                {


                    if (item.unlocked == false && item.displayed == false)
                    {
                        item.displayed = true;

                        openslot = true;
                        itemspriterenderer.sprite = itemsprites[3];

                        XMLManager.ins.PermSaveItems();



                        Name = item.name;
                        price = "Gold: " + item.price.ToString();
                        description = item.description.ToString();




                    }
                    else if (item.unlocked == true || item.displayed == true && buyonce == false)
                    {
                        Roll();

                    }

                    if (player.coin >= item.price && buyonce == true && item.ID == 4)
                    {

                        player.coin -= item.price;

                        player.MaxHealth += item.value;
                        Name= "Thank you";
                        price = "";
                        itemspriterenderer.sprite = itemsprites[5];

                        description = "Come Again";
                        item.unlocked = true;

                        XMLManager.ins.PermSaveItems();
                        SaveLoadManager.SavePlayer(player);

                    }
                    if (player.coin <= item.price && buyonce == true)
                    {
                        Name = "You're short";
                        price = "";
                        description = "ComeBack with more money";
                    }
                }
                if (ID == item.ID && item.ID == 5)
                {


                    if (item.unlocked == false && item.displayed == false)
                    {
                        item.displayed = true;

                        openslot = true;

                        itemspriterenderer.sprite = itemsprites[4];
                        XMLManager.ins.PermSaveItems();


                        Name= item.name;
                        price= "Gold: " + item.price.ToString();
                        description = item.description.ToString();


                    }
                    else if (item.unlocked == true || item.displayed == true && buyonce == false)
                    {
                        Roll();

                    }

                    if (player.coin >= item.price && buyonce == true && item.ID == 5)
                    {
                        item.ID = 5;
                        player.coin -= item.price;

                        player.MaxMana += item.value;
                        Name = "Thank you";
                        price = "";
                        itemspriterenderer.sprite = itemsprites[5];

                        
                        description = "Come Again";
                        item.unlocked = true;
                        SaveLoadManager.SavePlayer(player);

                        XMLManager.ins.PermSaveItems();

                    }
                    if (player.coin <= item.price && buyonce == true)
                    {
                        Name = "You're short";
                        price = "";
                        description = "ComeBack with more money";
                        Debug.Log("readingIt");
                    }
                }

               if(storeslots.Count ==0)
                {
                    Debug.Log("procked");
                    Name = "We're out of that";
                    price = "";
                    description = "Come back later";
                }
            }
       



        }


    }
    public void Whenhovered()
    {
        scenemanager.Name.text = Name;
        scenemanager.Price.text = price;
        scenemanager.Description.text = description;


    }

}
    



       

     
    
