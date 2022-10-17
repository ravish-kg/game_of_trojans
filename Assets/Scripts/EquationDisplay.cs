using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquationDisplay : MonoBehaviour
{
    public UnityEngine.UI.Text equationdisplayText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        equationdisplayText.text = Equation.display + "    Threshold: " + Collision.threshold;
    }
}
