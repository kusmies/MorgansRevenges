using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DFACT1_HANDLER_SCRIPT : MonoBehaviour
{
    public PLAYER_SCRIPT morgan;
    CHASEN_SCRIPT sceneChanger;
    public bool levelComplete = false;
    // Start is called before the first frame update
    void Start()
    {
        sceneChanger = GetComponent<CHASEN_SCRIPT>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveToDourFieldsAct2()
    {
        sceneChanger.changeScene(5);
    }
}
