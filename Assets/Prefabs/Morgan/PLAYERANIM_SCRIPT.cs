﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYERANIM_SCRIPT : MonoBehaviour
{
  Animator PLAYER_CONTROL;
    PLAYER_SCRIPT myPlayerMovement;

    // Start is called before the first frame update
    void Start()
    {
        PLAYER_CONTROL = GetComponent<Animator>();
        myPlayerMovement = GetComponent<PLAYER_SCRIPT>();
    }

    // Update is called once per frame
    void Update()
    {
        //just walk
        if (myPlayerMovement.isMoving == true && myPlayerMovement.isGrounded == true && myPlayerMovement.midslash == false && myPlayerMovement.death == false)
        {
            PLAYER_CONTROL.SetBool("Walk", true);
            PLAYER_CONTROL.SetBool("Jump", false);
            PLAYER_CONTROL.SetBool("Slash", false);
            PLAYER_CONTROL.SetBool("Crouch", false);


        }
        //just walk end
        //move jump
        else if (myPlayerMovement.isMoving == true && myPlayerMovement.isGrounded == false && myPlayerMovement.death == false)
        {
            PLAYER_CONTROL.SetBool("Walk", false);
            PLAYER_CONTROL.SetBool("Jump", true);
            PLAYER_CONTROL.SetBool("Crouch", false);


        }
        //move jump end
        //jump
        else if (myPlayerMovement.isMoving == false && myPlayerMovement.isGrounded == false && myPlayerMovement.death == false)
        {
            PLAYER_CONTROL.SetBool("Walk", false);
            PLAYER_CONTROL.SetBool("Jump", true);
            PLAYER_CONTROL.SetBool("Crouch", false);


        }
        //jump end
        //jumpslash



        //walk slash
        else if (myPlayerMovement.isMoving == true && myPlayerMovement.isGrounded == true && myPlayerMovement.midslash == true && myPlayerMovement.death == false)
        {
            PLAYER_CONTROL.SetBool("Crouch", false);
            PLAYER_CONTROL.SetBool("Walk", true);
            PLAYER_CONTROL.SetBool("Jump", false);
            PLAYER_CONTROL.SetBool("Slash", true);



        }
        //walk slash end

        //stand slash
        else if (myPlayerMovement.isMoving == false && myPlayerMovement.isGrounded == true && myPlayerMovement.midslash == true && myPlayerMovement.death == false)
        {
            PLAYER_CONTROL.SetBool("Crouch", false);
            PLAYER_CONTROL.SetBool("Walk", false);
            PLAYER_CONTROL.SetBool("Jump", false);
            PLAYER_CONTROL.SetBool("Slash", true);



        }

        //stand slash end
        //jump slash
        else if (myPlayerMovement.isMoving == false && myPlayerMovement.isGrounded == false && myPlayerMovement.midslash == true && myPlayerMovement.death == false)
        {
            PLAYER_CONTROL.SetBool("Crouch", false);
            PLAYER_CONTROL.SetBool("Walk", false);
            PLAYER_CONTROL.SetBool("Jump", true);
            PLAYER_CONTROL.SetBool("Slash", true);



        }

        //crouch
        else if (myPlayerMovement.crouch == true && myPlayerMovement.death == false)
        {
            PLAYER_CONTROL.SetBool("Walk", false);
            PLAYER_CONTROL.SetBool("Jump", false);
            PLAYER_CONTROL.SetBool("Slash", false);
            PLAYER_CONTROL.SetBool("Crouch", true);



        }
        //crouch end
    
        //fireball
        else if (myPlayerMovement.isMoving == false && myPlayerMovement.isGrounded == true && myPlayerMovement.castingfireball == true && myPlayerMovement.death == false)
        {
            PLAYER_CONTROL.SetBool("Walk", false);
            PLAYER_CONTROL.SetBool("Jump", false);
            PLAYER_CONTROL.SetBool("Fireball", true);

            PLAYER_CONTROL.SetBool("Crouch", false);


        }

        else if (myPlayerMovement.isMoving == false && myPlayerMovement.isGrounded == false && myPlayerMovement.castingfireball == true && myPlayerMovement.death == false)
        {
            PLAYER_CONTROL.SetBool("Walk", false);
            PLAYER_CONTROL.SetBool("Jump", true);
            PLAYER_CONTROL.SetBool("Fireball", true);

            PLAYER_CONTROL.SetBool("Crouch", false);


        }
        else if (myPlayerMovement.isMoving == true && myPlayerMovement.isGrounded == false && myPlayerMovement.castingfireball == true && myPlayerMovement.death == false)
        {
            PLAYER_CONTROL.SetBool("Walk", false);
            PLAYER_CONTROL.SetBool("Jump", true);
            PLAYER_CONTROL.SetBool("Fireball", true);

            PLAYER_CONTROL.SetBool("Crouch", false);


        }

        else if (myPlayerMovement.death ==true)
        {

            PLAYER_CONTROL.SetBool("Walk", false);
            PLAYER_CONTROL.SetBool("Jump", false);
            PLAYER_CONTROL.SetBool("Crouch", false);
            PLAYER_CONTROL.SetBool("Slash", false);
            PLAYER_CONTROL.SetBool("Death", true);
            PLAYER_CONTROL.SetBool("Fireball", false);
        }
        //fireball end




        else
        {
            PLAYER_CONTROL.SetBool("Walk", false);
            PLAYER_CONTROL.SetBool("Jump", false);
            PLAYER_CONTROL.SetBool("Crouch", false);
            PLAYER_CONTROL.SetBool("Slash", false);
            PLAYER_CONTROL.SetBool("Death", false);
            PLAYER_CONTROL.SetBool("Fireball", false);

        }
    }
}
