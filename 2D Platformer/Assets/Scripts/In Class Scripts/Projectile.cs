using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //GLOBAL VARIABLES
    //physics stuff
    public Rigidbody2D projectileRb;
    public float speed;

    //projectile countdown timer stuff
    public float projectileLife;
    public float projectileCountDown;

    //flip launch direction
    public PlayerController playerController;
    public bool facingRight; 

    // Start is called before the first frame update
    void Start()
    {
        projectileCountDown = projectileLife;

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        facingRight = playerController.facingRight;
        if(!facingRight) //if the player is facing Left
        {
            //do this
            transform.rotation = Quaternion.Euler(0, 180, 0); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        projectileCountDown -= Time.deltaTime;
        //Debug.Log("projectileCountDown = " + projectileCountDown);

        if(projectileCountDown <= 0)
        {
            Destroy(gameObject);
            Debug.Log("projectile destroyed"); 
        }
    }

    private void FixedUpdate()
    {
        if(facingRight) //if facingRight = true
        {
            //shoot projectile right
            projectileRb.velocity = new Vector3(speed, projectileRb.velocity.y, 0);
        } else //otherwise (if facingRight = false) 
        {
            //shoot projectile left
            projectileRb.velocity = new Vector3(-speed, projectileRb.velocity.y, 0);

        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if projectile collides w/ an enemy
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject); 
        }

        Destroy(gameObject); 
    }
}
