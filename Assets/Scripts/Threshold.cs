using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Threshold : MonoBehaviour
{
    public Text thresholdText;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        thresholdText.text = "Threshold: "+Collision.threshold;
    }
}