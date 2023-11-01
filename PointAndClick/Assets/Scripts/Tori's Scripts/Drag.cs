using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    //NOTE: Your draggable sprites/game objects must have COLLIDERS!
    //This script lives on the object you are dragging

    //GLOBAL VARIABLES
    private bool isDragging = false; //set true/false variable to check if the object is currently being dragged or not.
    private Vector3 offset; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if the object is being dragged
        if (isDragging)
        {
            Debug.Log("isDragging");
            //move the object with the mouse (take into account original offset)
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
                //Get the Main Camera object
                //Screen To World Point: Transforms a point from "screen space" into "world space". Needs a Vector 3.
                //Use the Input system (event system) to get the current mousePosition. This will be your Vector3 for ScreenToWorldPoint

                //NOTE: w/o the offset variable, the player would have to click in the exact center of the draggable object to get it to move.
                //The offset variable account for that error! 
        }
    }

    //Drag
    private void OnMouseDown() //OnMouseDown is called when the mouse button is pressed over a UI element or collider
    {
        //Record the difference b/w the draggable object's center and the clicked point on the camera's view
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        isDragging = true; //set bool to true, the object is currently being dragged

    }

    //Stop Dragging
    private void OnMouseUp() //OnMouseUp is called when the mouse button is released
    {
        isDragging = false; //set bool to false, the object is no longer being dragged
    }

    //Other things you might want to do with a draggable sprite!
        //Keep the draggable sprites w/i the game scene using colliders as borders or hardcoding it in (like pong!)
        //when the player drags a sprite into a certain area, do something! (change points, change scenes, destroy the sprite and make a new one, etc.)
        //On Trigger Enter and On Collision will be your friends here!

    //There is another drag scripting object that uses raycasting. We're not going to worry about that during this class, but if you're curious I'll send you a tutorial
}
