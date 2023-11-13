using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //add the unity UI Library

public class HealthBar : MonoBehaviour
{
    //GLOBARL VARIABLES
    public Slider slider; //declare & set slider UI in the inspector

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health; 
    }

    public void SetHealth(int health)
    {
        slider.value = health; 
    }


}
