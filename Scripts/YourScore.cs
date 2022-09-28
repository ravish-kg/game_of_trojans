using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YourScore : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreTxt;
    public ScoreManager sm;
    void Start()
    {
        int sc = (int)sm.sr;
        scoreTxt.text = "Your Score : " + sc.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
