using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //add in a new Unity Library so we can use the UI elements

public class GameManager : MonoBehaviour
{
    //GLOBAL VARIABLES

    //Game Objects for UI Elements
    public TextMeshProUGUI player1ScoreText; //Text Object for Player 1 Score, set in inspector
    public TextMeshProUGUI player2ScoreText; //Text Object for Player 2 Score, set in inspector

    //Scores
    private int player1Score = 0; //declare and set integer variable for Player 1 Score
    private int player2Score = 0; //declare and set integer variable for Player 2 Score


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //update the player scores
        player1ScoreText.text = "P1: " + player1Score; //update Player 1's Score UI
        player2ScoreText.text = "P2: " + player2Score; //update Player 2's Score UI
    }

    //When Player 1 Scores, run this function
    //NOTE: This is a PUBLIC void
    public void Player1Scored()
    {
        player1Score++; //add 1 to score value
        //Debug.Log("Player 1 Score: " + player1Score); //print player1Score to the console
    }

    //When Player 2 Scores, run this function
    //NOTE: This is a PUBLIC void
    public void Player2Scored()
    {
        player2Score++; //add 1 to score value
        //Debug.Log("Player 2 Score: " + player2Score); //print player2Score to the console
    }


}
