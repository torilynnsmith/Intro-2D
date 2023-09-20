using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    //GLOBAL VARIABLES
    public GameObject foodPrefab; //declare and set foodPrefab variable in the inspector (use the food prefab we made!)

    //Get Border Positions (so we can spawn the food within them
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight; 
    
    // Start is called before the first frame update
    void Start()
    {
        //Spawn food every 4 seconds, 3 seconds after the scene starts
        InvokeRepeating("Spawn", 3, 4); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Spawn one piece of food w/i the game's borders
    void Spawn()
    {
        //set x position b/w Left & Right borders
        int xPos = (int)Random.Range(borderLeft.position.x, borderRight.position.x);
        //randomly set the xPos of the food's position to a random integer between the x position values of the Left and right borders
        //Note that we are rounding to INTEGERS, not FLOATS
        
        //set y position b/w Bottom & Top borders
        int yPos = (int)Random.Range(borderBottom.position.y, borderTop.position.y);
        //randomly set the yPos of the food's position to a random integer between the y position values of the Bottom & Top borders

        //INSTANTIATE the food at (xPos, yPos) cooordinates
        Instantiate(foodPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);
            //Instantiate (original, position, rotation)
            //Instantiate creates a new instance of a game object. It has 3 parameters:
            //1. The name of the existing object you want to make a copy of
            //2. The position for the new object
            //3. The orientation/rotation of the new object
                //WHAT IS A QUATERNION? Quaternions represent rotation and are relatively complex.
                //We may get into them later, but just use Quaternion.identity to set them for now. This is the default. 
    }
}
