using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    //GLOBAL VARIABLES
    public float speed = 5f; //set speed, can change in inspector
    private Vector3 target; //declare target variable, where the moving object will try to move to

    // Start is called before the first frame update
    void Start()
    {
        //set the target to the starting position of the object (it won't be moving at first)
        target = transform.position;

        
    }

    // Update is called once per frame
    void Update()
    {
        //TO DO: A CHECK TO SEE IF AN ITEM IS BEING DRAGGED OR NOT TO KEEP THIS FROM CHASING THE MOUSE POSITION

        if(Input.GetMouseButtonDown(0))
            //similar to GetKey stuff! GetMouseButtonDown only returns for the first frame the mouse button is clicked
            //0 = Left Mouse, 1 = Right Mouse
        {
            Debug.Log("click to move"); 
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //same as in our Draggable Sprite script!

            //LOCK THE Z AXIS FOR 2D GAMES
            target.z = transform.position.z; 
        }

        //MOVE THE OBJECT
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            //MoveTowards calculates a position b/w the starting position and the target position, moving there as quickly as set by the speed. 
    }
}
