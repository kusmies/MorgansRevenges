using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPLWAL_SCRIPT : MonoBehaviour
{
    public int rowLength;
    public int columnHeight;
    public bool isExploding = false;
    public GameObject childExample;
    public GameObject[,] tileChildren;
    Transform myTran;

    // Start is called before the first frame update
    void Start()
    {
        myTran = GetComponent<Transform>();
        tileChildren = new GameObject[columnHeight, rowLength];

        for (int i = 0; i < columnHeight; i++)
        {
            for (int j = 0; j < rowLength; j++)
            {
                Vector3 childSpawn = new Vector3(j, i, 0);

                childSpawn = (childSpawn + myTran.transform.position);

                GameObject newChild = Instantiate(childExample, childSpawn, myTran.rotation);

                DTRYBLK_SCRIPT childScript = newChild.GetComponent<DTRYBLK_SCRIPT>();

                childScript.parent = GetComponent<EXPLWAL_SCRIPT>();

                tileChildren[i, j] = newChild;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isExploding)
        {
            for (int i = 0; i < columnHeight; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {

                    var childScript = tileChildren[i, j].GetComponent<DTRYBLK_SCRIPT>();

                    childScript.isDead = true;
                }
            }

            Destroy(gameObject);
        }
    }
}
