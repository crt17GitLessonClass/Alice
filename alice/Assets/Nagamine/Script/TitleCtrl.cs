using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleCtrl : MonoBehaviour
{    
	
	void Start ()
    {
		
	}       

	void Update ()
    {
        if(Input.GetMouseButton(1))
        {
            SceneManager.LoadScene("Tutorial");
        }
		
	}
}
