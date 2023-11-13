using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //GLOBAL VARIABLES
    public Rigidbody2D playerBody; 

    public float playerSpeed = 0.05f;

    public float jumpForce = 500;
    public bool isJumping = false;

    //HEALTH STUFF
    public HealthBar healthBar;

    public int maxHealth = 20;
    public int currentHealth; 

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

        if (Input.GetKey(KeyCode.A))
        {
            newPos.x -= playerSpeed; 
        }
        else if (Input.GetKey(KeyCode.D))
        {
            newPos.x += playerSpeed; 
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
        }

    }

    public void TakeDamage(int damage)
    {
        Debug.Log("TakeDamage() called. damage = " + damage);
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
