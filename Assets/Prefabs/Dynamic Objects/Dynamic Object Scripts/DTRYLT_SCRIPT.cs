using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTRYLT_SCRIPT: MonoBehaviour
{
    public int ID;
    FLOATING_FONT font;

    //destroys loot objects on player collision

     void Start()
    {
        font = GetComponent<FLOATING_FONT>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            if (font != null)
            {
                foreach (ItemEntry item in XMLManager.ins.itemDB.list)
                {

                    if (ID == item.ID)
                    {

                        font.showText(item.description);

                    }




                }
            }
            Destroy(gameObject);

        }





    }


}
