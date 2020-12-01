using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WATBOD_SCRIPT : MonoBehaviour
{
    public int rowLength;
    public int columnHeight;
    public bool isFrozen = false;
    public GameObject childExample1; // Subsurface water
    public GameObject childExample2; // Surface water. Spawn this .7 units above the final row
    public GameObject[,] tileChildren1; //The 2D array that holds all of the subsurface water.
    public GameObject[] tileChildren2; //The regular array that holds the surface of the water.
    Transform myTran;

    // Start is called before the first frame update
    void Start()
    {
        myTran = GetComponent<Transform>(); //Get the transform of the parent.
        tileChildren1 = new GameObject[columnHeight, rowLength]; //Make a 2d array based on the column height and row length.

        for (int i = 0; i < columnHeight; i++) //A weird for loop that makes all of the tile children. We iterate for every point in the column.
        {
            for (int j = 0; j < rowLength; j++) //And for every point in the column we iterate for every point in the row.
            {
                Vector3 childSpawn = new Vector3(j, i, 0); //The location of the tile child that we are currently working on. Note that we use i and j from the for loop to help us place the tile in the game scene.

                childSpawn = (childSpawn + myTran.transform.position); //One final adjustment to the spawn location based on the actual location of the parent.

                GameObject newChild = Instantiate(childExample1, childSpawn, myTran.rotation); //Now we instantiate a child. If only it were that easy.

                WATSUB_SCRIPT childScript = newChild.GetComponent<WATSUB_SCRIPT>(); //Before we let the child go off on his own we need to store that child's script into a temporary variable.

                childScript.parent = GetComponent<WATBOD_SCRIPT>(); //We also remind that child who was the parent that birthed it.

                tileChildren1[i, j] = newChild; //And finally, we add the child to the 2d array based on i and j.
            }
        }
    }

    void Update()
    {
        if (isFrozen) 
        {
            for (int i = 0; i < columnHeight; i++) //For every point of the column height
            {
                for (int j = 0; j < rowLength; j++) //For every point of the column width
                {
                    
                    var childScript = tileChildren1[i, j].GetComponent<WATSUB_SCRIPT>(); 

                    childScript.isFrozen = true;
                }
            }
            
        }
    }



}
