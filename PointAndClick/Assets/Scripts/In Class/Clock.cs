using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    //GLOBAL VARIABLES
    //Time variables
    public float timeRemaining = 90;
    public bool timerIsRunning = false; 

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
            if (timeRemaining > 0) //if there is more time than 0
            {
                timeRemaining -= Time.deltaTime;
                Debug.Log("timeRemaining = " + timeRemaining);
            }
            else //if time has run out
            {
                timeRemaining = 0;
                timerIsRunning = false; 
            }
        }

    }
}
