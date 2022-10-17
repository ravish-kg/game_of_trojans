using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionScript : MonoBehaviour
{
    public void btn_change_scene(string scene_name)
    {
        GameOpener.panel_counter = 0;
        TutorialManager.popUpIndex = 0;
        NewTimer.exit_condition = 0;
        SceneManager.LoadScene(scene_name);
    }
}