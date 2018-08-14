using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class TimeCtrl : MonoBehaviour
{             
    public static float countTime = 1200;     
    public static bool f_count = false;
    public GameObject timeupCanvas;

    void Start ()
    {             
        DontDestroyOnLoad(this.gameObject);
        timeupCanvas.SetActive(false);
    }   
	
	void Update ()
    {
        if(f_count && countTime > 0)
        {
            Timer();
        }             

        if(f_count && countTime <= 0)
        {
            timeupCanvas.SetActive(true);
            //PuzzleButton();
            //SceneManager.LoadScene("Q8");
        }  
    }

    void Timer()
    {
        countTime -= Time.deltaTime;        
    } 
    
    public void PuzzleButton()
    {
        SceneManager.LoadScene("Q8");
    }
}
