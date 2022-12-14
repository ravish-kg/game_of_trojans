using UnityEngine ;
using UnityEngine.UI ;
using UnityEngine.Events ;
using System.Collections ;

public enum TIMER_COLOR {
    RED, 
    ORANGE,
    YELLOW
}

public class ClockTimer : MonoBehaviour
{

    // Color constants
    Color red = new Color(1f,0f,0f,1f);
    Color orange = new Color(1f,165f/255f,0f,1f);
    Color yellow = new Color(1f,235f/255f,4f/255f,1f);

    [Header ("Clock Timer UI references :")]
    [SerializeField] private Image uiFillImage ;
    [SerializeField] private Text uiText;

    public TIMER_COLOR blockType;

    // [SerializeField] private Text uiText ;

    public int Duration { get; private set; }

    public int remainingDuration;

    public int defaultDuration = 10;

    bool timerStarted = false;


    private void Awake() {

      ResetTimer();
    }  

    private void ResetTimer() {
        uiText.text = "00" ;
        uiFillImage.fillAmount = 0f ;
        timerStarted = false;
        Duration = remainingDuration = 0 ;
    }

    public ClockTimer SetDuration(int seconds) {
        Duration = remainingDuration = seconds ;
        return this;
    }

    void Start() {
        switch (blockType)
        {
            case TIMER_COLOR.RED:
                Duration = remainingDuration = defaultDuration;
                uiFillImage.color = red;
                break;
            case TIMER_COLOR.ORANGE:
                Duration = remainingDuration = defaultDuration;
                uiFillImage.color = orange;
                break;
            case TIMER_COLOR.YELLOW:
                Duration = remainingDuration = defaultDuration;
                uiFillImage.color = yellow;
                break;
        }

        uiText.text = "" + remainingDuration;

        StopAllCoroutines();
        // StartCoroutine(UpdateTimer()) ;
    }

    void Update() {
        if(NewTimer.exit_condition == 1 && !timerStarted) {
            startTimer();
            timerStarted = true;
        }
        if(Collision1.count == 3) {
            // Destroy(number.gameObject);
            Debug.Log("inside clock timer script");
            Destroy(gameObject);
        }
        if(Collision.count == 3) {
            // Destroy(number.gameObject);
            Debug.Log("inside clock timer script");
            Destroy(gameObject);
        }
    }

    void startTimer() {
        StartCoroutine(UpdateTimer()) ;
    }

    private IEnumerator UpdateTimer() {
        while(remainingDuration > 0) {
            remainingDuration = int.Parse(uiText.text);
            UpdateUI(remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
        End();
    }

    // when the GameObjects collider arrange for this GameObject to travel to the left of the screen
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
    }

    private void UpdateUI(int seconds) {
        uiFillImage.fillAmount = Mathf.InverseLerp(0, Duration, seconds);
        uiText.text = "" + seconds;
    }

    public void End() {
        uiFillImage.gameObject.SetActive(false);
        ResetTimer();
    }

    private void OnDestory() {
        StopAllCoroutines();
    }
}
