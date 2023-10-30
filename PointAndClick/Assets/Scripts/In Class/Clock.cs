using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //add and use the TMPro Library

//THIS IS THE IN CLASS SCRIPT

public class Clock : MonoBehaviour
{
    //GLOBAL VARIABLES
    //Time variables
    public float timeRemaining = 90;
    public bool timerIsRunning = false;

    //UI Elements
    public TextMeshProUGUI timeText; //set Text Object variable in Inspector

    //Changing Scenes
    public SceneSwitcher sceneScript; //declare and set Script we're trying to reference
    public int sceneID; //declare and set sceneID in Inspector

    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining >= 0) //if there is more time than 0
            {
                timeRemaining -= Time.deltaTime; //count DOWN timer
                //timeRemaining += Time.deltaTime; //count UP timer

                //Debug.Log("timeRemaining = " + timeRemaining);
            }
            else if (timeRemaining <= 0)//if time has run out
            //else 
            {
                timeRemaining = 0;
                timerIsRunning = false;
                NextScene(); //call NextScene function
            }
            DisplayTime(); //call DisplayTime Function
        }

    }

    void DisplayTime()
    {
        //Debug.Log("DisplayTime() called"); //print to console

        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        //divide TimeRemaining by 60 = minutes
        float seconds = Mathf.FloorToInt(timeRemaining % 60);

        //update UI
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        //timeText.text = minutes + ":" + seconds;


    }

    //Go to Next Scene of Choice
    public void NextScene()
    {
        Debug.Log("NextScene Called");
        sceneScript.GoToScene(sceneID); 
    }
}
