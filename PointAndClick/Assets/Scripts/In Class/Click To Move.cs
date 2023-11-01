using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    //GLOBAL VARIABLES
    public float speed = 5f;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        //set starting locaiton
        target = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("click to move");

            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            target.z = transform.position.z; 
        }

        //MOVE THE OBJECT
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime); 
    }
}
