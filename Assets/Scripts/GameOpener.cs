using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOpener : MonoBehaviour
{
    public GameObject Panel;
    public static GameObject Timer_Panel;
    public static int panel_counter;
    public void showHidePanel()
    {
        panel_counter = 1;
        if (panel_counter == 1)
        {

            Panel.gameObject.SetActive(false);
            Timer_Panel.gameObject.SetActive(true);





        }
        else
        {
            Panel.gameObject.SetActive(true);

        }
    }


}


