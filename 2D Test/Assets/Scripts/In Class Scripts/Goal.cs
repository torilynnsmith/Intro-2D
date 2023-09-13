using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    //GLOBAL VARIABLES
    public bool isPlayer1Goal; //declare and set bool in the inspector to determine which Goal is for Player 1
    public GameManager myManager; //declare and set Game Manager in the inspector

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ball") //if the ball enters/"collides with" the trigger
        {
            if(!isPlayer1Goal)//player 1 scores
            {
                myManager.Player1Scored(); //call Player 1 Scored Function
                Debug.Log("Player 1 scored"); //print to console
            } else //player 2 scores
            {
                myManager.Player2Scored(); //call Player 2 Scored Function
                Debug.Log("Player 2 Scored"); //print to console
            }
        }
    }
}
