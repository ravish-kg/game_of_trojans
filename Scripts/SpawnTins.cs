using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTins : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject tin;
    public float x_max;
    public float x_min;
    public float y_max;
    public float y_min;
    public float gap = 2;
    public float time;

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

        Instantiate(tin, transform.position + new Vector3(x, y, 0), transform.rotation);
    }
}
