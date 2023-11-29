using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //use Scene Managment Library

//THIS IS THE IN CLASS SCRIPT

public class SceneSwitcher : MonoBehaviour
{
    //GLOBAL VARIABLE
    public int sceneNumber;
        //Main Menu = 1, Game Scene = 2, Game Over = 3

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneNumber == 1) //if in Main Menu Scene (1)/start Scene
        {
            GameScene(); //call game scene function
        } else if (sceneNumber == 2) //if in Game Scene
        {
            GameOver(); //call game 0ver function
        } else if (sceneNumber == 3) //if in Game Over Scene
        {
            Retry(); //call main menu function
        }

    }

    public void GameScene()
    {
        //LOAD GAME SCENE (FROM MAIN MENU)
        if (Input.GetKeyDown(KeyCode.Return)) //if Enter/Return key is pressed, first frame only
        {
            Debug.Log("Enter Key Pressed"); //print to console
            SceneManager.LoadScene("In Class Level 1"); //load Game Scene
        }
    }

    public void GameOver()
    {
        //LOAD GAME OVER SCENE (FROM GAME SCENE)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space Key Pressed");
            SceneManager.LoadScene("Game Over");
        }
    }

    public void Retry()
    {
        //LOAD MAIN MENU/GAME SCENE (FROM GAME OVER SCENE)
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("M Key Pressed");
            SceneManager.LoadScene("Main Menu");
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("G Key Pressed");
            SceneManager.LoadScene("Game Scene");
        }
    }

    public void GoToScene(int sceneID)
    {
        //Debug.Log("GoToScene() called."); //print to console
        Debug.Log("sceneID = " + sceneID);
        SceneManager.LoadScene(sceneID); 
    }

}
