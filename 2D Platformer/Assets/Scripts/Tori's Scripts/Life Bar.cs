using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //add the unity UI library

public class LifeBar : MonoBehaviour
{
    //GLOBAL VARIABLES
    public Slider slider; //declare & set slider UI variable in the inspector

    //changr color of bar
    public Gradient gradient; //declare and set gradient variable in inspector
    public Image fill; //declare and set an Image variable in inspector

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //NOTE: these voids are public so we can call them from other scripts
    //set the max value of the health bar
    public void SetMaxHealth (int health)
    {
        slider.maxValue = health; //set health to the max value of our slider component
        slider.value = health; //set the value of our slider comonent to health

        //change gradient color
        //set the color of the Image's fill to the gradient value
        fill.color = gradient.Evaluate(1f); //set gradient color to green
            //on our gradient sclae, 0 is the left & 1 is the right
    }

    //Change the Health Slider
    public void SetHealth(int health) //declare a void & feed it a variable (in this case an integer) 
    {
        slider.value = health; //change the value parameter of the slider to equal the value of health

        fill.color = gradient.Evaluate(slider.normalizedValue); //change the fill color according the health int value
        //normalizeValue takes an amount (ex. 0-20) and sets it proportionally equal to 0-1. 
    }
}
