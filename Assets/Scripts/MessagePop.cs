using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagePop : MonoBehaviour
{
    public GameObject RedBlock;
    public float waitTime = 10f;

    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void OnTriggerEnter2D(Collider2D other) {
        StartCoroutine(showMessage());
        Debug.Log("whatever");
        RedBlock.SetActive(false);
    }

    public  IEnumerator showMessage() {
        RedBlock.SetActive(true);
        yield return new WaitForSeconds(3);
    }
}