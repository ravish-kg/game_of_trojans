using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialLevel4 : MonoBehaviour
{

    public GameObject[] popUps;
    public GameObject button;
    public GameObject tryItOut;
    public GameObject player;

    public int popUpIndex;
    public float waitTime;
    public float waitTime2;

    // Start is called before the first frame update
    void Start()
    {
        popUpIndex = 0;
        waitTime = 2f;
        waitTime2 = 2f;

    }

    // Update is called once per frame
    void Update()
    {
        if (popUpIndex == 0)
        {
            // Debug.Log("popUp index is "+ popUpIndex);
            popUps[popUpIndex].SetActive(true);
            waitTime -= Time.deltaTime;
            button.SetActive(false);
            if (waitTime <= 0)
            {
                popUpIndex++;
                popUps[popUpIndex].SetActive(true);
                popUps[0].SetActive(false);
                button.SetActive(false);
            }
        }

        if (popUpIndex == 1)
        {
            popUps[popUpIndex].SetActive(true);
            waitTime2 -= Time.deltaTime;
            button.SetActive(false);
            if (waitTime2 <= 0)
            {
                popUpIndex++;
                popUps[popUpIndex].SetActive(true);
                popUps[0].SetActive(false);
                popUps[1].SetActive(false);
                button.SetActive(true);
            }
        }

    }

    public void render_scene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }
}