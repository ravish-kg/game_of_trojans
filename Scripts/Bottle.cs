﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bottle;
    public float x_max;
    public float x_min;
    public float y_max;
    public float y_min;
    public double gap = 2;
    public double time;

    void Update()
    {
        if (Time.time > time)
        {
            SpawnObs();
            //gap = gap + 2;
            time = Time.time + gap;
        }
    }

    void SpawnObs()
    {

        float x = Random.Range(x_min, x_max);
        float y = Random.Range(y_min, y_max);

        Instantiate(bottle, transform.position + new Vector3(x, y, 0), transform.rotation);
    }
}
