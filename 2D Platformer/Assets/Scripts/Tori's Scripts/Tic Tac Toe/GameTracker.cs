using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTracker : MonoBehaviour
{
    //Script Purpose: Keep track of who's turn it is

    //GLOBAL VARIABLES
    int spriteIndex = -1;

    //call this from your PlayerTurn script
    public int PlayerTurn()
    {
        spriteIndex++; //add 1 to sprite Index to track how many turns there have been
        return spriteIndex % 2; //divide spriteIndex by 2 and return the remainder int.
            //even numbers will return 0 (the X sprite), odds will return 1 (the O sprite)
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
