using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block1Movement : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;
    public GameObject wall4;
    public GameObject wall5;
    public GameObject wall6;
    public GameObject wall7;
    public GameObject wall8;
    public GameObject wall9;
    public GameObject wall10;
    public GameObject wall11;
    public GameObject wall12;
    public GameObject wall13;
    public GameObject wall14;
    public GameObject wall15;
    public GameObject wall16;
    public GameObject wall17;
    public GameObject wall18;
    public GameObject wall19;
    public GameObject wall20;
    public GameObject wall21;
    public GameObject wall22;
    public GameObject wall23;
    public GameObject wall24;
    public GameObject wall25;
    public GameObject wall26;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer.currentTime <= 15)
        {
            wall1.transform.localPosition = new Vector3(75.1f, 0.015f, -1);
            wall2.transform.localPosition = new Vector3(8f, -0.004f, -1);
            wall3.transform.localPosition = new Vector3(8.1f, -0.092f, -1);
            wall4.transform.localPosition = new Vector3(19.1f, -0.179f, -1);
            wall5.transform.localPosition = new Vector3(29.8f, -0.152f, -1);
            wall6.transform.localPosition = new Vector3(37.6f, 0.016f, -1);
            wall7.transform.localPosition = new Vector3(44.7f, -0.082f, -1);
            wall8.transform.localPosition = new Vector3(37.5f, -0.325f, -1);
            wall9.transform.localPosition = new Vector3(50.7f, -0.234f, -1);
            wall10.transform.localPosition = new Vector3(22.8f, -0.394f, -1);
            wall11.transform.localPosition = new Vector3(15.3f, -0.318f, -1);
            wall12.transform.localPosition = new Vector3(66.9f, -0.346f, -1);
            wall13.transform.localPosition = new Vector3(63.3f, -0.208f, -1);
            wall14.transform.localPosition = new Vector3(59.8f, -0.034f, -1);
            wall15.transform.localPosition = new Vector3(57.7f, 0.149f, -1);
            wall16.transform.localPosition = new Vector3(47.1f, 0.23f, -1);
            wall17.transform.localPosition = new Vector3(50.5f, 0.309f, -1);
            wall18.transform.localPosition = new Vector3(62.2f, 0.402f, -1);
            wall19.transform.localPosition = new Vector3(67.6f, 0.318f, -1);
            wall20.transform.localPosition = new Vector3(8.7f, 0.337f, -1);
            wall21.transform.localPosition = new Vector3(15f, 0.196f, -1);
            wall22.transform.localPosition = new Vector3(21.4f, 0.126f, -1);
            wall23.transform.localPosition = new Vector3(24.2f, 0.402f, -1);
            wall24.transform.localPosition = new Vector3(26.8f, 0.329f, -1);
            wall25.transform.localPosition = new Vector3(39.1f, 0.252f, -1);
            wall26.transform.localPosition = new Vector3(27.8f, 0.253f, -1);


        }
    }
}
