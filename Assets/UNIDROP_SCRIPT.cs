using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UNIDROP_SCRIPT : MonoBehaviour
{



    public GameObject[] Object;

    // Start is called before the first frame update
    void Start()
    {
        Drop();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Drop()
    {
        foreach (GameObject objects in Object)
        {
           GameObject newobjects= Instantiate(objects) as GameObject;


        }
    }

}