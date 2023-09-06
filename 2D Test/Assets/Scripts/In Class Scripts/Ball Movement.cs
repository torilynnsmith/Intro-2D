using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    //UNIVERSAL VARIABLES
    private float xDir; // declare x direction
    private float yDir; // declare y direction

    public Rigidbody2D rbBall; //declare and set rbBall Rigidbody2D from the Inspector
    public float force = 200; //declared and set force from the inspector 

    //private float ballSpeed = 5; 

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World");

        //MAKE BALL MOVE IN RANDOM DIRECTION AT START
        xDir = Random.Range(0, 2) == 0 ? -1 : 1; //if xDir=-1 it'll move left, if xDir = 1 it'll move right
        yDir = Random.Range(0, 2) == 0 ? -1 : 1; // if yDir=-1 it'll move down, if yDir = 1, it'll move up

        Vector3 direction = new Vector3(xDir, yDir, 0);//declared and set a new Vector3 variable, named direction
        rbBall.AddForce(direction * force); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
