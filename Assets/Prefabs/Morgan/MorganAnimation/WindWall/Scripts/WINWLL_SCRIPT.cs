using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WINWLL_SCRIPT : MonoBehaviour
{
    public GameObject WindWallPrefab;
    public GameObject WindWallSpawn;

    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

                if ((Input.GetKeyDown(KeyCode.O) && !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.D) && Input.GetKeyDown(KeyCode.W) && !Input.GetKeyDown(KeyCode.A)))
                {
                    Fire();
                }

        

    }
    void Fire()
    {
        //have a bullet
        GameObject wind;

        Debug.Log("normalShot");

        //make a bullet
        wind = (Instantiate(WindWallPrefab, WindWallSpawn.transform.position, transform.rotation)) as GameObject;

        //give it force
        wind.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

        //destroy after 2 seconds
        Destroy(wind, 1.0f);



    }


    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "WindWall" || collision.tag == "Soldier")
        {

            Destroy(gameObject);

        }

    }

}
