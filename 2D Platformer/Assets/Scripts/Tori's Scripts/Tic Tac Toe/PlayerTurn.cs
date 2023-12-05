using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    //Script Purpose:
    //Based on who's turn it is, switch out the sprite to be an X or an O

    //GLOBAL VARIABLES
    SpriteRenderer spriteRenderer; //Declare the Sprite Renderer component (we'll set it later in script) 
    public Sprite[] images; //create an array (list) of sprite images. Add them in the inspector
    //arrays start at 0! 0,1,2,3, and so on

    GameObject gameBoard; //declare a gameBoard object
    bool unplayed = true; //declare a set bool to let pieces only be played once

    //Awake is called once when the script instance is loaded
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); //get the Sprite Renderer component of the game object this script is attached to
        gameBoard = GameObject.Find("Game Board"); //set the gameBoard object
    }
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = null; //set the sprite to NOTHING at the start
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //OnMouseDown is called when the mouse button is pressed over a GUIElement or a Collider
    private void OnMouseDown()
    {
        if (unplayed)
        {
            int index = gameBoard.GetComponent<GameTracker>().PlayerTurn(); //declare a new int, index
                                                                            //get the Game Tracker script and the PlayerTurn() function from the gameBoard object
            spriteRenderer.sprite = images[index]; //set the sprite to whatever index we're at in the array
            unplayed = false; //change to false, this piece can't be played again
        }

    }
}
