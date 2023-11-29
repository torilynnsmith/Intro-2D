using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepMe : MonoBehaviour
{
    //GLOBAL VARIABLES
    public static GameObject instance; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Awake is called once when a script instance is loaded
    private void Awake()
    {
        if(instance == null) //if the instance of the game object this script is on doesn't exist
        {
            Debug.Log("Game Manager not destroyed");
            instance = gameObject;
            DontDestroyOnLoad(gameObject); 
        }
        else //if the instance DOES already exist in the scene
        {
            Debug.Log("Game Manager DESTROYED");
            Destroy(gameObject); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
