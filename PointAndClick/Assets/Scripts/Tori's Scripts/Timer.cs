timusing System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //add and use the TMPro library

//THIS IS TORI'S SCRIPT

public class Timer : MonoBehaviour
    //attached to Timer Text Object
{
    //GLOBAL VARIABLES
    //Time variables
    public float timeRemaining = 90; //declare and set float variable to store the amount of time remaining
    public bool timerIsRunning = false; //declare and set bool variable for whether or not the timer is running

    //UI Elements
    public TextMeshProUGUI timeText; //Text Object for Time Text, set in inspector

    //Changing Scenes
    public SceneChanger sceneScript; //declare and set Script we're trying to access
    public int sceneID; //declare and set sceneID in the Inspector = to its # in Build Settings

    // Start is called before the first frame update
    void Start()
    {
        //Start timer by setting bool to true
        timerIsRunning = true; 
    }

    // Update is called once per frame
    void Update()
    {
        //If the timer is running...
        if (timerIsRunning)
        {
            //If there is time remaining...
            if (timeRemaining > 0)
            {
                //Debug.Log("timeValue = " + timeValue); //print to console
                timeRemaining -= Time.deltaTime; //subtract the duration of the prevous frame from time remaining
                                                 //deltaTime is the duration of the previous frame
            }
            else if (timeRemaining <= 0) //if there is 0 timeRemaining (Time has Run Out)
            {
                Debug.Log("Time has run out!"); //print to console
                timerIsRunning = false; //set bool to false to stop timer
                timeRemaining = 0; //lock timeRemaing to 0 so it doesn't go into negative numbers
                NextScene(); //call NextScene function

            }

            //DisplayTime(timeRemaining); //display the time, pass in timeRemaining as the parameter to equate to the float timeToDisplay
            DisplayTime(); //display the time, pass in timeRemaining as the parameter

        }

    }

    //Display the timeRemaining through UI Text
    //void DisplayTime(float timeToDisplay) //added in a "value parameter", similar to our Collision 2D code!
        //creating a void with a passed in parameter is not entirely necessary
    void DisplayTime() //added in a "value parameter", similar to our Collision 2D code!
    {
        //check if timeToDisplay is < 0 and lock it to 0 if it is not
        //if (timeToDisplay <= 0)
        //{
        //    timeToDisplay = 0; //lock timeToDisplay to 0
        //}

        //Divide the timeRemaining by 60
        float minutes = Mathf.FloorToInt(timeRemaining / 60); //calculate minutes
            //Mathf is a collection of common math functions, like division, multiplication, etc.
            //FloorToInt rounds a float down to the nearest whole integer
        float seconds = Mathf.FloorToInt(timeRemaining % 60); //calculate seconds
                                                              //% = a Modulo operation. It returns a remainder int after a division
                                                              //For example, 62 % 60 returns a remainder of 2, which is our seconds value!
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds); //change text displayed in timeText Text Object
                                                                          //string.Format lets you place variables inside a formatted string
                                                                          //in this case, we're using 2 double-digit numbers separated by a colon
                                                                          //Variable 0 = minutes, put into 00 formatting option
                                                                          //Variable 1 = seconds, put into 00 formatting option
    }

    //Go to next Scene of Choice
    public void NextScene()
    {
        //Add go to next scene code here
        Debug.Log("NextScene Called"); //print to console

        //There's a couple ways to do this!
        //1. You could add in the scene management library and rewrite that code
        //2. You could call the function from the script we've already written! Let's do that one.
        sceneScript.MoveToScene(sceneID); //call MoveToScene function on the sceneScript
            //don't forget to set your sceneID in the Inspector for it to pass through correctly! 
    }
}
