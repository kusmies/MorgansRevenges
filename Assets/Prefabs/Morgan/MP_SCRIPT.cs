using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MP_SCRIPT : MonoBehaviour
{//mana slider
    public Slider Mp;
    //mana script
    public static MP_SCRIPT mana;

    private void Awake()
    {
        //makes mana script static
        mana = this;
    }
}
