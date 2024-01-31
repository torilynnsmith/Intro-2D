using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //Declare Universal Variables 
    public Rigidbody2D rbBall; //get Rigidbody 2D component from sprite

    public float force = 200; //delcare and set force/velocity
    //public float ballSpeed = 5; //declare ballSpeed variable

    //private float xPos; //get x position
    //private float yPos; //get y position
    private float xDir; //declare x direction
    private float yDir; //declare y direction

    public bool inPlay; //set to true/false if ball is in Play, set in Inspector
    public Vector3 ballStartPos; //Ball starting position, set in Inspector

    public bool isBallOne; //differentiate b/w ball1 and ball2

    // Start is called before the first frame update
    void Start()
    {
        //Add a Debug Message, prints to the console
        //Debug.Log("Hello World");

        //Debug.Log("Start(). force = " + force); 

        Launch(); //call the Launch Function at Start

        //rb = GetComponent<Rigidbody2D>(); 
            //get the component of the gameobject the script is placed on
            //HOT TIP: use a global variable instead and set this in the inspector
    }

    // Update is called once per frame
    void Update()
    {
        //Check if Ball is in Play
        if (inPlay == false) //if Ball is NOT in Play
        {
            transform.position = ballStartPos; //set Ball to start position
            Launch(); //call Launch() to automatically relaunch the Ball
        }

        //Check if Spacebar has been pressed to launch the ball
    }

    private void Launch()
    {
        Vector3 direction = new Vector3(0, 0, 0); //create new Vector3 variable
                                                  //What is a vector?
                                                  //Vector2 (x,y) = representation of 2D vectors and points
                                                  //Vector3 (x,y,z) = represenation of 3D vectors and points (can still be used in 2D projects!)

        //MAKE BALL MOVE IN RANDOM DIRECTION AT START
        //set direction.x
        xDir = Random.Range(0, 2); //random int between 0 & 1, the second/max number (2) is EXCLUSIVE & won't be included
        //if (xDir == 0)
        //{
        //    direction.x = -1; //go Left
        //    //Debug.Log("xDir = " + direction.x);//print direction.x to console
        //}
        //else if (xDir == 1)
        //{
        //    direction.x = 1; //go right
        //    //Debug.Log("xDir = " + direction.x);//print direction.x to console
        //}

        //If you have 2 Balls, set which direction they go
        if (isBallOne) //if Ball 1
        {
            direction.x = -1; //go Left
            //Debug.Log("Ball One went Left"); 
        } else //if Ball 2
        {
            direction.x = 1; //go Right
            //Debug.Log("Ball Two went Right"); 
        }
        //FANCIER WAYS
        //xDir = Random.Range(0, 2) == 0 ? -1 : 1; //set x direction (Compresses everything above)
        //xDir = Random.value < 0.5f ? -1.0f : 1.0f; //set x direction (Compresses the above line even more using floats

        //set direction.y
        yDir = Random.Range(0, 2); //random int between 0 & 1
        if (yDir == 0)
        {
            direction.y = -1; //go Down
            //Debug.Log("yDir = " + direction.y);//print direction.y to console
        }
        else if (yDir == 1)
        {
            direction.y = 1; //go Up
            //Debug.Log("yDir = " + direction.y);//print direction.y to console
        }
        //FANCIER WAYS
        //yDir = Random.Range(0, 2) == 0 ? -1 : 1; //set y direction
        //float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f):Random.Range(0.5f, 1.0f); //set y direction (Compresses the above line even more using floats and chooses a more random angle)

        //Add force to start movement
        rbBall.AddForce(direction * force); //apply force in decided direction
        inPlay = true; //ball is now in Play, = true
        //Debug.Log("inPlay = " + inPlay); //print inPlay value to console
    }

    //EVENTS UPON COLLISION
    private void OnCollisionEnter2D(Collision2D collision) //MAKE SURE THIS IS 2D!!! Won't work without the 2D qualifier
    {
        //HOT TIP: To dectect collision, at least one object must have a dynamic RigidBody on it

        //Debug.Log("Object that collided w/ Ball: " + collision.gameObject.name); //check if and what our Ball is colliding with

        //when Ball collides with Left or Right Walls, reset to original position at ballStartPos & change score
        if (collision.gameObject.name == "Left Wall" || collision.gameObject.name == "Right Wall")
        {
            //RESET POSITION
            //Debug.Log("hit wall, ball reset"); 
            rbBall.velocity = Vector3.zero; //zeros out the force being applied to Ball so the force doesn't stack
            inPlay = false; //set inPlay to False, will cause the inPlay check in Update() to reset the position and automatically Launch()

            //OTHER THINGS WE COULD DO HERE WITH COLLISIONS!
            //1. Change Score: You could change score here upon collision instead of a separate trigger!
                //This might be helpful if the ball were something like: a spaceship collecting moving treasure or hitting multiple moving asteroids.
            //2. Add sounds!
            //3. Change how the sprite looks.
            //All kinds of stuff! The possibilities are endless! The world is your oyster! 
        }
    }
}
