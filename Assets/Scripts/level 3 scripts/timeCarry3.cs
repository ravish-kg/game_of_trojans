using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeCarry3 : MonoBehaviour
{
    // Start is called before the first frame update
    public Text carryOverText;
    public static float textTimeCarry;
    
    public int under10 = 5;
    public int under20 = 3;
    public int under30 = 2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(textTimeCarry == 0){
            carryOverText.text = "";
        }
        else if(textTimeCarry >= 20){
            carryOverText.text = "You completed the game under 30 seconds. You gained " + under30 + " seconds to the next level.";
        }
        else if(textTimeCarry >= 10){
            carryOverText.text = "You completed the game under 20 seconds. You gained " + under20 + " seconds to the next level.";
        }
        else if(textTimeCarry > 0){
            carryOverText.text = "You completed the game under 10 seconds. You gained " + under10 + " seconds to the next level.";
        }
    }
}
