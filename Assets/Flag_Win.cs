using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag_Win : MonoBehaviour
{
    public CHASEN_SCRIPT level;

    Animator FLAG_WIN;
    void Start()
    {
        FLAG_WIN = GetComponent<Animator>();
    }

        private void OnTriggerEnter2D(Collider2D collision)
    
        {

        if (collision.tag == "Player" || collision.tag == "Win")
        {
            FLAG_WIN.SetBool("Raise", true);

        }

        }

    void FlagRaised()
    {
        FLAG_WIN.SetBool("Waving", true);
    }


    void Won()
    {
        level.changeScene(4);

    }
}
