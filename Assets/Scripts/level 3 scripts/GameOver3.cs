// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;

// public class GameOver3 : MonoBehaviour
// {
//     public static float timeCarryOver = 0f;
//     public static bool carryOverFlag = false;

//     public GameObject gameOverPanel;
//     public Text equation_panel;
//     public Text threshold_panel;
//     public Text score_panel;
//     public static int entry_restart_condition;
//     public Text gameOver;
//     private string Gameo;
//     private string objectd;
//     private string BASE_URL="https://docs.google.com/forms/d/e/1FAIpQLSe9yNVWR0ab2MrXVYWYKbxWDa_rYX-YvVdmvteH6DTe190ifw/formResponse";
//     private int flag = 0;

//     void Awake(){
//         // Debug.Log("Awake");
//         gameOverPanel.SetActive(false);
//     }

//     void Start() {
//         carryOverFlag = true;
//     }

//     // Update is called once per frame
//     void Update() {
//         if (Collision3.count == 3 || Timer3.currentTime == 0) {
//             gameOverPanel.SetActive(true);
//             if(scoreCalc.score >= int.Parse(Collision3.threshold)) {
//                 gameOver.text = "Success! Level complete!";
//                 equation_panel.text = "Equation: " + Collision3.math_eq;

//                 if(GameOver.carryOverFlag){
//                     GameOver.timeCarryOver = Timer3.sTime - Timer3.cTime;
//                     if(GameOver.timeCarryOver <= 0){
//                         GameOver.timeCarryOver = 0f;
//                     }
//                     else if(GameOver.timeCarryOver < 10){
//                         GameOver.timeCarryOver = 5;
//                     }
//                     else if(GameOver.timeCarryOver < 20){
//                         GameOver.timeCarryOver = 3;
//                     }
//                     else{
//                         GameOver.timeCarryOver = 2;
//                     }
//                     Debug.Log("Time Carry Over : " + timeCarryOver);
//                     GameOver.carryOverFlag = false;
//                 }
//             }
//             else {
//                 IEnumerator Post(string gameo, string objectd){
//                     WWWForm form = new WWWForm();
//                     form.AddField("entry.230878790",gameo);
//                     form.AddField("entry.558777034",objectd);

//                     byte[] rawd= form.data;
//                     WWW www = new WWW(BASE_URL, rawd);
//                     yield return www;

//                 }
//                 if(flag == 0) {
//                     // Gameo = "GameEnd~Timer$"+Time.time+"~equation$"+Equation.display+"~threshold$"+Collision3.threshold+"~Order$"+Collision3.count+"\n";
//                     Gameo = "GameEnd~Timer$"+Time.time+"~equation$"+Equation.display+"~threshold$"+Collision3.threshold+"~Order$"+Collision3.count+"~Level$"+SceneManager.GetActiveScene().name+"~Sessionid$"+Player.sessionid+"~Username$"+InstructionScript.uname+"\n";
                    
//                     StartCoroutine(Post(Gameo,""));
//                     flag = 1;
//                 }

//                 if (Timer3.currentTime == 0) {
//                     gameOver.text = "Time's up! You Lost :(";
//                     equation_panel.text = "Equation Incomplete";
//                 }
//                 else {
//                     gameOver.text = "Game Over! You Lost :(";
//                     equation_panel.text = "Equation: " + Collision3.math_eq;
//                 }
//             }
//             threshold_panel.text = "Threshold: "+ Collision3.threshold;
//             score_panel.text = "Score: " + scoreCalc.score;
//         }
//     }

//     public void Restart() {
//         Debug.Log(SceneManager.GetActiveScene().name);
//         gameOverPanel.SetActive(false);
//         GameOpener.panel_counter = 0;
//         entry_restart_condition = 1;
//         NewTimer.exit_condition = 0;
//         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//         // SceneManager.LoadScene("Level1");
//         scoreCalc.score = 0;
//         Collision3.count = 0;
//         timeCarry.textTimeCarry = 0f;
//         GameOver.timeCarryOver = 0f;
//         carryOverFlag = false;
//         GameOver.carryOverFlag = false;
//         rotation.isRotationCompleted = 0;
//     }

//     public void home() {
//         gameOverPanel.SetActive(false);
//         GameOpener.panel_counter = 0;
//         NewTimer.exit_condition = 0;
//         SceneManager.LoadScene("Menu");
//         Collision3.count = 0;
//         scoreCalc.score = 0;
//         timeCarryOver = 0f;
//         timeCarry.textTimeCarry = 0f;
//         GameOver.timeCarryOver = 0f;
//         carryOverFlag = false;
//         GameOver.carryOverFlag = false;
//         rotation.isRotationCompleted = 0;
//     }

//     public void loadLevel1(){
//         GameOpener.panel_counter = 0;
//         NewTimer.exit_condition = 0;
//         SceneManager.LoadScene("Level1");
//         scoreCalc.score = 0;
//         Collision3.count = 0;
//     }

//     public void loadLevel2(){
//         GameOpener.panel_counter = 0;
//         NewTimer.exit_condition = 0;
//         SceneManager.LoadScene("Level2_tutorial");
//         scoreCalc.score = 0;
//         Collision3.count = 0;
//     }

//     public void loadLevel3(){
//         GameOpener.panel_counter = 0;
//         NewTimer.exit_condition = 0;
//         SceneManager.LoadScene("Level3_tutorial");
//         scoreCalc.score = 0;
//         Collision3.count = 0;
//     }

// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver3 : MonoBehaviour
{
    public static float timeCarryOver = 0f;
    public static bool carryOverFlag = false;
    public GameObject nextLevelButton;
    public GameObject gameOverPanel;
    public Text equation_panel;
    public Text threshold_panel;
    public Text score_panel;
    public static int entry_restart_condition;
    public Text gameOver;
    private string Gameo;
    private string objectd;
    private string BASE_URL="https://docs.google.com/forms/d/e/1FAIpQLSe9yNVWR0ab2MrXVYWYKbxWDa_rYX-YvVdmvteH6DTe190ifw/formResponse";
    private int flag = 0;

    void Awake(){
        gameOverPanel.SetActive(false);
    }

    void Start() {
        carryOverFlag = true;
    }

    // Update is called once per frame
    void Update() {
        if (Collision3.count == 3 || Timer3.currentTime == 0) {
            gameOverPanel.SetActive(true);
            if(scoreCalc.score >= int.Parse(Collision3.threshold)) {
                gameOver.text = "Success! Level complete!";
                equation_panel.text = "Equation: " + Collision3.math_eq;
                nextLevelButton.SetActive(true);

                if(carryOverFlag){
                    timeCarryOver = Timer3.sTime - Timer3.cTime;
                    if(timeCarryOver <= 0){
                        timeCarryOver = 0f;
                    }
                    Debug.Log("Time Carry Over : " + timeCarryOver);
                    carryOverFlag = false;
                }
            }
            else {
                IEnumerator Post(string gameo, string objectd){
                    WWWForm form = new WWWForm();
                    form.AddField("entry.230878790",gameo);
                    form.AddField("entry.558777034",objectd);

                    byte[] rawd= form.data;
                    WWW www = new WWW(BASE_URL, rawd);
                    yield return www;

                }
                if(flag == 0) {
                    Gameo = "GameEnd~Timer-"+Time.time+"~equation-"+Equation.display+"~threshold-"+Collision3.threshold+"~Order-"+Collision3.count+"\n";
                    StartCoroutine(Post(Gameo,""));
                    flag = 1;
                }

                if (Timer3.currentTime == 0) {
                    gameOver.text = "Time's up! You Lost :(";
                    equation_panel.text = "Equation Incomplete";
                }
                else {
                    gameOver.text = "Game Over! You Lost :(";
                    equation_panel.text = "Equation: " + Collision3.math_eq;
                }
            }
            threshold_panel.text = "Threshold: "+ Collision3.threshold;
            score_panel.text = "Score: " + scoreCalc.score;
        }
    }

    public void Restart() {
        // Debug.Log(SceneManager.GetActiveScene().name);
        gameOverPanel.SetActive(false);
        nextLevelButton.SetActive(false);
        GameOpener.panel_counter = 0;
        entry_restart_condition = 1;
        NewTimer.exit_condition = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        scoreCalc.score = 0;
        Collision3.count = 0;
        timeCarryOver = 0f;
        carryOverFlag = false;
        rotation.isRotationCompleted = 0;
    }

    public void home() {
        Debug.Log("Inside Home");
        gameOverPanel.SetActive(false);
        nextLevelButton.SetActive(false);
        GameOpener.panel_counter = 0;
        NewTimer.exit_condition = 0;
        SceneManager.LoadScene("Menu");
        Collision3.count = 0;
        scoreCalc.score = 0;
        timeCarryOver = 0f;
        carryOverFlag = false;
        timeCarry.textTimeCarry = 0f;
        GameOver.timeCarryOver = 0f;
        rotation.isRotationCompleted = 0;
    }

    public void loadLevel1(){
        GameOpener.panel_counter = 0;
        NewTimer.exit_condition = 0;
        SceneManager.LoadScene("Level1");
        nextLevelButton.SetActive(false);
        scoreCalc.score = 0;
        Collision3.count = 0;
    }

    public void loadLevel2(){
        GameOpener.panel_counter = 0;
        NewTimer.exit_condition = 0;
        SceneManager.LoadScene("Level2_tutorial");
        nextLevelButton.SetActive(false);
        scoreCalc.score = 0;
        Collision3.count = 0;
    }

    public void loadLevel3(){
        GameOpener.panel_counter = 0;
        NewTimer.exit_condition = 0;
        SceneManager.LoadScene("Level3_tutorial");
        nextLevelButton.SetActive(false);
        scoreCalc.score = 0;
        Collision3.count = 0;
    }

    public void loadLevel1set2(){
        rotation.isRotationCompleted = 0;
        GameOpener.panel_counter = 0;
        NewTimer.exit_condition = 0;
        SceneManager.LoadScene("Level1_set2");
        nextLevelButton.SetActive(false);
        scoreCalc.score = 0;
        Collision3.count = 0;
    }

    public void loadLevel2set2(){
        GameOpener.panel_counter = 0;
        NewTimer.exit_condition = 0;
        SceneManager.LoadScene("Level2_set2");
        nextLevelButton.SetActive(false);
        scoreCalc.score = 0;
        Collision3.count = 0;
    }

    public void loadLevel4(){
        rotation.isRotationCompleted = 0;
        GameOpener.panel_counter = 0;
        NewTimer.exit_condition = 0;
        SceneManager.LoadScene("Level4_tutorial");
        nextLevelButton.SetActive(false);
        scoreCalc.score = 0;
        Collision3.count = 0;
    }

}