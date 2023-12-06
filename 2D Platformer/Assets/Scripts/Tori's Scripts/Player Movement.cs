using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //This is Tori's Version of the Player Controller Script

    //NOTE
    //Make a Camera follow your Player
    //1. Install Cinemachine via the Package Manager
    //2. Add a 2D Camera (Right Click Hierarchy -> Cinemachine -> 2D Camera
    //3. This will make the new Camera your Main Camera
    //4. Drag the Player Object into the 2D camera's follow field.
    //That's it! 

    //GLOBAL VARIABLES
    //Player movement
    public Rigidbody2D playerBody; //set Rigidbody variable for the player in Inspector

    public float playerSpeed = 0.05f; //declare and set playerSpeed
    public float jumpForce = 300; //declare and set jumpForce
    public bool isJumping = false;

    //Player Health
    public int maxHealth = 20; //set and declare the maxHealth
    public int currentHealth; //declare currentHealth

    public LifeBar healthBar; //reference the Life Bar (HealthBar) script, set in inspector

    //"flip" direction (for projectiles)
    public bool flippedLeft; //keeps track of which way our sprite IS facing
    public bool facingRight; //keeps track of which way our Player SHOULD be facing

    //play sound effects
    public AudioSource lavaRockAudio; //declare and set lava rock audio in inspector

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; //set currentHealth equal to maxHealth
        healthBar.SetMaxHealth(maxHealth); //set the SetMaxHealth(int) to the maxHealth value from this script
    }

    // Update is called once per frame
    void Update()
    {
        //I've decided to put these movements in separate functions for organizational reasons! 
        MovePlayer(); //call MovePlayer() function
        Jump();

        //Take damage test
        //if (Input.GetKeyDown(KeyCode.Y)) //when Y is pressed, first frame only
        //{
        //    TakeDamage(1); //call TakeDamage and feed it an int value of 1 (player will take 1 damage) 
        //}
    }

    //Move Player Left & Right via A & D keys
    private void MovePlayer()
    {
        Vector3 newPos = transform.position; //declare and set a new Vector3 variable, newPos (New Position)

        if (Input.GetKey(KeyCode.A)) //If A Key is pressed
        {
            //Debug.Log("A pressed."); //print to console
            newPos.x -= playerSpeed; //affect x coordinate left
            facingRight = false; //facing/moving Left
            Flip(false); //call Flip(), feed it a bool
        }
        else if (Input.GetKey(KeyCode.D)) //Move Right w/ D Key
        {
            //Debug.Log("D pressed."); //print to console
            newPos.x += playerSpeed; //affect x coordinate right
            facingRight = true; //facing/moving Right
            Flip(true); //call Flip(), feed it a bool
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
        //when colliding with a surface (ground, safe obstacles, etc.)
        if (collision.gameObject.tag == "Surface")
        {
            //Debug.Log("collided w/ surface"); //print to console
            isJumping = false;
            //Debug.Log("isJumping = " + isJumping); //print to console

        }

        //When colliding with a dangerous object (lava, enemy, etc.)
        if (collision.gameObject.name == "Lava Rock")
        {
            TakeDamage(1); //call TakeDamage(), reduce health by 1
            lavaRockAudio.Play(); //play the lava rock audio
        }
    }

    //Damage the player (make public to access from other scripts!) 
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; //reduce current health by damage amount
        healthBar.SetHealth(currentHealth); //set the SetHealth(int) to the currentHealth value from this script

        //Debug.Log("TakeDamage() called"); //print to console
        //Debug.Log("currentHealth = " + currentHealth); //print to console

        //if currentHealth = 0, destroy the player sprite
        //Could also go to a game over screen or restart the level! 
        if (currentHealth <= 0)
        {
            Destroy(gameObject); 
        }
    }

    //flip the launch point for projectiles so it will fire in both directions
    //you can also flip the sprite if you'd like, I just don't have that coded here. 
    void Flip (bool facingRight)
    {
        //Debug.Log("Flip() called. facingRight = " + facingRight); //print to console

        if (!flippedLeft && facingRight) //if player is flipped Left but facing right...
        {
            transform.Rotate(0, -180, 0); //flip the whole sprite and it's childed Launch point
                                          //flippedLeft = false;
            flippedLeft = true;

        }

        if (flippedLeft && !facingRight) //if player is flipped right but facing left
        {
            transform.Rotate(0, -180, 0); //flip the whole sprite and it's childed Launch point
            //flippedLeft = true;
            flippedLeft = false;
        }
    }



}
