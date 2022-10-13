using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreCalc : MonoBehaviour
{
    public Text scoreText;
    public static int score = 0;
    public int sr;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (score > 0)
            scoreText.text = "Score: " + ((int)score).ToString();
        else
            scoreText.text = "";
        sr = score;
    }
}
