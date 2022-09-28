using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        if (ScoreManager.score < 250)
            speed = 5;
        else
            speed = 10;
    }
}
