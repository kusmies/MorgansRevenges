using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LIGHTN_SCRIPT : MonoBehaviour
{

    public GameObject LightningPrefab;
    public GameObject LightningSpawn;
    bool righttrue;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        handleMovement();

        if ((Input.GetKeyDown(KeyCode.O) && Input.GetKeyDown(KeyCode.A)))
        {
            Fire();

        }


        if ((Input.GetKeyDown(KeyCode.O) && Input.GetKeyDown(KeyCode.D)))
                {
                    Fire();

                }

            

            
    }
    void handleMovement()

    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localPosition = new Vector3(3.2f, 0, 0);

        }

        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localPosition = new Vector3(-3.2f, 0, 0);

        }




    }

    void Fire()
    {
        //have a bullet
        GameObject light;

        Debug.Log("normalShot");

        //make a bullet
        light = (Instantiate(LightningPrefab, LightningSpawn.transform.position, transform.rotation)) as GameObject;


      
        //give it force
        light.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

        //destroy after 2 seconds

      Destroy(light, 1.0f);

    }


    
}
