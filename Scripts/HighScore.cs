using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    // Start is called before the first frame update
    public Text highscore;
    public ScoreManager sm;
    void Start()
    {

        int s = (int)sm.sr;
        if(!PlayerPrefs.HasKey("highscore")){
            PlayerPrefs.SetInt("highscore", 0);
        }
        if(s > PlayerPrefs.GetInt("highscore")){
            PlayerPrefs.SetInt("highscore", s);
        }
        highscore.text = "HIGH SCORE : " + PlayerPrefs.GetInt("highscore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
