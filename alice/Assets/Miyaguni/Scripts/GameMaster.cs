using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {
	[SerializeField]
	GameObject[] objects;
	[SerializeField]
	GameObject CountDownText;
	float countDown;
	float textTransparency = 1.0f;

	void Start () {
		for(int i = 0; i < objects.Length; i++){
			objects[i].SetActive(false);
		}		
		countDown = 3.5f;
	}
	
	void Update () {
		countDown -= Time.deltaTime;
		CountDownText.GetComponent<Text>().text = countDown.ToString("F0");
		if(countDown < 0.5f){
			CountDownText.GetComponent<Text>().text = "スタート!";
			Text text = CountDownText.GetComponent<Text>();
			text.color = new Color((72f / 255f) , (158f / 255f), (206f / 255f), textTransparency -= Time.deltaTime);
			if(textTransparency <= 0){
				for(int i = 0; i < objects.Length; i++){
					objects[i].SetActive(true);
				}
				destroyObject();
			}
		}
	}

	void destroyObject(){
		Destroy(gameObject);
	}
}