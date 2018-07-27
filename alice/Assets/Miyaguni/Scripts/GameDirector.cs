using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour {
	[SerializeField]
	GameObject TimeText;
	[SerializeField]
	float GameTime;
	[SerializeField]
	GameObject[] Colors;
	int colorCount;

	void Start () {
		//GameTime = 60.0f;
		colorCount = 0;
	}
	
	void FixedUpdate () {
		GameTime = Mathf.Clamp(GameTime, 0.0f, 60.0f);
		TimeText.GetComponent<Text>().text = GameTime.ToString("F0") + "秒";
		GameTime -= Time.deltaTime;
		GameObject catgene = GameObject.FindWithTag("Generator");
		GameObject cat = GameObject.FindWithTag("cat");

		if(GameTime < 1){
			Destroy(catgene);
			Destroy(cat);
			TimeText.GetComponent<Text>().text = "Game Over";
		}

		if(Colors[2].activeSelf){
			Destroy(catgene);
			Destroy(cat);
			TimeText.GetComponent<Text>().text = "Game Clear!";
		}
	}

	public void GetCat(){
		Colors[colorCount].SetActive(true);
		colorCount++;
	}
}
