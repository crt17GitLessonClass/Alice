using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMainCtrl : MonoBehaviour
{
    float countTime = 1200;
    public Text timetext;

    void Start ()
    {
        //timetext = GetComponent<Text>();
		
	}
	
	
	void Update ()
    {
        countTime -= Time.deltaTime; 
        int minute = (int)countTime / 60;
        int second = (int)countTime % 60;
        timetext.GetComponent<Text>().text = minute.ToString("F0") + " : " + second.ToString("F0"); 
    }

    public void ARcamera()
    {
        SceneManager.LoadScene("ARcamera");
    }
}
