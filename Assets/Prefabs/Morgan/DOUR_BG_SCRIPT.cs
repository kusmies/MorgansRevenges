using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOUR_BG_SCRIPT : MonoBehaviour
{
    public float parallaxEffect;
    public GameObject player;
    Transform myTran;
    Transform playerTran;
    Vector3 lastPlayerPosition;

    private void Start()
    {
        playerTran = player.GetComponent<Transform>();
        myTran = GetComponent<Transform>();
        lastPlayerPosition = playerTran.position;

    }

    private void LateUpdate()
    {
        if (playerTran.position.x < lastPlayerPosition.x - .1f)
        {

            myTran.position = new Vector3(myTran.position.x - parallaxEffect, myTran.position.y, myTran.position.z);
        }
        else if (playerTran.position.x > lastPlayerPosition.x + .1f)
        {

            myTran.position = new Vector3(myTran.position.x + parallaxEffect, myTran.position.y, myTran.position.z);
        }
        lastPlayerPosition = playerTran.position;
    }
}
