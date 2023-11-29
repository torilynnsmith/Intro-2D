using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //GLOBAL VARIABLES
    //MOVEMENT STUFF
    public Rigidbody2D playerBody; 

    public float playerSpeed = 0.05f;

    public float jumpForce = 500;
    public bool isJumping = false;

    //HEALTH STUFF
    public HealthBar healthBar;

    public int maxHealth = 20;
    public int currentHealth;

    //"flip" directions (for projectiles)
    public bool flippedLeft; //keeping track of which way our SPRITE is facing
    public bool facingRight; //keeping track of which way our Player SHOULD be facing

    //play sound effects
    public AudioSource fireAudio; 

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); 
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Jump(); 
    }

    //move player L&R w/ A & D keys
    private void MovePlayer()
    {
        Vector3 newPos = transform.position;

        if (Input.GetKey(KeyCode.A)) //moving left
        {
            newPos.x -= playerSpeed;
            facingRight = false; //change facingRight to false, bc we're facing left! 
            //Flip(facingRight);
            Flip(false); //call flip, feed it a bool
        }
        else if (Input.GetKey(KeyCode.D)) //moving right
        {
            newPos.x += playerSpeed;
            facingRight = true;
            Flip(facingRight); 
        }

        transform.position = newPos; //update position
    }

    private void Jump()
    {
        if (!isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            playerBody.AddForce(new Vector3(playerBody.velocity.x, jumpForce, 0));
            isJumping = true;
            //Debug.Log("isJumping = " + isJumping);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Surface")
        {
            isJumping = false;
            //Debug.Log("isJumping = " + isJumping);
        }

        if(collision.gameObject.name == "Fire")
        {
            TakeDamage(5);
            fireAudio.Play(); 
        }

    }

    public void TakeDamage(int damage)
    {
        Debug.Log("TakeDamage() called. damage = " + damage);
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void Flip (bool facingRight)
    {
        //Debug.Log("Flip() called! facingRight = " + facingRight); //print to console

        if (flippedLeft && facingRight) //if the player sprite is flipped Left but the player object is facing right
        {
            //flip the sprite and the player's childed Launch Point
            transform.Rotate(0, 180, 0);
            flippedLeft = false; 
        }

        if (!flippedLeft && !facingRight) //if the player sprite is flipped right but the player object is facing left
        {
            transform.Rotate(0, 180, 0);
            flippedLeft = true; 
        }

    }
}
