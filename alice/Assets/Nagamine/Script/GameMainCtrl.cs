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

    public GameObject hintwindow;
    public GameObject[] hinttext = new GameObject[6];

    
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
        hintwindow.SetActive(false);
        for(int i = 0; i < hinttext.Length; i++)              
            hinttext[i].SetActive(false);           
        if(f_gamestart)
            gameStartSet.SetActive(false);
        CutEndDisplay();
    }   	
	
	void Update ()
    {
        TimeDisplay();
        //CutEndDisplay();           
    }  

    public void GameStart()
    {
        // ゲームをスタートし、タイマーのカウントを開始。
        gameStartSet.SetActive(false);
        f_gamestart = true;
        TimeCtrl.f_count = true;
    }
    
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

    void CutEndDisplay()
    {
        cutend.GetComponent<Text>().text = ceNum.ToString();
    }

    public void ARcamera()
    {
        SceneManager.LoadScene("ARcamera");
    }

    public void HintWindow(int num)
    {                  
        for (int i = 0; i < hinttext.Length; i++)
            hinttext[i].SetActive(false);

        switch (num)
        {
            case 0:
                //hintwindow.SetActive(true);
                hinttext[0].SetActive(true);
                
                break;

            case 1:
                //hintwindow.SetActive(true);
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

        GameObject aaa = hinttext[num];
        StartCoroutine("Aaa", aaa);
    }

    IEnumerator Aaa(GameObject hint)
    {
        print(hint);
        yield return new WaitForSeconds(5.0f);
        //hintwindow.SetActive(false);
        hint.SetActive(false);        
    }
}   