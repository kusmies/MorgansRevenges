using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UNIDROP_SCRIPT : MonoBehaviour
{
    public int ID;
    public bool object1;
    public bool object2;
    public bool object3;
    public bool object4;
    public bool lootfinallydropped;
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;
     void Awake()
    {
        ID = Random.Range(1, 4);

    }

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        Drop();


    }

    void Drop()
    {
        if (lootfinallydropped == false)
        {
            if (ID == 1 && object1 == true)
            {
                Instantiate(item1);
                lootfinallydropped = true;
            }
            if (ID == 2 && object2 == true)
            {
                Instantiate(item2);
                lootfinallydropped = true;
            }
            if (ID == 3 && object3 == true)
            {
                Instantiate(item3);
                lootfinallydropped = true;
            }
            if (ID == 4 && object4 == true)
            {
                Instantiate(item4);
                lootfinallydropped = true;
            }


        }
        else
        {
            ID = Random.Range(1, 4);

        }

    }

}