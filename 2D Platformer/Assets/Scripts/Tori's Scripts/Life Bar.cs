using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //add the unity UI library

public class LifeBar : MonoBehaviour
{
    //UI INSTRUCTIONS
    //1. Add a Canvas. Add an Image to the canvas.
    //2. Add the bar sprite to the Image. Click "set native size" in the inspector to prevent any weird stretching. Rename the Image Object as "Border".
    //3. Create an empty game object on the cavas and rename it "Health Bar". Make it the same size as your "Border" image using the Rect tool.
    //4. Parent the Border Image to the Health Bar. This will act as a "Parent Object" to keep your other sprites organized and grouped together. 
    //5. Add an Image as a child to the Health Bar. Name it "Fill". Order it ABOVE your Border.
    //6. Open "Anchor Presets" in the Fill's Rect Transform. Hold down alt/opt and select the bottom right. This will set the scale and anchor points to that of our health bar. 
    //7. We can now scale just the Fill to create demo of our health values going up or down. Change the color to whatever you please. 
    //8. Add a Slider Component to your Health Bar. Make it "non-interactable", change the transition & navigation to "none" to ensure it's a static object we can only alter through code.
    //9. Drag your Fill object into the Fill Rect of the Slider. Now we can adjust the slider.
    //10. Select your Border. Change the Anchor Preset to the bottom right object. DO NOT HOLD ALT/OPT FOR THIS ONE. This will only set the anchors, not the scale.
    //11. Add the heart. Add an Image as a child to the Health bar. Drag in the heart sprite and click set native size. Set the Anchor Point to Middle Left
    //12. In the Slider component, change the Max Value to whatever you want your max health to be. Check Whole numbers to use ints instead of floats
    //13 Add in your Health Bar Script to the Health bar. Drag in your Health Bar to get the slider component.  
    //14. Drag your Health Bar into the Health Bar field on your player controller script. 

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
