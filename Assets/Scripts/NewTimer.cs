using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewTimer : MonoBehaviour
{
    float currentTime_new;
    public static int entry_condition;
    float startingTime_new = 5f;
    public static int exit_condition;
    [SerializeField] Text countdownText_new;

    // Start is called before the first frame update
    void Start()
    {
        currentTime_new = startingTime_new;

    }
    // Update is called once per frame
    void Update()
    {
        //if (GameOver.entry_restart_condition == 1)
        //{
        //countdownText_new.gameObject.SetActive(false);


        //}

        if (GameOpener.panel_counter == 1)
        {

            // GameOpener.Timer_Panel.SetActive(true);
            currentTime_new -= 1 * Time.deltaTime;
            Debug.Log("current time is " + currentTime_new);
            countdownText_new.text = currentTime_new.ToString("0");
            if (currentTime_new <= 1)
            {

                countdownText_new.text = "GO!";


                // countdownText_new.gameObject.SetActive(false);

            }
            if (currentTime_new <= 0)
            {
                currentTime_new = 5f;
                countdownText_new.gameObject.SetActive(false);
                // Destroy(GameOpener.Timer_Panel);
                exit_condition = 1;

            }





        }

    }
}
