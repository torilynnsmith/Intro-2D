using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeNoise : MonoBehaviour
{
    //This is an Audio Manager! Attach it to an empty Game Object named Audio Manager
    //Play Background Music in Unity that doesn't destroy b/w scenes
    //1. Show how to make music automatically play on awake version first.

    //GLOBAL VARIABLES
    //music

    //you want to declare instances so that you don't duplicate Audio Manager objects (if you happened to have different ones across your scenes)
    private static MakeNoise instance = null; //static variables are shared by all instances of a class. This means it preserves its values when "out of scope" or outside of the loaded scene
    public static MakeNoise Instance //
    {
        get { return instance; } //WHERE I LEFT OFF. ADD NOTES ON WHAT THIS DOES HERE
    }


    // Start is called before the first frame update
    void Start()
    {
        //you can always get the component through code instead of the inspector
        //source = GetComponent<AudioSource>(); //get the audio source component at start from the object this script is attached to. 
    }

    //Awake is called once when the script instance is loaded
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject); 
        //don't destory the target object when loading a new Scene
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    //Play the Sound

}
