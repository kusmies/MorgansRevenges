using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
public class UNIDROP_SCRIPT : MonoBehaviour
{

    public DropDatabase items;
    public int ID, Max;

    public bool droppedonce;
    void Awake()
    {
        ID = Random.Range(0, Max);

    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        Drop();


    }

    void Drop()
    {
        if (droppedonce == false)
        {
            droppedonce = true;
            foreach (DropList item in items.list)
            {
                if (item.ID == ID)
                {
                    Instantiate(item.dropped);
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