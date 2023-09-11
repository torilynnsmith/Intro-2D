using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //UNIVERSAL VARIABLES
    public Rigidbody2D rbPaddle; //get RigidBody2D component from object in inspector
    public float paddleSpeed = 0.05f; //declare and set paddleSpeed

    public bool isPlayer1; //set which player it is

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer1)
        {
            Player1Control(); 
        } else
        {
            Player2Control(); 
        }


    }

    private void Player1Control()
    {
        Vector3 newPos = transform.position; //declares a new Vector3 variable

        if (Input.GetKey(KeyCode.W))
        {
            //Debug.Log("W pressed"); //print to console
            newPos.y += paddleSpeed; //affect y coordinate up = move paddle up
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //Debug.Log("S pressed");
            newPos.y -= paddleSpeed; //affect x coodinate down
        }

        transform.position = newPos; //update paddle 1 w/ new position
    }
    
    private void Player2Control()
    {
        Vector3 newPos = transform.position;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            newPos.y += paddleSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            newPos.y -= paddleSpeed; 
        }


        transform.position = newPos; 


    }
}
