using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneUI : MonoBehaviour {
	void Update(){
		Text text = GetComponent<Text>();
		text.color = new Color(72f / 255f, 158f / 255f, 206f / 255f);
		if(Input.touchCount > 0 || Input.GetMouseButton(0)){
			GameStart();
		}
	}

	void GameStart(){
		SceneManager.LoadScene("Q3_game");
	}
}
