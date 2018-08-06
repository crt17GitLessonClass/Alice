using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {
	[SerializeField]
	GameObject TimeText;
	[SerializeField]
	GameObject SecondText;
	[SerializeField]
	float GameTime;
	public int catCount;
	[SerializeField]
	GameObject catCountText;
	[SerializeField]
	GameObject RestartButton;
	

	void Start () {
		//GameTime = 60.0f;
		catCount = 3;
		RestartButton.SetActive(false);
	}
	
	void FixedUpdate () {
		GameTime = Mathf.Clamp(GameTime, 0.0f, 60.0f);
		TimeText.GetComponent<Text>().text = GameTime.ToString("F0");
		GameTime -= Time.deltaTime;
		GameObject catgene = GameObject.FindWithTag("Generator");
		GameObject cat = GameObject.FindWithTag("cat");

		catCountText.GetComponent<Text>().text = "残り " + catCount.ToString() + "回";

		if(GameTime < 0.5f){
			Destroy(catgene);
			Destroy(cat);
			Destroy(SecondText);
			TimeText.GetComponent<Text>().text = "失敗";
			RestartButton.SetActive(true);
		}

		if(catCount == 0){
			Destroy(catgene);
			Destroy(cat);
			Destroy(SecondText);
			TimeText.GetComponent<Text>().text = "捕まえた!";
			Invoke("Clear", 0.5f);
		}
	}

	public void GetCat(){
		catCount--;
	}

	public void Restart(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	void Clear(){
		//SceneManager.LoadScene("Clear");
		RestartButton.SetActive(true);
	}
}
