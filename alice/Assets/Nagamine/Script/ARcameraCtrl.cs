using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARcameraCtrl : MonoBehaviour
{          
	
	void Start ()
    {
		
	}  	
	
	void Update ()
    {
		
	}

    public void GameMainBackButton()
    {
        SceneManager.LoadScene("GameMain");

    }
}
