using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine.UI;

public class UNIDROP_SCRIPT : MonoBehaviour
{

    public DropDatabase items;
    Transform spawn;
    bool isdead;
    int ID;

     bool droppedonce;
    void Awake()
    {
        ID = Random.Range(1, (items.list.Count));
       
    }

    private void Start()
    {
        spawn = GetComponent<Transform>();
    }



    public void Drop()
    {
         if (droppedonce == false)
            {
                droppedonce = true;
                foreach (DropList item in items.list)
                {
                    if (item.ID == ID)
                    {
                        Instantiate(item.dropped, spawn.transform.position, transform.rotation);
                    

                }

            }
            }
        
    }




    [System.Serializable]

    public class DropList
    {
        public int ID;
        public GameObject dropped;

    }

    [System.Serializable]
    public class DropDatabase
    {
        public List<DropList> list = new List<DropList>();
    }
}