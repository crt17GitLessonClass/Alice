using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour {
	[SerializeField]
	GameObject TimeText;
	[SerializeField]
	float GameTime;

	void Start () {
		//GameTime = 60.0f;
	}
	
	void FixedUpdate () {
		GameTime = Mathf.Clamp(GameTime, 0.0f, 60.0f);
		TimeText.GetComponent<Text>().text = GameTime.ToString("F1");
		GameTime -= Time.deltaTime;

		if(GameTime < 0){
			GameObject catgene = GameObject.Find("CatGenerator");
			Destroy(catgene);
		}
	}
}
