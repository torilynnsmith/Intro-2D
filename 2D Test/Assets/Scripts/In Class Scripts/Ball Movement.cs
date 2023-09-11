using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    //THINGS TO DO NEXT
    //1. Move "Random Direction At Start" code to its own function
    //2. Reset and relaunch Ball when it hits a wall

    //UNIVERSAL VARIABLES
    private float xDir; // declare x direction
    private float yDir; // declare y direction

    public Rigidbody2D rbBall; //declare and set rbBall Rigidbody2D from the Inspector
    public float force = 200; //declared and set force from the inspector 
    //private float ballSpeed = 5; //declared and set a speed privately (used similarly to force)

    // Start is called before the first frame update
    void Start()
    {
        //Add a Debug Message, prints to the console
        Debug.Log("Hello World");

        //MAKE BALL MOVE IN RANDOM DIRECTION AT START
        Vector3 direction = new Vector3(0, 0, 0); //create new Vector3 variable
                                                  //What is a vector?
                                                  //Vector2 (x,y) = representation of 2D vectors and points
                                                  //Vector3 (x,y,z) = represenation of 3D vectors and points (can still be used in 2D projects!)

        //set direction.x
        xDir = Random.Range(0, 2); //random int between 0 & 1, the second/max number (2) is EXCLUSIVE & won't be included
        if (xDir == 0)
        {
            direction.x = -1; //go Left
            Debug.Log("xDir = " + direction.x);//print direction.x to console
        }
        else if (xDir == 1)
        {
            direction.x = 1; //go right
            Debug.Log("xDir = " + direction.x);//print direction.x to console
        }
        //FANCIER WAYS
        //xDir = Random.Range(0, 2) == 0 ? -1 : 1; //set x direction (Compresses everything above)
        //xDir = Random.value < 0.5f ? -1.0f : 1.0f; //set x direction (Compresses the above line even more using floats

        //set direction.y
        yDir = Random.Range(0, 2); //random int between 0 & 1
        if (yDir == 0)
        {
            direction.y = -1; //go Down
            Debug.Log("yDir = " + direction.y);//print direction.y to console
        }
        else if (yDir == 1)
        {
            direction.y = 1; //go Up
            Debug.Log("yDir = " + direction.y);//print direction.y to console
        }
        //FANCIER WAYS
        //yDir = Random.Range(0, 2) == 0 ? -1 : 1; //set y direction
        //float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f):Random.Range(0.5f, 1.0f); //set y direction (Compresses the above line even more using floats and chooses a more random angle)

        //ADD FORCE TO START MOVEMENT
        rbBall.AddForce(direction * force); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
