using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WINPUEM_SCRIPT : MonoBehaviour
{
    Transform myTran;
    public GameObject particle;
    int numPart;
    public Vector2 spawnZoneOrigin;
    public Vector2 spawnZoneBounds;
    float minXSpawn;
    float minYSpawn;
    float maxXSpawn;
    float maxYSpawn;
    // Start is called before the first frame update
    void Start()
    {
        /*
        myTran = GetComponent<Transform>();
        spawnZoneOrigin = myTran.position;
        spawnZoneBounds = new Vector2(1.5f, 3f);
        */
        numPart = Random.Range(15, 25);
        minXSpawn = spawnZoneOrigin.x - spawnZoneBounds.x;
        maxXSpawn = spawnZoneOrigin.x + spawnZoneBounds.x;
        minYSpawn = spawnZoneOrigin.y - spawnZoneBounds.y;
        maxYSpawn = spawnZoneOrigin.y + spawnZoneBounds.y;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < numPart; i++)
            {
                Vector2 spawnLocation = new Vector2(Random.Range(minXSpawn, maxXSpawn), Random.Range(minYSpawn, maxYSpawn));

                GameObject particleSpawned;

                particleSpawned = Instantiate(particle, spawnLocation, transform.rotation);
            }
        
        
        Destroy(gameObject);
    }
}
