using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class TimeCtrl : MonoBehaviour
{           
    public static float countTime = 1200;     
    public static bool f_count = false;

    void Start ()
    {             
        DontDestroyOnLoad(this.gameObject);
    }   
	
	void Update ()
    {
        if(f_count && countTime > 0)
            Timer();

        if(f_count && countTime <= 0)
            SceneManager.LoadScene("Q8");
    }

    void Timer()
    {
        countTime -= Time.deltaTime;        
    }     
}
