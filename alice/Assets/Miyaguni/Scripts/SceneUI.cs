using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUI : MonoBehaviour {

	public void GameStart(){
		SceneManager.LoadScene("Q3_game");
	}

	public void main(){
		SceneManager.LoadScene("GameMain");
	}
}
