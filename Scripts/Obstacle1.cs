using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Player")
        {
            ScoreManager.score += 5;
            Destroy(this.gameObject);
        }

    }
}
