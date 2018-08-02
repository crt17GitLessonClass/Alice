using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneUI : MonoBehaviour {
	float textTransparency = 1.0f;
	void Update(){
		Text text = GetComponent<Text>();
		text.color = new Color(0f, 0f, 0f, Mathf.Sin((textTransparency += Time.deltaTime) * 3f));
		if(Input.touchCount > 0 || Input.GetMouseButton(0)){
			GameStart();
		}
	}

	void GameStart(){
		SceneManager.LoadScene("Q3_game");
	}
}
