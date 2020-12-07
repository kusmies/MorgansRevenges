using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DFACT2_HANDLER_SCRIPT : MonoBehaviour
{
    public LANCEL_SCRIPT lancelot;
    public PLAYER_SCRIPT morgan;
    public Vector2 playerPosition;
    public bool lancelotDefeated = false;
    public CHASEN_SCRIPT sceneChangeScript;
    // Start is called before the first frame update
    void Start()
    {
        sceneChangeScript = GetComponent<CHASEN_SCRIPT>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector2(morgan.transform.position.x, morgan.transform.position.y);

        if (!lancelotDefeated)
        {

        }
        else
        {
            
        }
    }

    public void endScene()
    {
        XMLManager.ins.SaveItems();
        SaveLoadManager.SavePlayer(morgan);
        XMLManager.ins.PermSaveItems();
        sceneChangeScript.changeScene(3);
    }
}
