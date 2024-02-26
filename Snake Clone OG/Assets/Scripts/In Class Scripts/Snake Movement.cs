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

        //MOVE LEFT
        if (Input.GetKey(KeyCode.LeftArrow)) //if left arrow key is pushed, then...
        {
            dir = Vector3.left; //change the movement direction to LEFT
        } //MOVE RIGHT
        else if (Input.GetKey(KeyCode.RightArrow)) //if the right arrow key is pushed, then...
        {
            dir = Vector3.right; //change the movement direction to RIGHT
        } //MOVE UP
        else if (Input.GetKey(KeyCode.UpArrow)) //if the up arrow key is pushed, then...
        {
            dir = Vector3.up; //change the movement direction to UP
        } //MOVE DOWN
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            dir = Vector3.down; //change the movement direction to DOWN
        }
    }

    //When the Snake collides with a trigger of something...
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Meat") //if snake collides with Meat/Food..
        {
            //do this
            Debug.Log("Meat destroyed. Yum."); //print to the console
            Destroy(collision.gameObject);
          
        }
    }
}
