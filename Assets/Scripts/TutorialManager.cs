using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{

    public GameObject[] popUps;
    public GameObject button;
    public GameObject tryItOut;
    public Text countDownText1;
    public Text countDownText2;
    public Text countDownText3;
    public Text countDownText4;
    public Text countDownText5;
    public GameObject hollow1;
    public GameObject hollow2;
    public GameObject hollow3;
    public GameObject hollow4;
    public GameObject hollow5;
    public GameObject player;

    public static int popUpIndex;
    public float waitTime = 2f;
    public float waitTime2 = 1f;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (popUpIndex == 0) {
            // Debug.Log("popUp index is "+ popUpIndex);
            popUps[popUpIndex].SetActive(true);
            waitTime -= Time.deltaTime;
            button.SetActive(false);
            if (waitTime <= 0) {
                popUpIndex++;
                popUps[popUpIndex].SetActive(true);
                popUps[0].SetActive(false);
                button.SetActive(true);
            }
            // if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) {
            //     popUpIndex = 2;
            // }
        }

        if (popUpIndex == 2) {
            popUps[2].SetActive(true);
            waitTime2 -= Time.deltaTime;
            // Debug.Log("popUp index is " + popUpIndex);
            // Debug.Log("waitTTime is " + waitTime2);
            if (waitTime2 <= 0) {
                popUps[3].SetActive(true);
                popUps[4].SetActive(true);
                popUpIndex = 4;
            }
            // Debug.Log("waitTTime is " + waitTime2);
            popUps[0].SetActive(false);
            popUps[1].SetActive(false);
        }

        if (popUpIndex == 5) {
            popUps[popUpIndex].SetActive(true);
            popUps[0].SetActive(false);
            popUps[1].SetActive(false);
            popUps[2].SetActive(false);
            popUps[3].SetActive(false);
            popUps[4].SetActive(false);
        }

        if (popUpIndex == 6) {
            popUps[popUpIndex].SetActive(true);
            popUps[0].SetActive(false);
            popUps[1].SetActive(false);
            popUps[2].SetActive(false);
            popUps[3].SetActive(false);
            popUps[4].SetActive(false);
            popUps[5].SetActive(false);
        }

        if (popUpIndex == 7) {
            popUps[7].SetActive(true);
            popUps[8].SetActive(true);
            popUps[9].SetActive(true);
            popUps[0].SetActive(false);
            popUps[1].SetActive(false);
            popUps[2].SetActive(false);
            popUps[3].SetActive(false);
            popUps[4].SetActive(false);
            popUps[5].SetActive(false);
            popUps[6].SetActive(false);
            popUpIndex = 9;
        }

        if (popUpIndex == 10) {
            popUps[popUpIndex].SetActive(true);
            tryItOut.SetActive(true);
            popUps[0].SetActive(false);
            popUps[1].SetActive(false);
            popUps[2].SetActive(false);
            popUps[3].SetActive(false);
            popUps[4].SetActive(false);
            popUps[5].SetActive(false);
            popUps[6].SetActive(false);
            popUps[7].SetActive(false);
            popUps[8].SetActive(false);
            popUps[9].SetActive(false);
            button.SetActive(false);
            Destroy(countDownText1);
            Destroy(countDownText2);
            Destroy(countDownText3);
            Destroy(countDownText4);
            Destroy(countDownText5);
            Destroy(hollow1);
            Destroy(hollow2);
            Destroy(hollow3);
            Destroy(hollow4);
            Destroy(hollow5);
            Destroy(player);
        }
    }

    public void incrementIndex() {
        popUpIndex++;
    }

    public void render_scene(string scene_name) {
        SceneManager.LoadScene(scene_name);
    }
}