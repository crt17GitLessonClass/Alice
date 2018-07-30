using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {
	[SerializeField]
	GameObject TimeText;
	[SerializeField]
	float GameTime;
	[SerializeField]
	GameObject[] Colors;
	[SerializeField]
	GameObject RestartButton;
	
	int colorCount;

	void Start () {
		//GameTime = 60.0f;
		colorCount = 0;
		RestartButton.SetActive(false);
	}
	
	void FixedUpdate () {
		GameTime = Mathf.Clamp(GameTime, 0.0f, 60.0f);
		TimeText.GetComponent<Text>().text = GameTime.ToString("F0") + "秒";
		GameTime -= Time.deltaTime;
		GameObject catgene = GameObject.FindWithTag("Generator");
		GameObject cat = GameObject.FindWithTag("cat");

		if(GameTime < 0.5f){
			Destroy(catgene);
			Destroy(cat);
			TimeText.GetComponent<Text>().text = "Faild";
			RestartButton.SetActive(true);
		}

		if(Colors[2].activeSelf){
			Destroy(catgene);
			Destroy(cat);
			TimeText.GetComponent<Text>().text = "Clear!";
			Invoke("Clear", 1.0f);
		}
	}

	public void GetCat(){
		Colors[colorCount].SetActive(true);
		colorCount++;
	}

	public void Restart(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	void Clear(){
		SceneManager.LoadScene("Clear");
	}
}
