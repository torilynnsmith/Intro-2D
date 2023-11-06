using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //NOTE
    //Make a Camera follow your Player
    //1. Install Cinemachine via the Package Manager
    //2. Add a 2D Camera (Right Click Hierarchy -> Cinemachine -> 2D Camera
    //3. This will make the new Camera your Main Camera
    //4. Drag the Player Object into the 2D camera's follow field.
    //That's it! 

    //GLOBAL VARIABLES
    public Rigidbody2D playerBody; //set Rigidbody variable for the player in Inspector

    public float playerSpeed = 0.05f; //declare and set playerSpeed
    public float jumpForce = 500; //declare and set jumpForce
    public bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //I've decided to put these movements in separate functions for organizational reasons! 
        MovePlayer(); //call MovePlayer() function
        Jump();
    }

    //Move Player Left & Right via A & D keys
    private void MovePlayer()
    {
        Vector3 newPos = transform.position; //declare and set a new Vector3 variable, newPos (New Position)

        if (Input.GetKey(KeyCode.A)) //If A Key is pressed
        {
            //Debug.Log("A pressed."); //print to console
            newPos.x -= playerSpeed; //affect x coordinate left
        }
        else if (Input.GetKey(KeyCode.D)) //Move Right w/ D Key
        {
            //Debug.Log("D pressed."); //print to console
            newPos.x += playerSpeed; //affect x coordinate right
        }

        transform.position = newPos; //update player object with the new position

    }

    //Jump Player via Spacebar
    private void Jump()
    {

        //NOTE: As written, this allows infinite double jumping! How can you limit that?

        if (!isJumping && Input.GetKeyDown(KeyCode.Space)) //when the Spacebar is pressed (first frame only)
        {
            playerBody.AddForce(new Vector3(playerBody.velocity.x, jumpForce, 0)); //apply force in decided direction
            //Similar to launching our Pong Ball! We're just declaring the new Vector 3 in the same line.
            //This Vector 3 keeps the same velocity.x (to keep moving in whatever x direction), but changes the y to jumpForce, and doesn't change the z at all. 
            isJumping = true;
            //Debug.Log("isJumping = " + isJumping); //print to console
            //reset is jumping on collision with a surface??
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Surface")
        {
            //Debug.Log("collided w/ surface"); //print to console
            isJumping = false;
            //Debug.Log("isJumping = " + isJumping); //print to console

        }
    }



}
