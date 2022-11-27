using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class leaderboard_Instruction : MonoBehaviour
{
    public static string uname;
    public static string levelName;
    public void btn_change_scene(string scene_name)
    {
        uname=Environment.UserName+Time.time;
        // Debug.Log("!!Username: "+uname);
        GameOpener.panel_counter = 0;
        TutorialManager.popUpIndex = 0;
        NewTimer.exit_condition = 0;
        
        levelName = scene_name;

        Debug.Log("Instructions");
        Debug.Log(levelName);

        SceneManager.LoadScene("LeaderBoard");
    }

    public void home(){
        SceneManager.LoadScene("Menu");
    }

    public void loadleaderboard(){
        SceneManager.LoadScene("Leaderboard_Levels");
    }
}
