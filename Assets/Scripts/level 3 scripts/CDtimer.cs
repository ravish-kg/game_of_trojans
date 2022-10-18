using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CDtimer : MonoBehaviour
{
    // Start is called before the first frame update
    public float currentTime1 = 0f;
    public float startTime1;
    public GameObject hollowNumber;
    [SerializeField] TMP_Text number;
    private SpriteRenderer c;
    public int checkRotation = 0;
    // [SerializeField] Text countdownText1;
    void Start() {
        currentTime1 = startTime1;
        number = hollowNumber.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update() {
        if(number != null) {
            currentTime1 -= 1 * Time.deltaTime;
            // countdownText1.text = currentTime1.ToString("0");
            number.text = currentTime1.ToString("0");
            if(currentTime1 <= 0) {
                currentTime1 = 0;  
                // countdownText1.text = ""; 
                // Destroy(countdownText1.gameObject);
                Destroy(hollowNumber.gameObject);
                Destroy(gameObject);
            }
        }
        if(Collision.count == 3) {
            // Destroy(countdownText1.gameObject);
            Destroy(hollowNumber.gameObject);
            Destroy(gameObject);
        }
        if(rotation.isRotationCompleted==1 && checkRotation==0) {
            hollowNumber.transform.eulerAngles = new Vector3(hollowNumber.transform.eulerAngles.x, hollowNumber.transform.eulerAngles.y, hollowNumber.transform.eulerAngles.z+180);
            checkRotation=1;
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Player") {
            currentTime1 = 0;
            Destroy(hollowNumber.gameObject);
            // countdownText1.text = ""; 
            // Destroy(countdownText1.gameObject);  
        }
    }
}