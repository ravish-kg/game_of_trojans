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
        Debug.Log("Inside Awake");
        var json = PlayerPrefs.GetString("scores", "{}");
        sd = JsonUtility.FromJson<ScoreData>(json);
    }

    public IEnumerable<Score> GetHighScores()
    {
        string selectedLevel = PlayerPrefs.GetString("selectedLevel");

        LEVEL level = (LEVEL)Enum.Parse(typeof(LEVEL), selectedLevel);

        List<Score> filtered = sd.scores.FindAll(e => e.level == level);

        return filtered.OrderByDescending(x => x.score);
    }

    public void AddScore(Score score)
    {
        sd.scores.Add(score);
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
    }
}























