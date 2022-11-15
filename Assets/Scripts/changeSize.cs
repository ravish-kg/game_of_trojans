using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSize : MonoBehaviour
{
    public float time2 = 3.0f;
    public float gap = 3.0f;
    public float maxLength = 0f;
    float temp;
    bool increased = false;
    bool checkInitialTime = false;
    public bool X = false;
    public bool Y = false;
    
    // Start is called before the first frame update
    void Start() {
        if(Y) {
            temp = transform.localScale.y;
        }
        else {
            temp = transform.localScale.x;
        }
    }

    IEnumerator changesize() {
        if(!increased) {
            if(Y) {
                while(transform.localScale.y < maxLength) {
                    Vector3 v = transform.localScale;
                    v.y += Time.deltaTime;
                    transform.localScale = v;
                    yield return null;
                }
                increased = true;
            }
            else {
                while(transform.localScale.x < maxLength) {
                    Vector3 v = transform.localScale;
                    v.x += Time.deltaTime;
                    transform.localScale = v;
                    yield return null;
                }
                increased = true;
            }
        }
        else {
            if(Y) {
                while(transform.localScale.y > temp) {
                    Vector3 v = transform.localScale;
                    v.y -= Time.deltaTime;
                    transform.localScale = v;
                    yield return null;
                }
                increased = false;
            }
            else {
                while(transform.localScale.x > temp) {
                    Vector3 v = transform.localScale;
                    v.x -= Time.deltaTime;
                    transform.localScale = v;
                    yield return null;
                }
                increased = false;
            }
        }
    }

    // Update is called once per frame
    void Update() {
        if(NewTimer.exit_condition==1) {
            if(!checkInitialTime) {
                time2 = Time.time + gap;
                checkInitialTime = true;
            }

            if(Time.time > time2) {
                StartCoroutine("changesize");
                time2 = Time.time + gap;
            }
        }
    }
}