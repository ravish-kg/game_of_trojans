using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;

public class ScoreManager : MonoBehaviour
{
    private string BASE_URL="https://game-of-trojans.wl.r.appspot.com";

    private ScoreData sd = new ScoreData();

    void Awake()
    {
    }

    public async Task GetScores() {
        using (var httpClient = new HttpClient())
        {
            var json = await httpClient.GetStringAsync(BASE_URL + "/");
            sd.scores = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Score>>(json);   
        }
    }

    public IEnumerable<Score> GetHighScores()
    {
        string selectedLevel = leaderboard_Instruction.levelName;
        string name = PlayerName.playerName;

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

    public async void AddScore(Score score)
    {
        using (var client = new HttpClient())
        {
            sd.scores.Add(score);
            var json = JsonUtility.ToJson(sd);
            Debug.Log(json);
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            var result = await client.PostAsync(BASE_URL + "/", content);
        }
    }

    private void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        // var json = JsonUtility.ToJson(sd);
        // Debug.Log(json);
    }
}























