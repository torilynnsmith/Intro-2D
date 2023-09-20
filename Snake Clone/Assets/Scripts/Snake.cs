using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; //add in a new Systems Library to allow us to use LISTS

public class Snake : MonoBehaviour
{
    //GLOBAL VARIABLES
    Vector3 dir = Vector3.right; //decare default movement direction
                                 //Remember the difference b/w Vector2(x,y) & Vector3(x,y,z)
                                 //there is shorthand for Vector2/3 directions.
                                 //In this one, Vector3.right = Vector3(1,0,0), moving it to the RIGHT

    //Keep Track of Tail Elements we'll be adding
    List<Transform> tail = new List<Transform>(); //declare a list variable

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

        //SAVE THE CURRENT POSITION (Where the head "previously" was. This is the gap that tail parts will move into)
        Vector3 gap = transform.position; 
        
        //In Snake, the snake is ALWAYS moving in some direction, never standing still.
        //MOVE SNAKE HEAD IN A DIRECTION
        transform.Translate(dir);
            //Translate moves the transform property in the direction and distance of the translation,
            //In this case, we are moving in the whatever direction we've set the dir variable to be

        //Check if the snake has a tail
        if (tail.Count > 0) //if the Tail amount is greater than 0, then...
        {
            //Move last Tail Element to where the Head previously was
            tail.Last().position = gap;

            //Keep our Tail List in order! Add to the front of the list and remove from the back
            tail.Insert(0, tail.Last()); //move to the next tail section
            tail.RemoveAt(tail.Count - 1); //reduce the list amount
                //Basically, these line of code move through each tail section only ONCE to tell it to move into the gap after the tail section preceding it has.
                //Then it will stop. 
        }
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
        }//MOVE LEFT
        else if (Input.GetKey(KeyCode.LeftArrow)) //if the Left Arrow is continuously pressed down, then...
        {
            dir = Vector3.left; //change the direction to LEFT
                                //NOTE: this could also be written as dir = - Vector3.right, "-right" = left
            //Debug.Log("direction = left"); //print to console
        }//MOVE UP
        else if (Input.GetKey(KeyCode.UpArrow)) //if the Up Arrow is continuously pressed down, then...
        {
            dir = Vector3.up; //change the direction to UP
            //Debug.Log("direction = up"); //print to console
        }//MOVE DOWN
        else if (Input.GetKey(KeyCode.DownArrow)) //if the Down Arrow is continuously pressed down, then...
        {
            dir = Vector3.down; //change the direction to DOWN
            //Debug.Log("direction = down"); //print to console
        }
    }

    //NEXT STEPS -
    //1. create an OnTriggerEnter2D function so that when the snake collides with a foodPrefab, it will add a tail element
}
