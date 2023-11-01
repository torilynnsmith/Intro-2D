using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragging : MonoBehaviour
{
    //NOTE: ANY DRAGGABLE SPRITE MUST HAVE A COLLIDER!!!

    //GLOBAL VARIABLES
    public bool isDragging = false;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        //if the object is being dragged
        if (isDragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;


        }
    }

    //START DRAGGING
    private void OnMouseDown()
    {
        //Record the difference b/w the draggable object's cnter and the clicked point on the camera's view
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        isDragging = true;
        //Debug.Log("isDragging = " + isDragging); 
    }


    //STOP DRAGGING
    private void OnMouseUp()
    {
        isDragging = false;
        //Debug.Log("isDragging = " + isDragging);
    }
}
