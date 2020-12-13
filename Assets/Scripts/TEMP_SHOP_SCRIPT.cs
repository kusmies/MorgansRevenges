using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.Build.Content;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class TEMP_SHOP_SCRIPT : MonoBehaviour
{
    public SHOPSCENEMANAGER_SCRIPT scenemanager;
    public TEMP_SHOP_SCRIPT tempitemshop;
    public Image itemspriterenderer;

   string Name, price, description;


    public int ID;



    private int IDassigner;

    public List<int> storeslots = new List<int>();
    public static int previousitem = -1;
    public Sprite[] itemsprites;
    public PLAYER_SCRIPT player;
    public bool buyonce;
    public bool openslot;
    void Awake()
    {
        tempitemshop = this;
        Load();
        Roll();


    }



    void Start()
    {
 
        XMLManager.ins.PermLoadItems();

        XMLManager.ins.LoadItems();
        ID = IDassigner;

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
        scenemanager.Name.text = Name;
        scenemanager.Price.text = price;
        scenemanager.Description.text = description;
        gameObject.GetComponent<Button>().interactable = false;
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

                        Name = item.name.ToString();
                        price= "Gold: " + item.price.ToString();
                        description= item.description.ToString();


                    }
                    else if (item.got == true || item.displayed == true && buyonce == false)
                    {
                        Roll();

                    }

                    if (player.coin >= item.price && buyonce == true && item.ID == 1)

                    {
                        Name = "Thank you";
                        price = "";
                        description = "Come Again";

                        player.MaxMana += item.value;
                        //subtracts the bronze price from the player total
                        player.coin -= item.price;

                        itemspriterenderer.sprite = itemsprites[6];

                        item.got = true;

                        XMLManager.ins.SaveItems();
                        SaveLoadManager.SavePlayer(player);


                    }
                    if (player.coin <= item.price && buyonce == true)
                    {
                        Name = "You're short";
                        price = "";
                        description = "ComeBack with more money";
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

                        Name = item.name.ToString();
                        price = "Gold: " + item.price.ToString();
                        description = item.description.ToString();



                    }
                    else if (item.got == true || item.displayed == true && buyonce == false)
                    {
                        Roll();

                    }

                    if (player.coin >= item.price && buyonce == true && item.ID == 2)
                    {
                        Name = "Thank you";
                        price = "";
                        description = "Come Again";
                        player.coin -= item.price;

                        player.MaxMana += item.value;

                        itemspriterenderer.sprite = itemsprites[6];

                        item.got = true;

                        XMLManager.ins.SaveItems();
                        SaveLoadManager.SavePlayer(player);

                    }
                    if (player.coin <= item.price && buyonce == true)
                    {
                        Name = "You're short";
                        price = "";
                        description = "ComeBack with more money";
                    }

                }
                if (ID == item.ID && item.ID == 3)
                {


                    if (item.got == false && item.displayed == false)
                    {
                        openslot = true;
                        itemspriterenderer.sprite = itemsprites[2];



                        item.displayed = true;


                        Name= item.name.ToString();
                        price = "Gold: " + item.price.ToString();
                        description = item.description.ToString();



                    }
                    else if (item.got == true || item.displayed == true && buyonce == false)
                    {
                        Roll();

                    }

                    if (player.coin >= item.price && buyonce == true && item.ID == 3)
                    {
                        Name = "Thank you";
                        price = "";
                        description = "Come Again";
                        player.coin -= item.price;

                        player.MaxHealth += item.value;

                        itemspriterenderer.sprite = itemsprites[6];

                        item.got = true;

                        XMLManager.ins.SaveItems();
                        SaveLoadManager.SavePlayer(player);

                    }
                    if (player.coin <= item.price && buyonce == true)
                    {
                        Name = "You're short";
                        price = "";
                        description = "ComeBack with more money";
                    }

                }
                if (ID == item.ID && item.ID == 4)
                {


                    if (item.got == false && item.displayed == false)
                    {
                        openslot = true;
                        itemspriterenderer.sprite = itemsprites[3];


                        item.displayed = true;



                        Name = item.name.ToString();
                        price= "Gold: " + item.price.ToString();
                        description = item.description.ToString();



                    }
                    else if (item.got == true || item.displayed == true && buyonce == false)
                    {
                        Roll();

                    }

                    if (player.coin >= item.price && buyonce == true && item.ID == 4)
                    {
                        Name = "Thank you";
                        price = "";
                        description = "Come Again";
                        player.coin -= item.price;

                        player.MaxHealth += item.value;

                        itemspriterenderer.sprite = itemsprites[6];


                        item.got = true;

                        XMLManager.ins.SaveItems();
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


                    if (item.got == false && item.displayed == false)
                    {
                        openslot = true;

                        itemspriterenderer.sprite = itemsprites[4];

                        item.displayed = true;



                        Name = item.name.ToString();
                        price= "Gold: " + item.price.ToString();
                        description = item.description.ToString();

                    }
                    else if (item.got == true || item.displayed == true && buyonce == false)
                    {
                        Roll();

                    }

                    if (player.coin >= item.price && buyonce == true && item.ID == 5)
                    {
                        Name = "Thank you";
                        price = "";
                        description = "Come Again";
                        item.ID = 5;
                        player.coin -= item.price;

                        player.SwordDamage += item.value;

                        itemspriterenderer.sprite = itemsprites[6];

                        item.got = true;

                        XMLManager.ins.SaveItems();
                        SaveLoadManager.SavePlayer(player);

                    }
                    if (player.coin <= item.price && buyonce == true)
                    {

                        Name = "You're short";
                        price = "";
                        description = "ComeBack with more money";
                    }
                }
                if (ID == item.ID && item.ID == 6)
                {


                    if (item.got == false && item.displayed == false)
                    {
                        openslot = true;

                        item.displayed = true;
                        itemspriterenderer.sprite = itemsprites[5];




                        Name= item.name.ToString();
                        price = "Gold: " + item.price;
                        description = item.description;

                    }


                    else if (item.got == true || item.displayed == true && buyonce == false)
                    {
                        Roll();

                    }

                    if (player.coin >= item.price && buyonce == true && item.ID == 6)
                    {
                        Name = "Thank you";
                        price = "";
                        description = "Come Again";
                        player.coin -= item.price;

                        player.SwordDamage += item.value;

                        itemspriterenderer.sprite = itemsprites[6];

                        item.got = true;

                        XMLManager.ins.SaveItems();
                        SaveLoadManager.SavePlayer(player);

                    }
                    if (player.coin <= item.price && buyonce == true)
                    {
                        Name = "You're short";
                        price = "";
                        description = "ComeBack with more money";
                    }

                }


                if (ID == item.ID && item.ID == 7)
                {


                    if (item.got == false && item.displayed == false)
                    {
                        openslot = true;

                        item.displayed = true;
                        itemspriterenderer.sprite = itemsprites[7];




                        Name = item.name.ToString();
                        price = "Gold: " + item.price;
                        description = item.description;

                    }


                    else if (item.got == true || item.displayed == true && buyonce == false)
                    {
                        Roll();

                    }

                    if (player.coin >= item.price && buyonce == true && item.ID == 7)
                    {
                        Name = "Thank you";
                        price = "";
                        description = "Come Again";
                        player.coin -= item.price;

                        player.speedup += item.value;

                        itemspriterenderer.sprite = itemsprites[6];

                        item.got = true;

                        XMLManager.ins.SaveItems();
                        SaveLoadManager.SavePlayer(player);

                    }
                    if (player.coin <= item.price && buyonce == true)
                    {
                        Name = "You're short";
                        price = "";
                        description = "ComeBack with more money";
                        description = "ComeBack with more money";
                    }

                }


            }

        }


    }
    public void Whenhovered()
    {
        scenemanager.Name.text = Name;
        scenemanager.Price.text = price;
        scenemanager.Description.text = description;
        Debug.Log("Mouse is over GameObject.");

    }
}







