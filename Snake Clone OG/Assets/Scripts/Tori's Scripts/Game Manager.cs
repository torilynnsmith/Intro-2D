using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //use the Unity Library for Text Mesh Pro UI

public class GameManager : MonoBehaviour
{
    //GLOBAL VARIABLES
    public TextMeshProUGUI foodScoreText; //Text Object for Food Score Text

    public int foodScore = 0; //declare and set initial Food Score

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //update the food score
        foodScoreText.text = "Score: " + foodScore; //update foodScoreText UI
    }

    //To be run when Food is Eaten....
    public void FoodEaten()
    {
        foodScore++; //add 1 to food score
        Debug.Log("Score Change. foodScore = " + foodScore); //print to console
    }
}
