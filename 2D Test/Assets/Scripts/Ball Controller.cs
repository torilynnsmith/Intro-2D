using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //Declare Universal Variables 
    public Rigidbody2D rb; //get Rigidbody 2D component from sprite
    //private Rigidbody2D rb; //get Rigidbody 2D privately

    public float force = 200; //delcare and set force/velocity
    //public float ballSpeed = 5; //declare ballSpeed variable

    //private float xPos; //get x position
    //private float yPos; //get y position
    private float xDir; //declare x direction
    private float yDir; //declare y direction
   
    //Vector2 direction; //Vector2 = representation of 2D vectors and points

    // Start is called before the first frame update
    void Start()
    {
        //1. Add a Debug Message
        Debug.Log("Hello World");


        //rb = GetComponent<Rigidbody2D>(); 
        //get the component of the gameobject the script is placed on
        //comment after showing the global variable

        //Make Ball Move in Random Direction at start
        xDir = Random.Range(0, 2) == 0 ? -1 : 1; //set x direction
        //The minimum value is inclusive, the max is not. In this case, it'll return integers between 0 & 1.
            //?: Is this condition true? yes : no
            //?: condition? consequent:alternative
        //If it returns a 0, turn it into -1 or 1. 
        Debug.Log("xDir = " + xDir);//print yDir to console
            //if x = -1, it'll move right. If x = 1, it'll move left
        yDir = Random.Range(0, 2) == 0 ? -1 : 1; //set y direction
        Debug.Log("yDir = " + yDir);//print yDir to console
            //if y = -1, it'll move down. If y = 1, it'll move up
            //note difference between integers (whole numbers) and floats (decimals)

        //Make Ball Move at Start (fancier angles) 
        //float x = Random.value < 0.5f ? -1.0f : 1.0f; //x coor value, choose left or right
        //if x is less than half, it'll be one direction, if greater then it is the other
        //float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f):Random.Range(0.5f, 1.0f); //y coor value, choose random angle

        Vector3 direction = new Vector3(xDir, yDir, 0); //create new Vector3 variable
            //What is a vector?
            //Vector2(x,y) and Vector3(x,y,z)

        //rb.velocity = new Vector3(ballSpeed * xDir, ballSpeed * yDir); //create a force on the ball
        //rb.velocity = direction * ballSpeed; //essentially the same as above, just loading the direction variables into one value
        //rb.velocity = direction * force; //essentially the same as above, just loading the direction variables into one value
        rb.AddForce(direction * force); //apply force in decided direction

    }

    // Update is called once per frame
    void Update()
    {

    }
}
