using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//By Timothy Phillips
//Copyright November 2020
//This script handles the behavior for the explodable wall parent object.
//This parent object links with all of the tiles connected to it. So when
//one tile is hit by the fireball spell it sends a signal to this object,
//which then sends a signal to all the tile children to explode.
//The real gimmick to this script is how you can set the wall's size (how many tiles)
//in the inspector panel, making adjustments for level design fairly quick.
//The only limitation is that we are restricted to square shaped walls, but that's hardly a limitation.

public class EXPLWAL_SCRIPT : MonoBehaviour 
{
    public int rowLength; //The length of our tile rows
    public int columnHeight; //The height of our tile columns
    public bool isExploding = false; //This is flipped to true when any of the children are hit by a fireball explosion.
    public GameObject childExample; //We need an example of the tile that we are making a bunch of.
    public GameObject[,] tileChildren; //The 2D array that holds all of our dear children.
    Transform myTran; //This object's transform. We need it to place our children in the correct spots.


    // Start is called before the first frame update
    void Start()
    {
        myTran = GetComponent<Transform>(); //Get the transform of the parent.
        tileChildren = new GameObject[columnHeight, rowLength]; //Make a 2d array based on the column height and row length.

        for (int i = 0; i < columnHeight; i++) //A weird for loop that makes all of the tile children. We iterate for every point in the column.
        {
            for (int j = 0; j < rowLength; j++) //And for every point in the column we iterate for every point in the row.
            {
                Vector3 childSpawn = new Vector3(j, i, 0); //The location of the tile child that we are currently working on. Note that we use i and j from the for loop to help us place the tile in the game scene.

                childSpawn = (childSpawn + myTran.transform.position); //One final adjustment to the spawn location based on the actual location of the parent.

                GameObject newChild = Instantiate(childExample, childSpawn, myTran.rotation); //Now we instantiate a child. If only it were that easy.

                DTRYBLK_SCRIPT childScript = newChild.GetComponent<DTRYBLK_SCRIPT>(); //Before we let the child go off on his own we need to store that child's script into a temporary variable.

                childScript.parent = GetComponent<EXPLWAL_SCRIPT>(); //We also remind that child who was the parent that birthed it.

                tileChildren[i, j] = newChild; //And finally, we add the child to the 2d array based on i and j.
            }
        }
    }

    // Update is called once per frame
    void Update() //Our update function is pretty simple
    {
        if (isExploding) //If we are exploding we start exploding all of the children. The isExploding bool is set by a child who was hit by a fireball explosion.
        {
            for (int i = 0; i < columnHeight; i++) //For every point of the column height
            {
                for (int j = 0; j < rowLength; j++) //For every point of the column width
                {

                    var childScript = tileChildren[i, j].GetComponent<DTRYBLK_SCRIPT>(); //We find the destructible block script of the child located at this point in the 2d array and store in a temporary variable.

                    childScript.isDead = true; //Then we tell it to die.
                }
            }

            Destroy(gameObject); //Once we've gone through every child and told it to kill itself, the parent then finishes the gruesome function by destroying itself too.
        }
    }
}
