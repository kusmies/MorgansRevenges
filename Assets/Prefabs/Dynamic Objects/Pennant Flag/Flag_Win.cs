using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag_Win : MonoBehaviour
{
    // if the player collides with the flag it teleports them to the win state
    public CHASEN_SCRIPT level;
    //timer for the flags activation
    public float FlagWaveTimer;
    //timer target for the flags activation
    public float FlagWaveTimerTarget;
    //flags animator
    Animator FLAG_WIN;
    void Start()
    {
        //sets the timer target
        FlagWaveTimerTarget = 2.0f;
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

        }

        }

    void FlagRaised()
    {//when the flags raised it sets waving to true
        FLAG_WIN.SetBool("Waving", true);
    }


    void Won()
    {
        //after the timer hits the target the game changes state
        FlagWaveTimer += Time.deltaTime;
        if (FlagWaveTimer >= FlagWaveTimerTarget)
        {
            level.changeScene(4);
        }

    }
}
