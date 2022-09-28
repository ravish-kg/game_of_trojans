using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private GameObject player;
    public GameObject effect;
    public GameObject effect2;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Border") {
            Destroy(gameObject);
        }
        else if (col.tag.Equals("Bullet")) {
            ScoreManager.score += 50;
            Destroy(col.gameObject);
            Destroy(gameObject);
            Instantiate(effect2, transform.position, Quaternion.identity);
        }
        else if (col.tag == "Player") {
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
        }
    }

}