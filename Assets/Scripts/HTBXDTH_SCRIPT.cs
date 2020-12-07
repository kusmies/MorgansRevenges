using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTBXDTH_SCRIPT : MonoBehaviour
{
    //variables for the timer
    public float timer;
    public float timerTarget;

    // Start is called before the first frame update
    void Start()
    {
        timerTarget = 0.6f;

    }

    // Update is called once per frame
    void Update()
    {
        //how timer goes up
        timer += Time.deltaTime;


        //triggers to explode if timer reaches timer target
        if (timer >= timerTarget)
        {
            //have a bullet


            //make a bullet

            //give it force

            //destroy after 0.8f seconds
            Destroy(gameObject, 0.8f);
            timer = 0.0f;
        }


    }



    //triggers early if it hits an enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {

            Destroy(gameObject);

          
        }
        
        if (collision.gameObject.CompareTag("Loot"))
        {
            Destroy(gameObject);

            

 
        }
    }

}
