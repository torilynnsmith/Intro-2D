using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //use Scene Management Library

//THIS IS TORI'S SCRIPT

public class SceneChanger : MonoBehaviour
{
    //GLOBAL VARIALBES

    //public KeyCode sceneKey; //set key to change scene in Inspector
    public int sceneNumber; //set Scene Number in Inspector
                            //essentially does the same thing as sceneID in the Build Settings
                            //Start = 1, Main = 2, End = 3

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //BASIC KEY CHECK CODE -> MOVE TO SPECIFIC SCENE FUNCTIONS WHEN DONE
        //if (Input.GetKey(KeyCode.Space)) //if Space is pressed, called as long as key is pressed
        //if (Input.GetKeyDown(KeyCode.Space)) //if Space is pressed, called only once
        ////if (Input.GetKeyDown(sceneKey)) //if sceneKey is pressed, called only once
        //{
        //    //Debug.Log("Space pressed"); //print to console
        //    //Debug.Log("sceneKey pressed"); //print to console
        //    EndScene(); //call EndScene() function
        //}
        if (sceneNumber == 1) //if Start Scene
        {
            MainScene(); //call MainScene() / Load Main Scene
        } else if (sceneNumber == 2) //if Main Scene
        {
            EndScene(); //call EndScene() / Load End Scene
        } else if (sceneNumber == 3) //if End Scene
        {
            StartScene(); //call Start Scene /Load Start Scene
        }
    }

    public void StartScene() //go to Start Scene
    {
        //Debug.Log("StartScene() Called"); //print to console
        //SceneManager.LoadScene("Start Scene"); //Load Start Scene

        if (Input.GetKeyDown(KeyCode.S))
        {
            //Debug.Log("StartScene() Called"); //print to console
            SceneManager.LoadScene("Start Scene"); //Load Start Scene
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            //Debug.Log("MainScene() Called"); //print to console
            SceneManager.LoadScene("Main Scene"); //Load Main Scene
        }
    }

    public void MainScene() //go to Main Scene
    {
        //Debug.Log("MainScene() Called"); //print to console
                                         //SceneManager.LoadScene("Main Scene"); //Load Main Scene

        if (Input.GetKeyDown(KeyCode.Return))
        {
            //Debug.Log("MainScene() Called"); //print to console
            SceneManager.LoadScene("Main Scene"); //Load Main Scene
        }
    }

    public void EndScene() //go to End Scene when a key is pressed
    {
        //if (Input.GetKey(KeyCode.Space)) //if Space is pressed, called as long as key is pressed
        if (Input.GetKeyDown(KeyCode.Space)) //if Space is pressed, called only once
        //if (Input.GetKeyDown(sceneKey)) //if sceneKey is pressed, called only once
        {
            //Debug.Log("EndScene() Called"); //print to console
            SceneManager.LoadScene("End Scene"); //Load End Scene
        }
        //Debug.Log("EndScene() Called"); //print to console
        //SceneManager.LoadScene("End Scene"); //Load End Scene
                                             //NOTE: You need to import all the scenes you're switching between
                                             //in your build settings before this will work!
    }

    //CHANGE SCENE W/ BUTTON AND SCENE ID.
    //This is the more efficient way w/o having to write a specific new function for each scene change (which we already have for keycode checks)
    public void MoveToScene(int sceneID) //added in a "value parameter", similar to our Collision 2D code!
        //Here, I've declared and am grabbing values for a new int variable "sceneID"
    {
        //NOTE: You will need to add the default Event System Object back to your hierarchy to recognize mouse clicks

        //Debug.Log("MoveToScene Called"); //print to console
        //SceneManager.LoadScene("End Scene"); //call a scene specifically by it's name
        //OR
        SceneManager.LoadScene(sceneID); //load a scene based on its Scene ID # in Build Settings.
                                         //Set this number in the Inspector
                                         //Unity Documentation on LoadScene: https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadScene.html
    }

}
