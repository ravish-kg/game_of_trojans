using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class GameOver : MonoBehaviour
{
    public GameObject number1, number2, number3, rhs;
    bool changepos = false;
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
    private string BASE_URL = "https://docs.google.com/forms/d/e/1FAIpQLSe9yNVWR0ab2MrXVYWYKbxWDa_rYX-YvVdmvteH6DTe190ifw/formResponse";

    private string SCORE_URL = "https://game-of-trojans.wl.r.appspot.com/";

    private int flag = 0;

    public LEVEL level;

    private bool isScoreUpdated = false;

    public ScoreManager scoreManager;

    void Awake()
    {
        gameOverPanel.SetActive(false);
    }

    void Start()
    {
        changepos = false;
        carryOverFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Collision.count == 3 || Timer.currentTime == 0)
        {
            gameOverPanel.SetActive(true);
            if (!changepos && (Collision.temp == 0 || Collision.temp == 4))
            {
                Vector3 pos1 = number1.GetComponent<RectTransform>().position;
                pos1.x -= 10;
                number1.GetComponent<RectTransform>().position = pos1;

                Vector3 pos2 = number2.GetComponent<RectTransform>().position;
                pos2.x += 22;
                number2.GetComponent<RectTransform>().position = pos2;

                Vector3 pos3 = number3.GetComponent<RectTransform>().position;
                pos3.x -= 25;
                number3.GetComponent<RectTransform>().position = pos3;

                changepos = true;
            }

            if (scoreCalc.score >= int.Parse(Collision.threshold))
            {
                string temps = Regex.Replace(Collision.original_equation, @"_", "");
                number1.GetComponent<Text>().text = Collision.numbers_list[0];
                number2.GetComponent<Text>().text = Collision.numbers_list[1];
                number3.GetComponent<Text>().text = Collision.numbers_list[2];
                rhs.GetComponent<Text>().text = scoreCalc.score.ToString();

                gameOver.text = "Success! Level complete!";
                // equation_panel.text = "Equation: " + Collision.math_eq;
                equation_panel.text = temps + " = ";
                nextLevelButton.SetActive(true);

                if (carryOverFlag)
                {
                    timeCarryOver = Timer.sTime - Timer.cTime;
                    if (timeCarryOver <= 0)
                    {
                        timeCarryOver = 0f;
                    }
                    else if (timeCarryOver < 10)
                    {
                        timeCarryOver = 5f;
                    }
                    else if (timeCarryOver < 20)
                    {
                        timeCarryOver = 3f;
                    }
                    else
                    {
                        timeCarryOver = 2f;
                    }
                    Debug.Log("Time Carry Over : " + timeCarryOver);
                    carryOverFlag = false;
                }

                // Leaderboard score logic - STARTS
                if (!isScoreUpdated)
                {
                    // Need to change to take name as input... Should change savescore logic
                    float score = (float)System.Math.Round(Timer.startingTime - Timer.cTime, 2);
                    string name = PlayerName.playerName;
                    string uuid = PlayerName.uname;
                    // scoreManager.AddScore(new Score(name, score, level));                    
                    // scoreManager.SaveScore();
                    ScoreData temp = new ScoreData();
                    temp.scores.Add(new Score(name, uuid, score, level));
                    var json = JsonUtility.ToJson(temp);
                    Debug.Log(json);
                    StartCoroutine(scoreManager.postRequest(SCORE_URL, json));

                    isScoreUpdated = true;
                }
                // Leaderboard score logic - ENDS
            }
            else
            {
                IEnumerator Post(string gameo, string objectd)
                {
                    WWWForm form = new WWWForm();
                    form.AddField("entry.230878790", gameo);
                    form.AddField("entry.558777034", objectd);

                    byte[] rawd = form.data;
                    WWW www = new WWW(BASE_URL, rawd);
                    yield return www;

                }
                if (flag == 0)
                {
                    // Gameo = "GameEnd~Timer$"+Time.time+"~equation$"+Equation.display+"~threshold$"+Collision.threshold+"~Order$"+Collision.count+"\n";
                    Gameo = "GameEnd~Timer$" + Time.time + "~equation$" + Equation.display + "~threshold$" + Collision.threshold + "~Order$" + Collision.count + "~Level$" + SceneManager.GetActiveScene().name + "~Sessionid$" + Player.sessionid + "~Username$" + InstructionScript.uname + "\n";
                    StartCoroutine(Post(Gameo, ""));
                    flag = 1;
                }

                if (Timer.currentTime == 0)
                {
                    gameOver.text = "Time's up! You Lost :(";
                    equation_panel.text = "Equation Incomplete";
                }
                else
                {
                    string temps = Regex.Replace(Collision.original_equation, @"_", "");
                    number1.GetComponent<Text>().text = Collision.numbers_list[0];
                    number2.GetComponent<Text>().text = Collision.numbers_list[1];
                    number3.GetComponent<Text>().text = Collision.numbers_list[2];
                    rhs.GetComponent<Text>().text = scoreCalc.score.ToString();

                    gameOver.text = "Game Over! You Lost :(";
                    // equation_panel.text = "Equation: " + Collision.math_eq;
                    equation_panel.text = temps + " = ";
                }
            }
            threshold_panel.text = "Threshold: " + Collision.threshold;
            score_panel.text = "Score: " + scoreCalc.score;
        }
    }

    public void Restart()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        nextLevelButton.SetActive(false);
        gameOverPanel.SetActive(false);
        GameOpener.panel_counter = 0;
        entry_restart_condition = 1;
        NewTimer.exit_condition = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // SceneManager.LoadScene("Level1");
        scoreCalc.score = 0;
        Collision.count = 0;
        timeCarryOver = 0f;
        GameOver.timeCarryOver = 0f;
        carryOverFlag = false;
        isScoreUpdated = false;
    }

    public void home()
    {
        Debug.Log("Inside Home gameover");
        gameOverPanel.SetActive(false);
        nextLevelButton.SetActive(false);
        GameOpener.panel_counter = 0;
        NewTimer.exit_condition = 0;
        SceneManager.LoadScene("Menu");
        Collision.count = 0;
        scoreCalc.score = 0;
        timeCarryOver = 0f;
        GameOver.timeCarryOver = 0f;
        carryOverFlag = false;
        isScoreUpdated = false;
    }

    public void loadLevel1()
    {
        GameOpener.panel_counter = 0;
        NewTimer.exit_condition = 0;
        SceneManager.LoadScene("Level1");
        nextLevelButton.SetActive(false);
        scoreCalc.score = 0;
        Collision.count = 0;
        isScoreUpdated = false;
    }
    public void loadLevel2()
    {
        GameOpener.panel_counter = 0;
        NewTimer.exit_condition = 0;
        SceneManager.LoadScene("Level2_tutorial");
        nextLevelButton.SetActive(false);
        scoreCalc.score = 0;
        Collision.count = 0;
        isScoreUpdated = false;
    }

    public void loadLevel3()
    {
        GameOpener.panel_counter = 0;
        NewTimer.exit_condition = 0;
        SceneManager.LoadScene("Level3_tutorial");
        nextLevelButton.SetActive(false);
        scoreCalc.score = 0;
        Collision.count = 0;
        isScoreUpdated = false;
    }

    public void loadLevel1set2()
    {
        rotation.isRotationCompleted = 0;
        GameOpener.panel_counter = 0;
        NewTimer.exit_condition = 0;
        SceneManager.LoadScene("Level1_set2");
        nextLevelButton.SetActive(false);
        scoreCalc.score = 0;
        Collision3.count = 0;
        isScoreUpdated = false;
    }

    public void openLeaderboard()
    {
        GameOpener.panel_counter = 0;
        NewTimer.exit_condition = 0;
        SceneManager.LoadScene("Leaderboard");
        nextLevelButton.SetActive(false);
        scoreCalc.score = 0;
        Collision.count = 0;
        isScoreUpdated = false;
    }

}