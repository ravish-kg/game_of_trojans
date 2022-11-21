using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerName : MonoBehaviour
{
    // Start is called before the first frame update

    public static string name = "vaibhav";

    public Text inputText;

    public Text invalidText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // name = (string)inputText.text;
        
    }

    public void submit(){
        name = (string)inputText.text;
        if(name == null || name == ""){
            invalidText.text = "Please enter valid name";
            return;
        }
        else if(name.Length < 3){
            invalidText.text = "Name must have minimum 3 characters";
            return;
        }
        else if(name.Length > 10){
            invalidText.text = "Name can have maximum 6 characters";
            return;
        }
        Debug.Log(name);
        
        invalidText.text = "";
        SceneManager.LoadScene("Menu");

        PlayerPrefs.SetString("playerName", name);
    }
}
