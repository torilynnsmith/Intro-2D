using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    //GLOBAL VARIABLES
    public int damage; //declare and set damage variable from inspector(change value depending on how powerful the enemy is) 
    public PlayerMovement playerController; //reference the Player Movement/Player controller script, set in inspector

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //When Enemy collides with Player...(Notice the tag!) 
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("collided w/ Player");
            playerController.TakeDamage(damage); //call and set the TakeDamage(int) to the damamge value from this script
        }
    }
}
