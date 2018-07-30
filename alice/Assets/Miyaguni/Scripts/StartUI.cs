using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour {
	[SerializeField]
	GameObject[] UIs;

	void Start(){
		UIs[2].SetActive(false);
	}

	public void GameStart(){
		SceneManager.LoadScene("main");
	}

	public void Exposition(){
		UIs[2].SetActive(true);
		UIs[1].SetActive(false);
	}

	public void closeExposition(){
		UIs[2].SetActive(false);
		UIs[1].SetActive(true);
	}
}
