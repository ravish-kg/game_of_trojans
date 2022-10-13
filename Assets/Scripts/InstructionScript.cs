using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionScript : MonoBehaviour
{
    public void btn_change_scene(string scene_name) {
        TutorialManager.popUpIndex = 0; 
        SceneManager.LoadScene(scene_name); 
    }
}