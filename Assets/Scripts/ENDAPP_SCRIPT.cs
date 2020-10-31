using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENDAPP_SCRIPT : MonoBehaviour
{
    //A public function that ends the application. It needs to be attached to something in the current scene in order to run.
    public void endGame()
    {
        Application.Quit();
    }

}
