using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermaidScript : MonoBehaviour
{
    private GameObject player;
    public GameObject effect;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border") {
            Destroy(gameObject);
        }
        else if (collision.tag == "Bullet") {
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if(collision.tag == "Player") {
            ScoreManager.score += 100;
            Destroy(gameObject);
        }
        
    }
}