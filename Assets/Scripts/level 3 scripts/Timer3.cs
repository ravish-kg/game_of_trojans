using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer3 : MonoBehaviour
{
    public static float currentTime, temp;
    public static float cTime = 0f;
    public static float sTime = 0f;
    public static float startingTime = 30f;
    [SerializeField] Text countdownText;
    public GameObject MazeChangeText;

    void Start()
    {
        currentTime = startingTime + GameOver.timeCarryOver;
        temp = startingTime;
        sTime = startingTime + GameOver.timeCarryOver;
        timeCarry3.textTimeCarry = GameOver.timeCarryOver;
        GameOver.timeCarryOver = 0f;
    }

    void Update()
    {
        if (NewTimer.exit_condition == 1)
        {
            currentTime -= 1 * Time.deltaTime;
            temp -= 1 * Time.deltaTime;
            cTime = currentTime;
            //Debug.Log("current time is " + currentTime);
            countdownText.text = "Timer: " + currentTime.ToString("0");


            if (MazeChangeText)
            {

                if (temp.ToString("0") == "20")
                {
                    MazeChangeText.SetActive(true);
                    MazeChangeText.GetComponent<TMP_InputField>().text = "Maze change in";
                }
                else if (temp.ToString("0") == "19")
                {
                    MazeChangeText.SetActive(true);
                    MazeChangeText.GetComponent<TMP_InputField>().text = "3";
                }
                else if (temp.ToString("0") == "18")
                {
                    MazeChangeText.SetActive(true);
                    MazeChangeText.GetComponent<TMP_InputField>().text = "2";
                }
                else if (temp.ToString("0") == "17")
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
            if (Collision3.count == 3)
            {
                currentTime = Time.deltaTime;
            }
        }
    }
}
