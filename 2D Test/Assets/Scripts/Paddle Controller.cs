using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    //DECLARE VARIABLES
    public Rigidbody2D rbPaddle; //get RigidBody2D component
    public bool isPlayer1; //set which player it is

    public float paddleSpeed = 0.05f; //declare and set paddleSpeed

    //Controller Key Codes
    //public KeyCode upKey; //declare and set in Inspector
    //public KeyCode downKey; //declare and set in Inspector

    //Set Borders (If we wanted the option to reset the paddle to the otherside and make it continuous
    //public float leftBorder; //ref Left Border
    //public float rightBorder; //ref Right Border

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
        ////MOVE TO PLAYER SPECIFIC FUNCTION AFTER CHECKING IF PLAYER 1 OR 2
        //Vector3 newPos = transform.position; //declare a new Vector3 variable, newPos (New Position)

        //if (Input.GetKey(KeyCode.W)) //if W is pressed...
        //{
        //    //Debug.Log("W pressed");
        //    newPos.y += paddleSpeed; //affect y coordinate up = move paddle up
        //    //direction = Vector2.up; //move paddle up
        //}
        //else if (Input.GetKey(KeyCode.S)) //if S is pressed
        //{
        //    //Debug.Log("S pressed");
        //    newPos.y -= paddleSpeed; //affect y coordinate down = move paddle down
        //    //direction = Vector2.down; //move paddle down
        //}

        //transform.position = newPos; //update with the new position
    }

    void Player1Control()
    {
        Vector3 newPos = transform.position; //declare a new Vector3 variable, newPos (New Position)

        if (Input.GetKey(KeyCode.W)) //if W is pressed...
        {
            //Debug.Log("W pressed");
            newPos.y += paddleSpeed; //affect y coordinate up = move paddle up
            //direction = Vector2.up; //move paddle up
        }
        else if (Input.GetKey(KeyCode.S)) //if S is pressed
        {
            //Debug.Log("S pressed");
            newPos.y -= paddleSpeed; //affect y coordinate down = move paddle down
            //direction = Vector2.down; //move paddle down
        }

        transform.position = newPos; //update player 1 paddle with the new position
    }

    void Player2Control()
    {
        Vector3 newPos = transform.position; //declare a new Vector3 variable, newPos (New Position)

        if (Input.GetKey(KeyCode.UpArrow)) //if Up Arrow is pressed
        {
            newPos.y += paddleSpeed; //affect y coordinate up = move paddle up
        }
        else if (Input.GetKey(KeyCode.DownArrow)) //if Down Arrow is pressed
        {
            newPos.y -= paddleSpeed; //affect y coordinate down = move paddle down

        }

        transform.position = newPos; //update player 2 paddle with new position
    }
}
