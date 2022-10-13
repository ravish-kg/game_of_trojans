using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public static float currentTime;
    public float startingTime = 30f;
    [SerializeField] Text countdownText;
    public GameObject MazeChangeText;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        //Debug.Log("current time is " + currentTime);
        countdownText.text = "Timer: " + currentTime.ToString("0");


        if (MazeChangeText)
        {

            if (currentTime.ToString("0") == "20")
            {
                MazeChangeText.SetActive(true);
                MazeChangeText.GetComponent<TMP_InputField>().text = "Maze change in";
            }
            else if (currentTime.ToString("0") == "19")
            {
                MazeChangeText.SetActive(true);
                MazeChangeText.GetComponent<TMP_InputField>().text = "3";
            }
            else if (currentTime.ToString("0") == "18")
            {
                MazeChangeText.SetActive(true);
                MazeChangeText.GetComponent<TMP_InputField>().text = "2";
            }
            else if (currentTime.ToString("0") == "17")
            {
                MazeChangeText.SetActive(true);
                MazeChangeText.GetComponent<TMP_InputField>().text = "1";
            }
            
            else
            {
                MazeChangeText.SetActive(false);
            }
        }

        

        if (currentTime <= 0)
        {
            currentTime = 0;
        }
        if (Collision.count == 3)
        {
            currentTime = Time.deltaTime;
        }
    }
}
