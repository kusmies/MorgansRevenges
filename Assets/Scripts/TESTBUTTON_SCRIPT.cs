using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTBUTTON_SCRIPT : MonoBehaviour
{
    public int ITEMID;

    void Start()
    {
       ITEMID = Random.Range(1, 4);


    }
    public void cost()
    {

        TEMPITEMS_CLASS bronze = XMLOp.Deserialize<TEMPITEMS_CLASS>("bronze.xml");
        // Debug.Log(bronze.name);
        TEMPITEMS_CLASS silver = XMLOp.Deserialize<TEMPITEMS_CLASS>("silver.xml");
        // Debug.Log(silver.name);
        TEMPITEMS_CLASS steelhelm = XMLOp.Deserialize<TEMPITEMS_CLASS>("helm.xml");
        // Debug.Log(steelhelm.name);
        TEMPITEMS_CLASS steelshield = XMLOp.Deserialize<TEMPITEMS_CLASS>("shield.xml");

        if(ITEMID == bronze.ID)
        {
            PLAYER_SCRIPT.player.coin -= bronze.price;

            Debug.Log(bronze.name);

            ITEMID = Random.Range(1, 4);

        }

        if (ITEMID == silver.ID)
        {
            PLAYER_SCRIPT.player.coin -= silver.price;

            Debug.Log(silver.name);
            ITEMID = Random.Range(1, 4);


        }
        if (ITEMID == steelhelm.ID)
        {
            PLAYER_SCRIPT.player.coin -= steelhelm.price;
            ITEMID = Random.Range(1, 4);

            Debug.Log(steelhelm.name);

        }
        if (ITEMID == steelshield.ID)
        {
            PLAYER_SCRIPT.player.coin -= steelshield.price;
            ITEMID = Random.Range(1, 4);

            Debug.Log(steelshield.name);

        }
    }
}
