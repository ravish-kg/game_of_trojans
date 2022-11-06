using UnityEngine;
using System.Collections;

public class wallObstacle : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("Obstacle hit wall ");
            Timer.currentTime = 0;
        }

    }
}
