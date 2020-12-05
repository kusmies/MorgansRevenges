using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DFACT2_HANDLER_SCRIPT : MonoBehaviour
{
    public LANCEL_SCRIPT lancelot;
    public PLAYER_SCRIPT morgan;
    public Vector2 playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector2 (morgan.transform.position.x, morgan.transform.position.y);
    }
}
