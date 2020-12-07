using System.Collections;
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

            PLAYER_CONTROL.ResetTrigger("Slash");
            PLAYER_CONTROL.ResetTrigger("JumpSlash");

            PLAYER_CONTROL.SetBool("Walk", true);
            PLAYER_CONTROL.SetBool("Jump", false);
            PLAYER_CONTROL.SetBool("Crouch", false);
          

        }
        //just walk end
        //move jump
        else if (myPlayerMovement.isMoving == true && myPlayerMovement.isGrounded == false && myPlayerMovement.death == false)
        {
            PLAYER_CONTROL.SetBool("Walk", false);
            PLAYER_CONTROL.SetBool("Jump", true);
            PLAYER_CONTROL.SetBool("Crouch", false);
            PLAYER_CONTROL.ResetTrigger("Slash");

            // PLAYER_CONTROL.SetBool("JumpSlash", true);
            if (myPlayerMovement.jumpslash == true && !this.PLAYER_CONTROL.GetCurrentAnimatorStateInfo(0).IsTag("JumpSlash"))
            {

                PLAYER_CONTROL.SetTrigger("JumpSlash");



            }
             else        
            {

                PLAYER_CONTROL.ResetTrigger("JumpSlash");



            }
        }
        //move jump end
        //jump
        else if (myPlayerMovement.isMoving == false && myPlayerMovement.isGrounded == false && myPlayerMovement.death == false)
        {
            PLAYER_CONTROL.SetBool("Walk", false);
            PLAYER_CONTROL.SetBool("Jump", true);
            PLAYER_CONTROL.SetBool("Crouch", false);
            PLAYER_CONTROL.ResetTrigger("Slash");

            //   PLAYER_CONTROL.SetBool("JumpSlash", true);

            if ( myPlayerMovement.jumpslash == true && !this.PLAYER_CONTROL.GetCurrentAnimatorStateInfo(0).IsTag("JumpSlash"))
            {
               
                PLAYER_CONTROL.SetTrigger("JumpSlash");


            }
            else
            {

                PLAYER_CONTROL.ResetTrigger("JumpSlash");



            }
        }
        //jump end
        //jumpslash



        //walk slash
        else if (myPlayerMovement.isMoving == true && myPlayerMovement.isGrounded == true && myPlayerMovement.midslash == true && myPlayerMovement.death == false && !this.PLAYER_CONTROL.GetCurrentAnimatorStateInfo(0).IsTag("Slash"))
        {
            PLAYER_CONTROL.SetBool("Crouch", false);
            PLAYER_CONTROL.SetBool("Walk", true);
            PLAYER_CONTROL.SetBool("Jump", false);
            PLAYER_CONTROL.SetTrigger("Slash");
            PLAYER_CONTROL.ResetTrigger("JumpSlash");



        }
        //walk slash end

        //stand slash
        else if (myPlayerMovement.isMoving == false && myPlayerMovement.isGrounded == true && myPlayerMovement.midslash == true && myPlayerMovement.death == false && !this.PLAYER_CONTROL.GetCurrentAnimatorStateInfo(0).IsTag("Slash"))
        {
            PLAYER_CONTROL.SetBool("Crouch", false);
            PLAYER_CONTROL.SetBool("Walk", false);
            PLAYER_CONTROL.SetBool("Jump", false);
            PLAYER_CONTROL.SetTrigger("Slash");
            PLAYER_CONTROL.ResetTrigger("JumpSlash");



        }

        //stand slash end
        //jump slash





        //crouch
        else if (myPlayerMovement.crouch == true && myPlayerMovement.death == false)
        {
            PLAYER_CONTROL.SetBool("Walk", false);
            PLAYER_CONTROL.SetBool("Jump", false);
            PLAYER_CONTROL.SetBool("Slash", false);
            PLAYER_CONTROL.SetBool("Crouch", true);
            PLAYER_CONTROL.ResetTrigger("Slash");
            PLAYER_CONTROL.ResetTrigger("JumpSlash");


            if (myPlayerMovement.castingfrostWave ==true && !this.PLAYER_CONTROL.GetCurrentAnimatorStateInfo(0).IsTag("FrostWave"))
            {
                PLAYER_CONTROL.SetTrigger("FrostWave");

            }
         
        }
        //crouch end
       

        //fireball
        else if (myPlayerMovement.isMoving == false && myPlayerMovement.isGrounded == true && myPlayerMovement.castingfireball == true && myPlayerMovement.death == false && !this.PLAYER_CONTROL.GetCurrentAnimatorStateInfo(0).IsTag("Fireball"))
        {
            PLAYER_CONTROL.SetBool("Walk", false);
            PLAYER_CONTROL.SetBool("Jump", false);
            PLAYER_CONTROL.SetTrigger("Fireball");
            PLAYER_CONTROL.ResetTrigger("Slash");
            PLAYER_CONTROL.ResetTrigger("JumpSlash");

            PLAYER_CONTROL.SetBool("Crouch", false);


        }

        else if (myPlayerMovement.isMoving == false && myPlayerMovement.isGrounded == false && myPlayerMovement.castingfireball == true && myPlayerMovement.death == false && !this.PLAYER_CONTROL.GetCurrentAnimatorStateInfo(0).IsTag("Fireball"))
        {
            PLAYER_CONTROL.SetBool("Walk", false);
            PLAYER_CONTROL.SetBool("Jump", true);
            PLAYER_CONTROL.SetTrigger("Fireball");
            PLAYER_CONTROL.ResetTrigger("Slash");
            PLAYER_CONTROL.ResetTrigger("JumpSlash");

            PLAYER_CONTROL.SetBool("Crouch", false);


        }
        else if (myPlayerMovement.isMoving == true && myPlayerMovement.isGrounded == false && myPlayerMovement.castingfireball == true && myPlayerMovement.death == false && !this.PLAYER_CONTROL.GetCurrentAnimatorStateInfo(0).IsTag("Fireball"))
        {
            PLAYER_CONTROL.SetBool("Walk", false);
            PLAYER_CONTROL.SetBool("Jump", true);
            PLAYER_CONTROL.SetTrigger("Fireball");
            PLAYER_CONTROL.ResetTrigger("Slash");
            PLAYER_CONTROL.ResetTrigger("JumpSlash");

            PLAYER_CONTROL.SetBool("Crouch", false);


        }

        else if (myPlayerMovement.death ==true)
        {

            PLAYER_CONTROL.SetBool("Walk", false);
            PLAYER_CONTROL.SetBool("Jump", false);
            PLAYER_CONTROL.SetBool("Crouch", false);
            PLAYER_CONTROL.SetBool("Death", true);
            PLAYER_CONTROL.ResetTrigger("Slash");
            PLAYER_CONTROL.ResetTrigger("JumpSlash");


        }

        else if (myPlayerMovement.playerstruck ==true)

        {
            PLAYER_CONTROL.SetBool("Hit", true);
            PLAYER_CONTROL.ResetTrigger("FrostWave");
            PLAYER_CONTROL.ResetTrigger("Slash");
            PLAYER_CONTROL.ResetTrigger("JumpSlash");
            PLAYER_CONTROL.ResetTrigger("Fireball");
            PLAYER_CONTROL.SetBool("Walk", false);
            PLAYER_CONTROL.SetBool("Jump", false);
            PLAYER_CONTROL.SetBool("Crouch", false);
            PLAYER_CONTROL.SetBool("Death", false);

        }
        //fireball end




        else
        {
            PLAYER_CONTROL.SetBool("Hit", false);

            PLAYER_CONTROL.ResetTrigger("FrostWave");
            PLAYER_CONTROL.ResetTrigger("Slash");
            PLAYER_CONTROL.ResetTrigger("JumpSlash");
            PLAYER_CONTROL.ResetTrigger("Fireball");
            PLAYER_CONTROL.SetBool("Walk", false);
            PLAYER_CONTROL.SetBool("Jump", false);
            PLAYER_CONTROL.SetBool("Crouch", false);
            PLAYER_CONTROL.SetBool("Death", false);

        }
    }
}
