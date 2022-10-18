using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collision3 : MonoBehaviour
{
    // public double gap = 7;
    // public double time = 7;
    int ct;
    public static string number;
    public static int count = 0;
    // public GameObject hollowNumber;
    private SpriteRenderer c;
    public static string math_eq;
    Color red = new Color(1f,0f,0f,1f);
    Color orange = new Color(1f,165f/255f,0f,1f);
    Color yellow = new Color(1f,235f/255f,4f/255f,1f);
    string[] equation = { "_ + ( _ * _ )", "( _ * _ ) + _ ", "( _ / _ ) + _", "_ + _ - _", "_ * ( _ / _ )" };
    string[] thresholdArr = { "100", "200", "20", "30", "30" };
    public static string pick;
    public static string threshold;
    public int index;
    public GameObject AnimationText;
    private string Gameo;
    private string objectd;
    private string BASE_URL="https://docs.google.com/forms/d/e/1FAIpQLSe9yNVWR0ab2MrXVYWYKbxWDa_rYX-YvVdmvteH6DTe190ifw/formResponse";

    // Start is called before the first frame update
    void Start() {
        // time = Time.time + gap;
        int temp = Random.Range(0, 5);
        pick = equation[temp];
        threshold = thresholdArr[temp];
        Equation.display = "Equation: " + pick;
    }

    // Update is called once per frame
    void Update() {
        // if(NewTimer.exit_condition == 1) 
        // {
        //     if(Time.time > time) {
        //         c = gameObject.GetComponent<SpriteRenderer>();
        //         if(c.color == red) {
        //             c.color = orange;
        //         } 
        //         else if(c.color == orange) {
        //             c.color = yellow;
        //         }
        //     time = Time.time + gap;
        //     }
        // }
        
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Player") {
            ct = (int) GetComponent<CDtimer>().currentTime1;
            count++;
            c = gameObject.GetComponent<SpriteRenderer>();
            Destroy(gameObject);
            if(c.color==yellow) {
                // number = Random.Range(1, 11).ToString();
                number = ct.ToString();
                AnimationText.GetComponent<TextMeshPro>().text = "1x";
                // hollowNumber.GetComponent<TextMesh>().text = number;
            }
            else if(c.color==orange) {
                // number = Random.Range(11, 21).ToString();
                number = (ct * 2).ToString();
                AnimationText.GetComponent<TextMeshPro>().text = "2x";
                // hollowNumber.GetComponent<TextMesh>().text = number;
            }
            else if(c.color==red) {
                // number = Random.Range(21, 31).ToString();
                number = (ct * 3).ToString();
                AnimationText.GetComponent<TextMeshPro>().text = "3x";
                // hollowNumber.GetComponent<TextMesh>().text = number;
            }
            GameObject clone = (GameObject)Instantiate(AnimationText, transform.position, Quaternion.identity);
            Destroy (clone, 1.0f);
            // Instantiate(hollowNumber, transform.position, Quaternion.identity);
            string num = Collision3.number;
            index = Equation.display.IndexOf("_");
            Equation.display = Equation.display.Substring(0, index) + num + Equation.display.Substring(index + 1);
            
            IEnumerator Post(string gameo, string objectd) {
                WWWForm form = new WWWForm();
                form.AddField("entry.230878790",gameo);
                form.AddField("entry.558777034",objectd);

                byte[] rawd= form.data;
                WWW www = new WWW(BASE_URL, rawd);
                yield return www;
            }

            // objectd = "~Time-"+Time.time+"~Color-"+c.color+"~Value-"+hollowNumber.GetComponent<TextMesh>().text+"~Order-"+count+"\n";
            objectd = "~Time-"+Time.time+"~Color-"+c.color+"~Value-"+num+"~Order-"+count+"\n";

            StartCoroutine(Post("",objectd));

            if (count == 3) {
                int i1 = Equation.display.IndexOf(":");
                math_eq = Equation.display.Substring(i1 + 2);
                int value_of_eq = bodmas.evaluate(math_eq);
                scoreCalc.score = value_of_eq;
                Gameo = "GameEnd~Timer-"+Time.time+"~equation-"+Equation.display+"~threshold-"+threshold+"~Order-"+count+"\n";
                StartCoroutine(Post(Gameo,""));
            }
        }
    }
}