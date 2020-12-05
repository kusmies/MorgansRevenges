using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHESTDROP_SCRIPT : MonoBehaviour
{
    public Transform spawn;
    public GameObject[] items;
    public PLAYER_SCRIPT player;
    int ID;

    bool droppedonce;
    void Awake()
    {
        ID = Random.Range(1, 6);

    }





    public void Drop()
    {
        if (droppedonce == false)
        {
            droppedonce = true;
            foreach (ItemEntry item in XMLManager.ins.itemDB.list)
            {

                if (ID == item.ID && item.ID == 1)
                {


                    if (item.got == false && item.chestdropped ==false)
                    {



                        //subtracts the bronze price from the player total
                        item.chestdropped = true;
                        XMLManager.ins.SaveItems();

                        Instantiate(items[0], spawn.transform.position, spawn.transform.rotation);
                    }
                   else if (item.got == true || item.chestdropped == true)
                    {
                        Instantiate(items[6], spawn.transform.position, spawn.transform.rotation);

                    }

                }

                if (ID == item.ID && item.ID == 2)
                {


                    if (item.got == false && item.chestdropped == false)
                    {



                        //subtracts the bronze price from the player total
                        item.chestdropped = true;
                        XMLManager.ins.SaveItems();
                        Instantiate(items[1], spawn.transform.position, spawn.transform.rotation);


                    }
                 else   if (item.got == true || item.chestdropped == true)
                    {
                        Instantiate(items[6], spawn.transform.position, spawn.transform.rotation);

                    }

                }
                if (ID == item.ID && item.ID == 3)
                {


                    if (item.got == false && item.chestdropped == false)
                    {



                        //subtracts the bronze price from the player total
                        item.chestdropped = true;
                        XMLManager.ins.SaveItems();
                        Instantiate(items[2], spawn.transform.position, spawn.transform.rotation);

                    }
                 else   if (item.got == true || item.chestdropped == true)
                    {
                        Instantiate(items[6], spawn.transform.position, spawn.transform.rotation);

                    }

                }
                if (ID == item.ID && item.ID == 4)
                {


                    if (item.got == false && item.chestdropped == false)
                    {



                        //subtracts the bronze price from the player total
                        item.chestdropped = true;
                        XMLManager.ins.SaveItems();
                        Instantiate(items[3], spawn.transform.position, spawn.transform.rotation);

                    }
                    else if (item.got == true || item.chestdropped == true)
                    {
                        Instantiate(items[6], spawn.transform.position, spawn.transform.rotation);

                    }

                }
                if (ID == item.ID && item.ID == 5)
                {


                    if (item.got == false && item.chestdropped == false)
                    {



                        //subtracts the bronze price from the player total
                        item.chestdropped = true;
                        XMLManager.ins.SaveItems();
                        Instantiate(items[4], spawn.transform.position, spawn.transform.rotation);

                    }
                  else  if (item.got == true || item.chestdropped == true)
                    {
                        Instantiate(items[6], spawn.transform.position, spawn.transform.rotation);

                    }

                }
                if (ID == item.ID && item.ID == 6)
                {


                    if (item.got == false && item.chestdropped == false)
                    {



                        //subtracts the bronze price from the player total
                        item.chestdropped = true;
                        XMLManager.ins.SaveItems();
                        Instantiate(items[5], spawn.transform.position, spawn.transform.rotation);

                    }


                   else if(item.got ==true || item.chestdropped ==true)
                    {
                        Instantiate(items[6], spawn.transform.position, spawn.transform.rotation);

                    }

                }




            }

        }
    }



}
