using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float currentTime;
    public float startingTime = 30f;

    [SerializeField] Text countdownText;
    void Start()
    {
        currentTime = startingTime;
    }
    void Update()
    {

        currentTime -= 1 * Time.deltaTime;
        //Debug.Log("current time is " + currentTime);
        countdownText.text = "Timer: " + currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            // Your Code Here
        }
        if(Collision.count == 3)
        {
            currentTime = Time.deltaTime;
        }
    }
}
