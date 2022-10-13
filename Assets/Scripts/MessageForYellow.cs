using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageForYellow : MonoBehaviour
{
    public GameObject YellowBlock;

    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            YellowBlock.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            YellowBlock.SetActive(false);
        }
    }
}