using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballLaunch : MonoBehaviour
{
    //THIS SCRIPT LIVES ON THE PLAYER, NOT THE LAUNCH POINT

    //GLOBAL VARIABLES
    public GameObject projectilePrefab; //declare and set the projectilePrefab GameObject in the Inspector
    public Transform launchPoint; //the position from which a projectile will launch

    public float shootTime; //cooldown time amount b/w projectile firing, set in inspector
        //currently set to 0.5
    public float shootCounter; //the cooldown timer itself, set in inspector

    // Start is called before the first frame update
    void Start()
    {
        shootCounter = shootTime; //set the shootCounter timer equal to shootTime when the scene starts
    }

    // Update is called once per frame
    void Update()
    {
        //if the Fire Button (L Mouse) is pressed AND the shootCounter is reset
        if(Input.GetButtonDown("Fire1") && shootCounter <= 0)
            //returns true for the frame Fire1 (Left Mouse) is pressed
        {
            Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
            //Instantiate needs 3 things! (1,2,3)
            //1. what are you instantiating?
            //2. Where are you instantiating it?
            //3. What is the rotation you're instantiating it with? USE Quaternion.identity

            shootCounter = shootTime; //restart the cooldown time to disable ability to shoot
        }

        shootCounter -= Time.deltaTime; //reduce cooldown time
    }
}
