using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeCarry3 : MonoBehaviour
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
        if(textTimeCarry > 0){
            carryOverText.text = "You have gained " + (int)textTimeCarry + " seconds!!  It will be added to the next level.";
        }
        else{
            carryOverText.text = "";
        }
    }
}
