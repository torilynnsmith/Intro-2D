using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    //GLOBAL VARIABLES
    public bool isPlayer1Goal; //declare and set bool in the inspector to determine which Goal is for Player 1

    public GameManager myManager; //declare and set the Game Manager from the Inspector

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //EVENTS UPON ENTERING/"COLLIDING" WITH A TRIGGER
    private void OnTriggerEnter2D(Collider2D collision) //MAKE SURE THIS IS 2D!!! Won't work without the 2D qualifier
        //you could also do this as a true collision on the walls, but I want you to see how triggers work!
        //If a collider is a trigger, objects will pass right through it, but a "collision" will still be registered
    {
        if (collision.gameObject.name == "Ball") //if the Ball collide with the Goal areas
        {
            if (!isPlayer1Goal) //if the Trigger is on the Player 2 Goal (check your bool!)
                //! = is not
                //so, if this is written as !isPlayer1Goal, then it's referring to Player 2's goal area
            {
                //Debug.Log("Player 1 Scored"); //print this message to the console
                myManager.Player1Scored(); //call the Player1Scored() funciton from the Game Manager

            }
            else //if the Trigger is on the Player 1 Goal
            {
                //Debug.Log("Player 2 Scored"); //print this message to the console
                myManager.Player2Scored(); //call the Player2Scored() function from the Game Manager
            }
        }

    }
}
