using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

    public bool clear = false;
    public bool gameover = false;
    public bool flag1 = true;
    public bool flag4 = false;
    public bool flag5 = false;
    public bool flag10 = false;

    public GameObject Playerobj;
    public GameObject Retrybutton;

    private int cutend = 3;

    [SerializeField]
    private GameObject startbutton;
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private Text countdownText;

    private bool startflag = false;

    float time = 30.0f;
    Text timeText;
    float countdowntime = 3.5f;

    public bool movestart = false;

    AudioSource audiosource;
    [SerializeField]
    AudioClip countSE;

    [SerializeField]
    AudioClip currectSE;

    [SerializeField]
    AudioClip incurrectSE;



    void Start() {
        timeText = GameObject.Find("timeText").GetComponent<Text>();
        Instantiate(Playerobj, Vector3.zero, Quaternion.identity);
        audiosource = GetComponent<AudioSource>();



    }

    void Update() {
        if (!startflag) { return; }

        if (countdowntime > 0) {
            countdowntime -= Time.deltaTime;
            countdownText.GetComponent<Text>().text = countdowntime.ToString("F0");
            if (countdowntime <= 0) {
                Destroy(countdownText);
                movestart = true;
            }
            return;

        } else {

            if (clear) { return; }

            if (time <= 0) {
                GameOver();
                return;
            }


            time -= Time.deltaTime;
            timeText.text = "残り" + time.ToString("F0") + "秒";


        }


    }

    public void Reset(GameObject destroy) {

        //GameObject Player = GameObject.FindWithTag("Player");
        Destroy(destroy);
        Instantiate(Playerobj, Vector3.zero, Quaternion.identity);

        flag1 = true;
        flag4 = false;
        flag5 = false;
        flag10 = false;
    }

    public void Clear() {
        //SceneManager.LoadScene("Clear");
        timeText.text = "Clear";
        clear = true;
        GameMainCtrl.ceGet += cutend;
        GameMainCtrl.f_Q4 = true;
        //GameObject.Find("RetryButton").SetActive(true);
        SceneManager.LoadScene("CutEnd");


    }

    void GameOver() {
        //SceneManager.LoadScene("GameOver");
        timeText.text = "GameOver";
        gameover = true;
        Retrybutton.SetActive(true);

    }

    public void StartButton() {
        startbutton.SetActive(false);
        panel.SetActive(false);
        startflag = true;
        audiosource.PlayOneShot(countSE);
        
        


       // Countdown();
       

    }

    void Countdown() {
        startflag = true;
     
    }

    public void CurrectSE() {
        audiosource.PlayOneShot(currectSE);
    }

    public void inCurrectSE() {
        audiosource.PlayOneShot(incurrectSE);
    }
}