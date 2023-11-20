using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    //GLOBAL VARIABLES
    //physics stuff
    public Rigidbody2D projectileRb; //declare and set the Rigidbody for the Projectile in the inspector
    public float speed; //declare how fast the projectile will go (alter in inspector)
        //currenlty set to 6

    //projectile countdown timer
    public float projectileLife; //set how long the projectile will last
        //currenlty set to 2
    public float projectileCount; //counts down time until the projectile destorys itself. (
                                  //currenlty set to 0
    //flip launch direction
    public PlayerMovement playerMovement; //reference and set the Player Movement script in the inspector
    public bool facingRight; //declare facingRight bool (you'll pull this from the player movement script in a bit)

    // Start is called before the first frame update
    void Start()
    {
        projectileCount = projectileLife; //set projectileCount equal to projectile Life

        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        //find the Player Movement script through code
        //we get the reference to the script this way b/c the projectile is a prefab and we can't set it in in the inspector anymore

        facingRight = playerMovement.facingRight; //get the facingRight value from the Player Movement script and equate it to the facingRight in THIS SCRIPT
        if(!facingRight) //if the player is facing Left...
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); //rotate the project 180 degrees to the left
            //Quaternion.Euler returns rotation values and applies them
        }
    }

    // Update is called once per frame
    void Update()
    {
        projectileCount -= Time.deltaTime; //reduces the projectileCount w/ each second

        if(projectileCount <0) //if the projectileCount runs out...
        {
            Destroy(gameObject); //destroy the gameObject this script is on (the projectile) 
        }
    }

    private void FixedUpdate()
        //FixedUpdate() is called every fixed framerate frame. It runs exactly 50 times per second all the time.
        //it's better practice to use FixedUpdate when applying force, torque, physics-related stuff b/c it's executed in sync with the physics engine, , not the framerate
        //IN SHORT: Moving w/ Rigidbody stuff -> FixedUpdate()
        //VS: Moving w/ transform -> Update()
    {
        if(facingRight)//if facingRight = true...
        {
            //shoot projectile right
            projectileRb.velocity = new Vector3(speed, projectileRb.velocity.y, 0); 
            //projectile will move along x,y,z Vector 3
        }
        else //otherwise...
        {
            //shoot projectile left (NOTICE THE -speed!!!) 
            projectileRb.velocity = new Vector3(-speed, projectileRb.velocity.y, 0);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //NOTE: The RigidBody on the projectile must be DYNAMIC for this collision to register. at least one object in any given collision has to be Dynamic

        //if projectile collides w/ an enemy
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject); //destroy the enemy collided with
                 
        }

        Destroy(gameObject); //Destroy the projectile
    }

}
