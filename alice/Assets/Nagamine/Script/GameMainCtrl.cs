using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMainCtrl : MonoBehaviour
{             
    public Text timer;
    Text timertext;

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
    }   	
	
	void Update ()
    {
        TimeDisplay();  
        
        // デバッグ用
        if(Input.GetMouseButtonDown(0))  
            TimeCtrl.f_count = true;         
    }  
    
    void TimeDisplay()
    {                 
        int minute = (int)TimeCtrl.countTime / 60;
        int second = (int)TimeCtrl.countTime % 60;

        if (second < 10)
            timertext.text = minute.ToString("F0") + " : 0" + second.ToString("F0");
        else if (minute < 10)
            timertext.text = "0" + minute.ToString("F0") + " : " + second.ToString("F0");
        else if (second < 10 && minute < 10)
            timertext.text = "0" + minute.ToString("F0") + " : 0" + second.ToString("F0");
        else
            timertext.text = minute.ToString("F0") + " : " + second.ToString("F0");   
    }

    public void ARcamera()
    {
        SceneManager.LoadScene("ARcamera");
    }
}
