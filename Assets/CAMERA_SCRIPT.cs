using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAMERA_SCRIPT : MonoBehaviour
{
    Transform myTran;
    public Transform parentTran;
    public int type; //1 is act 1, 2 is act 2
    // Start is called before the first frame update
    void Start()
    {
        myTran = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (type == 1)
        {
            myTran.position = new Vector3(parentTran.position.x, 20f, myTran.position.z);

            if (myTran.position.x < 24f)
            {
                myTran.position = new Vector3(24f, 20f, myTran.position.z);
            }

            if (myTran.position.x > 391f)
            {
                myTran.position = new Vector3(391f, 20f, myTran.position.z);
            }
        }
        else if (type == 2)
        {
            myTran.position = new Vector3(parentTran.position.x, 20f, myTran.position.z);

            if (myTran.position.x < -21.46f)
            {
                myTran.position = new Vector3(-21.46f, 20f, myTran.position.z);
            }

            if (myTran.position.x > 23.17f)
            {
                myTran.position = new Vector3(23.17f, 20f, myTran.position.z);
            }
        }
    }
}
