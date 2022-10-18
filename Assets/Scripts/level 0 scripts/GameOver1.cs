using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver1 : MonoBehaviour
{
    public static float timeCarryOver = 0f;
    public static bool carryOverFlag = false;

    public GameObject gameOverPanel;
    public GameObject nextLevelButton;

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
        // Debug.Log("Awake");
        gameOverPanel.SetActive(false);
        
    }

    void Start() {
        carryOverFlag = true;
    }

    // Update is called once per frame
    void Update() {
        if (Collision1.count == 3 || Timer1.currentTime == 0) {
            gameOverPanel.SetActive(true);
            if(scoreCalc.score >= int.Parse(Collision1.threshold)) {
                gameOver.text = "Success! Level complete!";
                equation_panel.text = "Equation: " + Collision1.math_eq;
                nextLevelButton.SetActive(true);

                if(carryOverFlag){
                    timeCarryOver = Timer1.sTime - Timer1.cTime;
                    if(timeCarryOver <= 0){
                        timeCarryOver = 0f;
                    }
                    else if(timeCarryOver > 20){
                        timeCarryOver = 2f;
                    }
                    else if(timeCarryOver > 10){
                        timeCarryOver = 3f;
                    }
                    else {
                        timeCarryOver = 5f;
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
                    Gameo = "GameEnd~Timer-"+Time.time+"~equation-"+Equation.display+"~threshold-"+Collision1.threshold+"~Order-"+Collision1.count+"\n";
                    StartCoroutine(Post(Gameo,""));
                    flag = 1;
                }

                if (Timer1.currentTime == 0) {
                    gameOver.text = "Time's up! You Lost :(";
                    equation_panel.text = "Equation Incomplete";
                }
                else {
                    gameOver.text = "Game Over! You Lost :(";
                    equation_panel.text = "Equation: " + Collision1.math_eq;
                }
            }
            threshold_panel.text = "Threshold: "+ Collision1.threshold;
            score_panel.text = "Score: " + scoreCalc.score;
        }
    }

    public void Restart() {
        Debug.Log("restart 1 = " + SceneManager.GetActiveScene().name);
        nextLevelButton.SetActive(false);
        gameOverPanel.SetActive(false);
        GameOpener.panel_counter = 0;
        entry_restart_condition = 1;
        NewTimer.exit_condition = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // SceneManager.LoadScene("Level1");
        scoreCalc.score = 0;
        Collision1.count = 0;
        timeCarryOver = 0f;
        carryOverFlag = false;
    }

    public void home() {
        gameOverPanel.SetActive(false);
        nextLevelButton.SetActive(false);
        GameOpener.panel_counter = 0;
        NewTimer.exit_condition = 0;
        SceneManager.LoadScene("Menu");
        Collision1.count = 0;
        scoreCalc.score = 0;
        timeCarryOver = 0f;
        carryOverFlag = false;
    }

    public void loadLevel1(){
        GameOpener.panel_counter = 0;
        NewTimer.exit_condition = 0;
        SceneManager.LoadScene("Level1");
        nextLevelButton.SetActive(false);
        scoreCalc.score = 0;
        Collision1.count = 0;
    }
    public void loadLevel2(){
        GameOpener.panel_counter = 0;
        NewTimer.exit_condition = 0;
        SceneManager.LoadScene("Level2_tutorial");
        nextLevelButton.SetActive(false);
        scoreCalc.score = 0;
        Collision1.count = 0;
        
    }

    public void loadLevel3(){
        GameOpener.panel_counter = 0;
        NewTimer.exit_condition = 0;
        SceneManager.LoadScene("Level3_tutorial");
        nextLevelButton.SetActive(false);
        scoreCalc.score = 0;
        Collision1.count = 0;
    }

}
