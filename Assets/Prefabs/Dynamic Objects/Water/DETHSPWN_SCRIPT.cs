using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DETHSPWN_SCRIPT : MonoBehaviour
{
    //explosion object
    public GameObject ExplosionPrefab;
    //spawning explosion
    public GameObject ExplosionSpawn;
    //item drop = true
    public bool itemdrop;


     
    //void thats tag for spawning explosion
    void SpawnExplosion()
    {

        GameObject Explosion;
        Explosion = (Instantiate(ExplosionPrefab, ExplosionSpawn.transform.position, transform.rotation)) as GameObject;

        Destroy(gameObject);

    }

    //void thats tagged to get loot drop
    
    void lootdrop()
    {
        //itemdrop = true;

    }
    
}
