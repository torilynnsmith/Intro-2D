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

    // Start is called before the first frame update
    void Start()
    {
        projectileCountDown = projectileLife; 
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
        //shoot projectile right
        projectileRb.velocity = new Vector3(speed, projectileRb.velocity.y, 0); 
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
