using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;

public class ScoreUi : MonoBehaviour
{
    public RowUi rowUi;
    public ScoreManager scoreManager;

    private string BASE_URL="https://game-of-trojans.wl.r.appspot.com/";
    
    public Text titleText;

    void Start() {
        Debug.Log("Start");
        ScoreManager.gotData = false;
        StartCoroutine(scoreManager.GetRequest(BASE_URL));
    }

    void Update() {
        if(ScoreManager.gotData) {
            Debug.Log("In Update");
            GetData();
            ScoreManager.gotData = false;
        }
    }
    
    async Task GetData()
    {
        Debug.Log("GetData");

        var scores = scoreManager.GetHighScores().ToArray();

        Debug.Log("Scores");
        Debug.Log(scores);

        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUi, transform).GetComponent<RowUi>();
            row.rank.text = (i + 1).ToString();
            row.name.text = scores[i].name;
            row.score.text = scores[i].score.ToString();
        }

        //titleText.text = "LEADERBOARD 1";
    }
}

