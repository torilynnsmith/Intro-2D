using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunch : MonoBehaviour
{
    //THIS SCRIPT LIVES ON THE PLAYER OBJECT, NOT THE LAUNCH POINT

    //GLOBAL VARIABLES
    public GameObject projectilePrefab;
    public Transform launchPoint;

    //Projectile fire cooldown timer
    public float shootTime; //cooldown time amount b/w projectiles firing
    public float shootCountDown; //the cooldown timer itself

    // Start is called before the first frame update
    void Start()
    {
        shootCountDown = shootTime; 
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Fire1"))
        if (Input.GetMouseButtonDown(0) && shootCountDown <= 0)
        {
            Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
            //Debug.Log("Left Mouse Clicked");

            shootCountDown = shootTime; 
        }

        shootCountDown -= Time.deltaTime; //reduce shoot CountDown time
    }
}
