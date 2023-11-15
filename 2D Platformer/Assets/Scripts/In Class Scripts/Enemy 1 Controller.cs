using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    //GLOBAL VARIABLES
    //DAMAGE STUFF
    public int damage;
    public PlayerController playerController;

    //ENEMY MOVEMENT STUFF
    public Transform[] patrolPoints;
    public float moveSpeed = 3;
    public int patrolDestination; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement(); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //when enemy collides w/ player...
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("collided w/ Player");
            playerController.TakeDamage(damage);
        }
    }

    private void EnemyMovement()
    {
        //if the patrol destination is 0;
        if (patrolDestination == 0)
        {
            //go to patrol destination 0
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, patrolPoints[0].position) < .2f)
            {
                patrolDestination = 1; 
            }
        }

        //if the patrol destination is 1;
        if (patrolDestination == 1)
        {
            //go to patrol destination 0
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, patrolPoints[1].position) < .2f)
            {
                patrolDestination = 0;
            }
        }

    }
}
