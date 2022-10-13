using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public double gap = 7;
    public double time = 7;
    public static string number;
    public static int count = 0;
    public GameObject hollowNumber;
    private SpriteRenderer c;
    public static string math_eq;
    Color darkgreen = new Color(0f,50f/255f,0f,255f/255f);
    Color green = new Color(0f,150f/255f,0f,255f/255f);
    Color lightgreen = new Color(0f,255f/255f,0f,255f/255f);
    string[] equation = { "_ + ( _ * _ )", "( _ * _ ) + _ ", "( _ / _ ) + _", "_ + _ - _", "_ * ( _ / _ )" };
    string[] thresholdArr = { "200", "200", "20", "30", "30" };
    public static string pick;
    public static string threshold;
    public int index;

    private string Gameo;
    private string objectd;
    private string BASE_URL="https://docs.google.com/forms/d/e/1FAIpQLSe9yNVWR0ab2MrXVYWYKbxWDa_rYX-YvVdmvteH6DTe190ifw/formResponse";


    // Start is called before the first frame update
    void Start() {
        int temp = Random.Range(0, 5);
        pick = equation[temp];
        threshold = thresholdArr[temp];
        Equation.display = "Equation: " + pick;
    }

    // Update is called once per frame
    void Update() {
        if(Time.time > time) {
            c = gameObject.GetComponent<SpriteRenderer>();
            if(c.color == darkgreen) {
                c.color = green;
            } 
            else if(c.color == green) {
                c.color = lightgreen;
            }
            time = Time.time + gap;
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Player") {
            Debug.Log("player hit detected");
            count++;
            c = gameObject.GetComponent<SpriteRenderer>();
            Destroy(gameObject);
            if(c.color==lightgreen) {
                Debug.Log("lightgreen");
                number = Random.Range(1, 11).ToString();
                hollowNumber.GetComponent<TextMesh>().text = number;
            }
            else if(c.color==green) {
                Debug.Log("green");
                number = Random.Range(11, 21).ToString();
                hollowNumber.GetComponent<TextMesh>().text = number;
            }
            else if(c.color==darkgreen) {
                Debug.Log("darkgreen");
                number = Random.Range(21, 31).ToString();
                hollowNumber.GetComponent<TextMesh>().text = number;
            }
            Instantiate(hollowNumber, transform.position, Quaternion.identity);
            string num = Collision.number;
            index = Equation.display.IndexOf("_");
            Equation.display = Equation.display.Substring(0, index) + num + Equation.display.Substring(index + 1);
            

              
            IEnumerator Post(string gameo, string objectd){
                WWWForm form = new WWWForm();
                form.AddField("entry.230878790",gameo);
                form.AddField("entry.558777034",objectd);

                byte[] rawd= form.data;
                WWW www = new WWW(BASE_URL, rawd);
                yield return www;

            }


            objectd = "~Time-"+Time.time+"~Color-"+c.color+"~Value-"+hollowNumber.GetComponent<TextMesh>().text+"~Order-"+count+"\n";


            StartCoroutine(Post("",objectd));

            if (count == 3)
            {
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


