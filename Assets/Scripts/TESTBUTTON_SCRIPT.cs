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

public class TESTBUTTON_SCRIPT : MonoBehaviour
{
    public int ITEMID;
    public int id,price;
    public string Name;
    
    
    

    private void Awake()
    {
        
    }
    void Start()
    {
        XMLManager.ins.LoadItems();
        ITEMID = Random.Range(1, 5);


    }


    public void cost()
    {
        
        




        ITEMID = Random.Range(1, 5);
        foreach (ItemEntry item in XMLManager.ins.itemDB.list)
        {
            //makes the item if the ID equals the bronze ID and its not been obtained previously
            if (ITEMID ==item.ID)
            {

                if (item.got == false)
                {
                    Debug.Log(item.ID);
                    Debug.Log(item.price);
                    Debug.Log(item.name);
                    Debug.Log(item.ID);


                    //subtracts the bronze price from the player total
                    PLAYER_SCRIPT.player.coin -= item.price;
                }
                item.got = true;
                XMLManager.ins.SaveItems();



            }
            //makes the item if the ID equals the silver ID and its not been obtained previously
            
            else if (ITEMID == item.ID)
            {
                /*
                Debug.Log(item.ID);
                Debug.Log(item.price);
                Debug.Log(item.name);
                Debug.Log(item.ID);
                */

            }
            //makes the item if the ID equals the steelhelm ID and its not been obtained previously

            else if (ITEMID == item.ID)
            {/*
                Debug.Log(item.ID);
                Debug.Log(item.price);
                Debug.Log(item.name);
                Debug.Log(item.ID);
                */


            }
            //makes the item if the ID equals the steelshield ID and its not been obtained previously

            else if (ITEMID == item.ID)
            {/*
                Debug.Log(item.ID);
                Debug.Log(item.price);
                Debug.Log(item.name);
                Debug.Log(item.ID);
                */

            }
            else
            {
                Debug.Log("cant buy");
            }
            
        }
    }

}

