using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public GameObject obstacle;
    public float x_max;
    public float x_min;
    public float y_max;
    public float y_min;
    public float gap;
    public float time;

    void Update()
    {
        if(Time.time > time)
        {
            SpawnObs();
            time = Time.time + gap;
        }
    }

    void SpawnObs()
    {
        float x = Random.Range(x_min, x_max);
        float y = Random.Range(y_min, y_max);

        Instantiate(obstacle, transform.position + new Vector3(x, y, 0), transform.rotation);
    }
}
