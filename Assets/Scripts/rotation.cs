using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    // public GameObject myPrefab;
    float time2 = 15.0f;
    float gap = 15.0f;
    public float rot_duration = 2f;
    Quaternion final_rot;
    bool isRotating = false;
    bool checkInitialTime = false;
    public static int isRotationCompleted = 0;
    public GameObject player;
    // public float x, y, z;

    // Use this for initialization
    void Start()
    {
        // time2 = Time.time + gap;
        final_rot = transform.rotation;
    }

    IEnumerator rotateOBJ()
    {
        final_rot = final_rot * Quaternion.Euler(0, 0, 180);
        Quaternion startRot = transform.rotation;
        float rot_elapsedTime = 0.0F;
        while (rot_elapsedTime < rot_duration)
        {
            transform.rotation = Quaternion.Slerp(startRot, final_rot, rot_elapsedTime / rot_duration);
            rot_elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.rotation = Quaternion.Euler(0, 0, 180);
        isRotationCompleted = 1;
        player.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (NewTimer.exit_condition == 1)
        {

            if (!checkInitialTime)
            {
                time2 = Time.time + gap;
                checkInitialTime = true;
            }

            if (Time.time >= time2 && !isRotating && Collision3.count < 3)
            {
                player.SetActive(false);
                isRotating = true;
                StartCoroutine("rotateOBJ");
            }
        }
    }

}