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

            if (myTran.position.x < 30f)
            {
                myTran.position = new Vector3(30f, 20f, myTran.position.z);
            }

            if (myTran.position.x > 385f)
            {
                myTran.position = new Vector3(385f, 20f, myTran.position.z);
            }
        }
        else if (type == 2)
        {
            myTran.position = new Vector3(parentTran.position.x, 20f, myTran.position.z);

            if (myTran.position.x < -15.46f)
            {
                myTran.position = new Vector3(-15.46f, 20f, myTran.position.z);
            }

            if (myTran.position.x > 17.17f)
            {
                myTran.position = new Vector3(17.17f, 20f, myTran.position.z);
            }
        }
    }
}
