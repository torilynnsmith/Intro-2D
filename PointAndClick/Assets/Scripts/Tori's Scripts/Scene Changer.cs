using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //use Scene Management Library

public class SceneChanger : MonoBehaviour
{
    //GLOBAL VARIALBES

    //public KeyCode sceneKey; //set key to change scene in Inspector
    public int sceneNumber; //set Scene Number in Inspector
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
            Debug.Log("StartScene() Called"); //print to console
            SceneManager.LoadScene("Start Scene"); //Load Start Scene
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("MainScene() Called"); //print to console
            SceneManager.LoadScene("Main Scene"); //Load Main Scene
        }
    }

    public void MainScene() //go to Main Scene
    {
        //Debug.Log("MainScene() Called"); //print to console
                                         //SceneManager.LoadScene("Main Scene"); //Load Main Scene

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("MainScene() Called"); //print to console
            SceneManager.LoadScene("Main Scene"); //Load Main Scene
        }
    }
    public void EndScene() //go to End Scene when a key is pressed
    {
        //if (Input.GetKey(KeyCode.Space)) //if Space is pressed, called as long as key is pressed
        if (Input.GetKeyDown(KeyCode.Space)) //if Space is pressed, called only once
        //if (Input.GetKeyDown(sceneKey)) //if sceneKey is pressed, called only once
        {
            Debug.Log("EndScene() Called"); //print to console
            SceneManager.LoadScene("End Scene"); //Load End Scene
        }
        //Debug.Log("EndScene() Called"); //print to console
        //SceneManager.LoadScene("End Scene"); //Load End Scene
                                             //NOTE: You need to import all the scenes you're switching between
                                             //in your build settings before this will work!
    }
}
