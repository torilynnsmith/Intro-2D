using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    //GLOBAL VARIABLES
    Vector3 dir = Vector3.right; //declared a default movement direction of RIGHT


    // Start is called before the first frame update
    void Start()
    {
        //Call MoveSnake() every 300 ms (0.3 sec) to move the snake
        InvokeRepeating("MoveSnake", 0.3f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeDirection(); //call Change Direction
    }

    //Make the Snake Move
    void MoveSnake()
    {
        //Debug.Log("MoveSnake called"); //prints to the console
        transform.Translate(dir); //translate transform property in the direction and distance of the translation

    }

    //change the snake's direction when a key is pressed
    private void ChangeDirection()
    {
        //Debug.Log("Change Direction called"); //print to console

        //Move Left
        if (Input.GetKey(KeyCode.LeftArrow)) //if left arrow key is pushed, then...
        {
            //do this
            dir = Vector3.left; //move left
        }
        //MAKE IT MOVE THE OTHER 3 DIRECTIONS, RIGHT, UP, DOWN
    }
}
