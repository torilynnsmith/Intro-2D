using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatSpawn : MonoBehaviour
{
    //GLOBAL VARIABLES
    public GameObject foodPrefab; //declare and set foodPrefab in the inspector

    //Get Border Positions (so we can spawn food within them)
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight; 

    // Start is called before the first frame update
    void Start()
    {
        //Spawn food every 5 seconds, 3 secs after the scene starts.
        InvokeRepeating("Spawn", 3, 5); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Spawn one piece of food
    void Spawn()
    {
        //Debug.Log("Spawn Function called"); //print to the console

        //set x position b/w Left & Right borders.
        int xPos = (int)Random.Range(borderLeft.position.x+10, borderRight.position.x-10);
        //Debug.Log("xPos =" + xPos);

        //set y position b/w Top & Bottom borders.
        int yPos = (int)Random.Range(borderBottom.position.y + 10, borderTop.position.y - 10);
        //Debug.Log("yPos = " + yPos);

        //INSTANTIATE a new food prefab at (xPos,yPos) coordinates
        Instantiate(foodPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);
    }
}
