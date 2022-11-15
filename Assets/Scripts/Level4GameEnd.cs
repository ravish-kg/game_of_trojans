using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4GameEnd : MonoBehaviour
{

    public GameObject block1;
    public GameObject block2;
    public GameObject block3;
    public GameObject block4;
    public GameObject block5;
    public GameObject block6;
    public GameObject block7;
    public GameObject block8;
    public GameObject block9;
    public GameObject block10;
    public GameObject block11;
    public GameObject popupCanvas;
    public GameObject TimerCanvas;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (block1 == null && block2 == null && block3 == null && block4 == null && block5 == null && block6 == null && block7 == null && block8 == null && block9 == null && block10 == null && block11 == null && !popupCanvas.active && TimerCanvas == null)
        {
            Timer.currentTime = 0;
        }

    }
}
