using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMainCtrl : MonoBehaviour
{    
    // タイマー表示
    public Text timer;
    Text timertext; 
    // ce = CutEnd = 切れはし
    public Text cutend;
    public static int ceNum = 0;
    public static int ceGet = 0;
    // ゲームスタートフラグ 
    public static bool f_gamestart = false;
    public GameObject gameStartSet;
    // ヒントウィンドウ    
    public GameObject[] hinttext = new GameObject[6];
    public GameObject hintclose;  

    //bool card1;
    //bool card4;                                
    //bool card5;
    //bool card10;
    //bool Q2;
    //bool Q3;
    //bool Q4;
    //bool Q5;
    //bool Q6;

    void Start ()
    {                       
        timertext = timer.GetComponent<Text>();
        hintclose.SetActive(false);
        for(int i = 0; i < hinttext.Length; i++)              
            hinttext[i].SetActive(false);           
        if(f_gamestart)
            gameStartSet.SetActive(false);
        CutEndDisplay();
    }   	
	
	void Update ()
    {
        TimeDisplay();                 
    }  

    public void GameStart()
    {
        // ゲームをスタートし、タイマーのカウントを開始。
        gameStartSet.SetActive(false);
        f_gamestart = true;
        TimeCtrl.f_count = true;
    }
    
    // タイマーの表示
    void TimeDisplay()
    {                 
        int minute = (int)TimeCtrl.countTime / 60;
        int second = (int)TimeCtrl.countTime % 60;

        // memo- countTimeの条件文だけできれいに分けられそう。
        if (second < 10)
            timertext.text = minute.ToString("F0") + " : 0" + second.ToString("F0");
        else if (minute < 10)
            timertext.text = "0" + minute.ToString("F0") + " : " + second.ToString("F0");
        else if (second < 10 && minute < 10)
            timertext.text = "0" + minute.ToString("F0") + " : 0" + second.ToString("F0");
        else
            timertext.text = minute.ToString("F0") + " : " + second.ToString("F0");   
    }

    // ページの切れ端の表示
    void CutEndDisplay()
    {
        cutend.GetComponent<Text>().text = ceNum.ToString();
    }

    // ARカメラ
    public void ARcamera()
    {
        SceneManager.LoadScene("ARcamera");
    }

    // ヒントウィンドウの表示
    public void HintWindow(int num)
    {
        // for文 findでいい気がする
        hintclose.SetActive(false);
        for (int i = 0; i < hinttext.Length; i++)
            hinttext[i].SetActive(false);

        switch (num)
        {
            case 0:                  
                hinttext[0].SetActive(true);                 
                break;

            case 1:                  
                hinttext[1].SetActive(true);
                break;

            case 2:                
                hinttext[2].SetActive(true);
                break;

            case 3:                   
                hinttext[3].SetActive(true);
                break;

            case 4:
                hinttext[4].SetActive(true);
                break;

            case 5:
                hinttext[5].SetActive(true);
                break;

            default:
                break;
        }
        hintclose.SetActive(true);          
    }

    // ヒントウィンドウの非表示
    public void HintCloseButton()
    {
        GameObject hintObj = GameObject.FindGameObjectWithTag("N_HintWindow");
        hintObj.SetActive(false);
        hintclose.SetActive(false);
    }
}   