using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    //GLOBAL VARIABLES

    //damage variables
    public int damage; //declare and set damage variable from inspector(change value depending on how powerful the enemy is) 
    public PlayerMovement playerController; //reference the Player Movement/Player controller script, set in inspector

    //enemy movement
    public Transform[] patrolPoints; //declare and set a Transform variable as an ARRAY, since we need multiple
                                     //Drag and drop your patrol points into the array
    public float moveSpeed = 3; //declare and set moveSpeed
    public int patrolDestination; //declare patrol Destination (will change through script)

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement(); //call enemy movement
    }


    //When enemy collides with something...
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //When Enemy collides with Player...(Notice the tag!) 
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("collided w/ Player");
            playerController.TakeDamage(damage); //call and set the TakeDamage(int) to the damamge value from this script
        }
    }

    private void EnemyMovement()
    {
        //if the patrol Desitnation is destination 0...
        if (patrolDestination == 0)
        {
            //go to a patrol destination 0!
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
            //we've used MoveTowards in our Click To Move code!
            //It needs 3 parameters: (current location, target location, the speed with with to move to the target location) 
            //So this line says: transform the position of the enemy this script is on from the current position to the patrol point [position in arrary] at this speed multiplied by Time.deltaTime

            //if the enemy gets reallyyyy close to the desired patrol point (like they're, basically there...)
            if (Vector3.Distance(transform.position, patrolPoints[0].position) < .2f) //if the distance b/w these 2 objects is less than .2f...
                                                                                      //Distance calculates the distance b/w 2 objects
            {
                //...set the patrol destination to 1 in the array
                patrolDestination = 1;
            }
        }

        //if the patrol Desitnation is destination 1...
        if (patrolDestination == 1)
        {
            //go to a patrol destination 0!
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);

            //if the enemy gets reallyyyy close to the desired patrol point (like they're, basically there...)
            if (Vector3.Distance(transform.position, patrolPoints[1].position) < .2f) //if the distance b/w these 2 objects is less than .2f...
                                                                                      //Distance calculates the distance b/w 2 objects
            {
                //...set the patrol destination to 0 in the array
                patrolDestination = 0;
            }
        }
    }
}
