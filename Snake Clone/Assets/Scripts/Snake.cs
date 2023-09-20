using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Linq; 

public class Snake : MonoBehaviour
{
    //GLOBAL VARIABLES
    Vector3 dir = Vector3.right; //decare default movement direction
        //Remember the difference b/w Vector2(x,y) & Vector3(x,y,z)
        //there is shorthand for Vector2/3 directions.
        //In this one, Vector3.right = Vector3(1,0,0), moving it to the RIGHT

    // Start is called before the first frame update
    void Start()
    {
        //Call MoveSnake() every 300ms(0.3 seconds) to move the snake
        InvokeRepeating("MoveSnake", 0.3f, 0.3f);
        //InvokeRepeating("methodName", time, repeatRate)
            //methodName: name of method/function to invoke
            //time: start invoking after n seconds
            //repeatRate: repeat after every n seconds.

    }

    // Update is called once per frame
    void Update()
    {
        //NOTE: if we did movement in update, it would go SUPER FAST, so let's call it on a delay in Start()

        //Change the Snake's direction by calling ChangeDirection(), detecting key presses all the time
        ChangeDirection(); //It's nice to keep chunks of code like this in their own functions, just like we did with the Pong Player Paddles
    }

    //Make the Snake move
    void MoveSnake()
    {
        //Debug.Log("MoveSnake called"); //print to console

        //In Snake, the snake is ALWAYS moving in some direction, never standing still.
        //Move the snake head into a new direction
        transform.Translate(dir);
            //Translate moves the transform property in the direction and distance of the translation,
            //In this case, we are moving in the whatever direction we've set the dir variable to be
    }

    //Change the Snakes movement direction when a Key is pressed
    private void ChangeDirection()
    {
        //Debug.Log("Change Direction called"); //print to console

        //MOVE RIGHT
        if (Input.GetKey(KeyCode.RightArrow)) //if the Right Arrow is continuously pressed down, then...
        {
            dir = Vector3.right; //change the direction to RIGHT
            //Debug.Log("direction = right"); //print to console
        }
        //MOVE LEFT
        else if (Input.GetKey(KeyCode.LeftArrow)) //if the Left Arrow is continuously pressed down, then...
        {
            dir = Vector3.left; //change the direction to LEFT
                                //NOTE: this could also be written as dir = - Vector3.right, "-right" = left
            //Debug.Log("direction = left"); //print to console
        }
        //MOVE UP
        else if (Input.GetKey(KeyCode.UpArrow)) //if the Up Arrow is continuously pressed down, then...
        {
            dir = Vector3.up; //change the direction to UP
            //Debug.Log("direction = up"); //print to console
        }
        //MOVE DOWN
        else if (Input.GetKey(KeyCode.DownArrow)) //if the Down Arrow is continuously pressed down, then...
        {
            dir = Vector3.down; //change the direction to DOWN
            //Debug.Log("direction = down"); //print to console
        }
    }
}
