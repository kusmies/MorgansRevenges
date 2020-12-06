using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag_Win : MonoBehaviour
{
    //flags animator
    Animator FLAG_WIN;

    public DFACT1_HANDLER_SCRIPT actManager; //The level manager. We need to give it updates when the player touches the flag.


    void Start()
    {
        //animator for the flag
        FLAG_WIN = GetComponent<Animator>();
    }

        private void OnTriggerEnter2D(Collider2D collision)
    
        {

        //collider between player and flag
        if (collision.tag == "Player" || collision.tag == "Win")
        {
            //sets raise to true
            FLAG_WIN.SetBool("Raise", true);
            actManager.levelComplete = true; //tell the level manager tht the level is over so it can stop enemies.

        }

        }

    void FlagRaised()
    {//when the flags raised it sets waving to true
        FLAG_WIN.SetBool("Waving", true);
    }


    void Won()
    {
        actManager.moveToDourFieldsAct2(); //Tell the level manager to move into the next scene
    }
}
