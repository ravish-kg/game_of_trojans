using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private ScoreData sd = new ScoreData();

    void Awake()
    {
        var json = PlayerPrefs.GetString("scores", "{}");
        sd = JsonUtility.FromJson<ScoreData>(json);
    }

    public IEnumerable<Score> GetHighScores()
    {
        string selectedLevel = PlayerPrefs.GetString("selectedLevel");
        string name = PlayerPrefs.GetString("playerName");

        LEVEL level = (LEVEL)Enum.Parse(typeof(LEVEL), selectedLevel);
        
        List<Score> result = sd.scores.FindAll(e => e.level == level);

        List<Score> top10 = result.OrderByDescending(x => -x.score).Take(10).ToList();

        bool isPresent = top10.Exists(e => e.name.Equals(name));

        if(!isPresent) {
            Score sc = sd.scores.Find(e => e.level == level && e.name == name);
            
            if(sc != null)
                top10.Add(sc);
        }

        return top10;
    }

    public void AddScore(Score score)
    {
        var json = PlayerPrefs.GetString("scores");
        sd = JsonUtility.FromJson<ScoreData>(json);
        sd.scores.Add(score);
        Debug.Log(sd.scores);
    }

    private void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(sd);
        Debug.Log(json);
        PlayerPrefs.SetString("scores", json);
        UnityEngine.PlayerPrefs.Save();
    }
}























