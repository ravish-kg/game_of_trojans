using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1GameEnd : MonoBehaviour
{
    public GameObject block1;
    public GameObject block2;
    public GameObject block3;
    public GameObject block4;
    public GameObject block5;
    public GameObject popupCanvas;
    public GameObject TimerCanvas;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (block1 == null && block2 == null && block3 == null && block4 == null && block5 == null && !popupCanvas.active && TimerCanvas == null)
        {
            Timer1.currentTime = 0;
        }

    }
}
