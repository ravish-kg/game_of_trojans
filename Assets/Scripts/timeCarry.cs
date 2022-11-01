using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeCarry : MonoBehaviour
{
    // Start is called before the first frame update

    public Text carryOverText;
    public static float textTimeCarry;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(textTimeCarry == 5){
            carryOverText.text = "Hurrah! You have completed the level within 10 seconds!!" + (int)textTimeCarry +  " will be added to the next level.";
        }
        else if(textTimeCarry == 3){
            carryOverText.text = "Hurrah! You have completed the level within 20 seconds!!" + (int)textTimeCarry +  " will be added to the next level.";
        }
        else if(textTimeCarry == 2){
            carryOverText.text = "Hurrah! You have completed the level within 30 seconds!!" + (int)textTimeCarry +  " will be added to the next level.";
        }
        else{
            carryOverText.text = "";
        }
    }
}
