using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeNoise : MonoBehaviour
{
    //This is a singleton demo we're using to maintain a Game Manager! Attach it to an empty Game Manager Object in your first/starting scene

    //Play Background Music in Unity that doesn't destroy, restart, and/or overlap b/w scenes
    //1. Show how to make music automatically play on awake version first (attach to main camera)
    //2. Attach music to main camera in start scene to demonstrate the music restarting when the new scene loads
    //3. Write the following code to explain singletons
    //4. Attach music to Game Manager Object in start scene to demonstrate overlapping.
    //5. Attach music to Game Manager Object in main scene to demonstrate the singleton destroying the duplicate object and not restarting the music
    //6. reiterate how this is helpful for maintaining static info b/w scenes and how it reduces the need to add a game manager into every scene now 
   
    //GLOBAL VARIABLES

    //Singletons:you want to declare instances so that you don't duplicate the Audio Manager objects (if you happened to have different ones across your scenes)
    public static GameObject instance; //static variables are shared by all instances of a class. This means it preserves its values when "out of scope" or outside of the loaded scene
        //NOTE: even though this is a public static variable, it will not appear in the inspector. It is set through code by its mere existence


    // Start is called before the first frame update
    void Start()
    {
        //you can always get the component through code instead of the inspector
        //source = GetComponent<AudioSource>(); //get the audio source component at start from the object this script is attached to. 
        //Debug.Log("printed at start"); 
    }

    //Awake is called once when the script instance is loaded
    private void Awake()
    {
        //Debug.Log("printed at Awake");

        //when the new scene/instance of this script loads...
        if (instance == null) //if the instance of the game object this script is attached to does not exist when the new scene starts....
        {
            Debug.Log("Game Manager not destroyed."); //print to console
            instance = gameObject; //the new static instance becomes equal to this game object. It now exists! 
            DontDestroyOnLoad(gameObject); //don't destory the target object when loading a new Scene
        }
        else //if the instance DOES already exist in the scene...
        {
            Debug.Log("Game Manager DESTROYED."); //print to console
            Destroy(gameObject); //destroy the duplicate gameObject in the new scene so you don't have duplicates of things floating around and running code twice
        }
        //The above code is useful for maintaining information between scenes. This can apply to things like:
        //game managers, background music, save states, scores, etc. when moving b/w scenes.
    }


    // Update is called once per frame
    void Update()
    {
        
    }

}
