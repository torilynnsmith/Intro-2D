using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    //DECLARE VARIABLES
    public Rigidbody2D rbPaddle; //get RigidBody2D component
        //HOT TIP: set RigidBody to Kinematic so they don't go flying if hit with the Ball

    public bool isPlayer1; //set which player it is

    public float paddleSpeed = 0.05f; //declare and set paddleSpeed

    //Controller Key Codes
    //public KeyCode upKey; //declare and set in Inspector
    //public KeyCode downKey; //declare and set in Inspector

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if an object is Player1 (set in Inspector) use one set of controls over the other
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

        //If paddle is w/i play area, allow movement
        //NOTE: We've set our border values here to approximately where the paddles would hit the Wall objects.
        //Basically, this is hardcoding collision! 
        if (newPos.y <= 4.1f && newPos.y >= -4.1f) //NOTE: used floats to get it as close to the border as possible
        {
            //Debug.Log("Player1 Controller in play area"); //print to console

            //PLAYER MOVEMENT CONTROLS
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
        //reset paddle to be within the play area
        if (newPos.y >= 4.1f) //if the y position is greater than or equal to 4...
        {
            newPos.y = 4; //set the y position value to 3.9f
            transform.position = newPos; //update player 1 paddle with the new position
            //Debug.Log("newPos.y = " + newPos.y);
        } else if (newPos.y <= -4.1f) //if the y position is less than or equal to -4...
        {
            newPos.y = -4; //set the y position value to 3.9f
            transform.position = newPos; //update player 1 paddle with the new position
            //Debug.Log("newPos.y = " + newPos.y);
        }

    }

    void Player2Control()
    {
        Vector3 newPos = transform.position; //declare a new Vector3 variable, newPos (New Position)

        if (newPos.y <= 4.1f && newPos.y >= -4.1f) //NOTE: used floats to get it as close to the border as possible
        {
            //Debug.Log("Player2 Controller in play area"); //print to console

            //PLAYER MOVEMENT CONTROLS
            //This is the same process as Player1Control! 
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
        //reset paddle to be within the play area
        if (newPos.y >= 4.1f) //if the y position is greater than or equal to 4...
        {
            newPos.y = 4; //set the y position value to 3.9f
            transform.position = newPos; //update player 2 paddle with the new position
            //Debug.Log("newPos.y = " + newPos.y);
        }
        else if (newPos.y <= -4.1f) //if the y position is less than or equal to -4...
        {
            newPos.y = -4; //set the y position value to 3.9f
            transform.position = newPos; //update player 2 paddle with the new position
            //Debug.Log("newPos.y = " + newPos.y);
        }
    }
}
