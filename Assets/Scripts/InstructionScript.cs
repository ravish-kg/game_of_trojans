using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class InstructionScript : MonoBehaviour
{
    public static string uname;
    public void btn_change_scene(string scene_name)
    {
        uname=Environment.UserName+Time.time;
        // Debug.Log("!!Username: "+uname);
        GameOpener.panel_counter = 0;
        TutorialManager.popUpIndex = 0;
        NewTimer.exit_condition = 0;
        
        PlayerPrefs.SetString("selectedLevel", scene_name);

        SceneManager.LoadScene("LeaderBoard");
    }
} 