using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    // Start is called before the first frame update
    public float currentTime1 = 0f;
    public float startTime1;
    public GameObject hollowNumber;
    private SpriteRenderer c;
    // [SerializeField] Text countdownText1;
    public GameObject mazeChangeText;

    [SerializeField] Text remainingDuration;

    void Start() {
        currentTime1 = startTime1;
    }

    // Update is called once per frame
    void Update() {
        // if (mazeChangeText)
        // {
        //     if (Timer.currentTime.ToString("0").Equals("20"))
        //     {
        //         currentTime1 = currentTime1 + (5 * Time.deltaTime);
        //         int curr = int.Parse(remainingDuration.text);
        //         curr = curr + 5;

        //         Debug.Log(curr);

        //         remainingDuration.text = curr + "";
        //     }
        // }

        if(remainingDuration != null) {
            currentTime1 -= 1 * Time.deltaTime;
            remainingDuration.text = currentTime1.ToString("0");

            if (mazeChangeText)
            {
                if (Timer.currentTime.ToString("0").Equals("20"))
                {
                    currentTime1 = currentTime1 + (5 * Time.deltaTime);
                }
            }
            

            // Debug.Log("current time="+countdownText.text);
            // if(currentTime1 <= 0) {
            //     currentTime1 = 0;  
            //     remainingDuration.text = ""; 
            //     Destroy(remainingDuration.gameObject); 
            //     Destroy(gameObject);
            // }
        }
        // if(Collision.count == 3) {
        //     Destroy(countdownText1.gameObject);
        //     Destroy(gameObject);
        // }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        // if(col.tag == "Player") {
        //     currentTime1 = 0;
        //     countdownText1.text = ""; 
        //     Destroy(countdownText1.gameObject);  
        // }
    }
}