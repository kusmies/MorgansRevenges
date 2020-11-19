using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOUR_BG_SCRIPT : MonoBehaviour
{

    PLAYER_SCRIPT playerScript;
    Transform myTran;
    Vector2 prevPlayerLocation;
    Vector2 currPlayerLocation;
    float speed = .01f;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GetComponentInParent<PLAYER_SCRIPT>();

        myTran = GetComponent<Transform>();

        prevPlayerLocation = playerScript.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currPlayerLocation = playerScript.transform.position;
        if(prevPlayerLocation.x >= currPlayerLocation.x + .1f || prevPlayerLocation.x <= currPlayerLocation.x - .1f)
        {
            if(Input.GetAxis("Horizontal") > 0)
            {
                Debug.Log("MovingRight");
                myTran.position = new Vector2(myTran.position.x + speed, myTran.position.y);
            }
            if(Input.GetAxis("Horizontal") < 0)
            {
                Debug.Log("MovingLeft");
                myTran.position = new Vector2(myTran.position.x - speed, myTran.position.y);
            }
        }

        prevPlayerLocation = currPlayerLocation;

    }
}
