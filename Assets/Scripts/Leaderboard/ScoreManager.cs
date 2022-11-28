using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.IO;

using UnityEngine.Networking;

public class ScoreManager : MonoBehaviour
{
    private string BASE_URL="https://game-of-trojans.wl.r.appspot.com/";

    private ScoreData sd = new ScoreData();

    public static bool gotData = false;

    void Start() {
        // Debug.Log("Start Score MAnageer");
        // GetScores();
    }

    public IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    sd.scores = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Score>>(webRequest.downloadHandler.text);
                    gotData = true;
                    break;
            }
        }
    }

    public string GetAllScores(){
        string selectedLevel = leaderboard_Instruction.levelName;
        string name = PlayerName.playerName;
        string uuidName = PlayerName.uname;

        string res="";
        

        LEVEL level = (LEVEL)Enum.Parse(typeof(LEVEL), selectedLevel);
        
        List<Score> result = sd.scores.FindAll(e => e.level == level);

        List<Score> rankAll = result.OrderByDescending(x => -x.score).ToList();

        for(int i=0; i<rankAll.Count(); i++){
            if(rankAll[i].uuid == uuidName){
                res = "" + name + " ------ Your Rank : " + (i+1) + " ------ Time Taken : " + rankAll[i].score;
            }
            
        }

        return res;
    }

    public IEnumerable<Score> GetHighScores()
    {
        string selectedLevel = leaderboard_Instruction.levelName;
        string name = PlayerName.playerName;

        LEVEL level = (LEVEL)Enum.Parse(typeof(LEVEL), selectedLevel);
        
        List<Score> result = sd.scores.FindAll(e => e.level == level);


        List<Score> top10 = result.OrderByDescending(x => -x.score).Take(10).ToList();

        // bool isPresent = top10.Exists(e => e.name.Equals(name));

        // if(!isPresent) {
        //     Score sc = sd.scores.Find(e => e.level == level && e.name == name);
            
        //     if(sc != null)
        //         top10.Add(sc);
        // }

        return top10;
    }

    public async void AddScore(Score score)
    {
        Debug.Log("AddScore");
        // Debug.Log(sd.scores);

        // using (var client = new HttpClient())
        // {
        //     sd.scores.Add(score);
        //     var json = JsonUtility.ToJson(sd);
        //     Debug.Log(json);
        //     var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
        //     var result = await client.PostAsync(BASE_URL, content);
        // }
        List<Score> temp = new List<Score>();
        temp.Add(score);
        var json = JsonUtility.ToJson(temp);
        Debug.Log(json);
        StartCoroutine(postRequest(BASE_URL, json));
    }

    public void addScoreToDB(Score score) {
        List<Score> temp = new List<Score>();
        temp.Add(score);
        var json = JsonUtility.ToJson(temp);
        StartCoroutine(postRequest(BASE_URL, json));
    }

    public IEnumerator postRequest(string url, string json)
    {
        Debug.Log("Post Request");
        var uwr = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        Debug.Log(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
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























