using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum LEVEL {
    LEVEL_0,
    LEVEL_1,
    LEVEL_2,
    LEVEL_3,
    LEVEL_4,
    LEVEL_1_SET2,
    LEVEL_2_SET2,
    LEVEL_3_SET2,
    LEVEL_4_SET2,
}

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

    public LEVEL level;

    private bool isScoreUpdated = false;

    public ScoreManager scoreManager;

    void Awake(){
        // Debug.Log("Awake");
        gameOverPanel.SetActive(false);
        
    }

    void Start() {
        GameOver.carryOverFlag = true;
        isScoreUpdated = false;
    }

    // Update is called once per frame
    void Update() {
        if (Collision1.count == 3 || Timer1.currentTime == 0) {
            gameOverPanel.SetActive(true);
            if(scoreCalc.score >= int.Parse(Collision1.threshold)) {
                gameOver.text = "Success! Level complete!";
                equation_panel.text = "Equation: " + Collision1.math_eq;
                nextLevelButton.SetActive(true);

                if(GameOver.carryOverFlag){
                    GameOver.timeCarryOver = Timer1.sTime - Timer1.cTime;
                    if(GameOver.timeCarryOver <= 0){
                        GameOver.timeCarryOver = 0f;
                    }
                    else if(GameOver.timeCarryOver < 10){
                        GameOver.timeCarryOver = 5;
                    }
                    else if(GameOver.timeCarryOver < 20){
                        GameOver.timeCarryOver = 3;
                    }
                    else{
                        GameOver.timeCarryOver = 2;
                    }
                    Debug.Log("Time Carry Over : " + GameOver.timeCarryOver);
                    GameOver.carryOverFlag = false;
                }

                // Leaderboard score logic - STARTS
                if(!isScoreUpdated) {
                    // Need to change to take name as input... Should change savescore logic
                    float score = (float)System.Math.Round(Timer1.startingTime - Timer1.cTime, 2);
                    string name = PlayerPrefs.GetString("playerName");
                    scoreManager.AddScore(new Score(name, score, level));                    
                    scoreManager.SaveScore();
                    isScoreUpdated = true;
                }
                // Leaderboard score logic - ENDS

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
                    // Gameo = "GameEnd~Timer$"+Time.time+"~equation$"+Equation.display+"~threshold$"+Collision1.threshold+"~Order$"+Collision1.count+"\n";
                    Gameo = "GameEnd~Timer$"+Time.time+"~equation$"+Equation.display+"~threshold$"+Collision1.threshold+"~Order$"+Collision1.count+"~Level$"+SceneManager.GetActiveScene().name+"~Sessionid$"+Player.sessionid+"~Username$"+InstructionScript.uname+"\n";
                    
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
        GameOver.timeCarryOver = 0f;
        GameOver.carryOverFlag = false;
        isScoreUpdated = false;
    }

    public void home() {
        gameOverPanel.SetActive(false);
        nextLevelButton.SetActive(false);
        GameOpener.panel_counter = 0;
        NewTimer.exit_condition = 0;
        SceneManager.LoadScene("Menu");
        Collision1.count = 0;
        scoreCalc.score = 0;
        GameOver.timeCarryOver = 0f;
        GameOver.carryOverFlag = false;
        isScoreUpdated = false;
    }

    public void loadLevel1(){
        GameOpener.panel_counter = 0;
        NewTimer.exit_condition = 0;
        SceneManager.LoadScene("Level1");
        nextLevelButton.SetActive(false);
        scoreCalc.score = 0;
        Collision1.count = 0;
        isScoreUpdated = false;
    }
    public void loadLevel2(){
        GameOpener.panel_counter = 0;
        NewTimer.exit_condition = 0;
        SceneManager.LoadScene("Level2_tutorial");
        nextLevelButton.SetActive(false);
        scoreCalc.score = 0;
        Collision1.count = 0;
        isScoreUpdated = false;
    }

    public void loadLevel3(){
        GameOpener.panel_counter = 0;
        NewTimer.exit_condition = 0;
        SceneManager.LoadScene("Level3_tutorial");
        nextLevelButton.SetActive(false);
        scoreCalc.score = 0;
        Collision1.count = 0;
        isScoreUpdated = false;
    }

    public void openLeaderboard() {
        GameOpener.panel_counter = 0;
        NewTimer.exit_condition = 0;
        SceneManager.LoadScene("Leaderboard");
        nextLevelButton.SetActive(false);
        scoreCalc.score = 0;
        Collision1.count = 0;
        isScoreUpdated = false;
    }

}