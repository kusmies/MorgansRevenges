using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FRSTWVE_SCRIPT : MonoBehaviour
{
    public GameObject FrostWavePrefab;
    public GameObject FrostWaveSpawn;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {


                if (Input.GetKeyDown(KeyCode.O)&& Input.GetKeyDown(KeyCode.S))
                {

                    Fire();

            Debug.Log("freeze");
                }
            




            

    }
    void Fire()
    {
        //have a bullet
        GameObject ice;

        Debug.Log("normalShot");

        //make a bullet
        ice = (Instantiate(FrostWavePrefab, FrostWaveSpawn.transform.position, transform.rotation)) as GameObject;

        //give it force
        ice.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

        //destroy after 2 seconds

        Destroy(ice, 1.5f);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "Frost" || collision.tag == "Soldier")
        {

            Destroy(gameObject);

        }

    }

}
