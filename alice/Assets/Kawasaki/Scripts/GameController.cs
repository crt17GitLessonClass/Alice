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
  

    float time = 60.0f;
    Text timeText;

    void Start() {
        timeText = GameObject.Find("timeText").GetComponent<Text>();
        Instantiate(Playerobj, Vector3.zero, Quaternion.identity);


    }

    void Update() {

        if (clear) { return; }

        if (time <= 0) {
            GameOver();
            return;
        }


        time -= Time.deltaTime;
        timeText.text = "残り" + time.ToString("F0") + "秒";

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
        GameObject.Find("RetryButton").SetActive(true);


    }

    void GameOver() {
        //SceneManager.LoadScene("GameOver");
        timeText.text = "GameOver";
        gameover = true;
        GameObject.Find("RetryButton").SetActive(true);

    }
}