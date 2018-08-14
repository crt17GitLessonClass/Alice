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
	float GameTime;
	public int catCount;
	[SerializeField]
	GameObject catCountText;
	[SerializeField]
	GameObject RestartButton;
	[SerializeField]
	GameObject ExitButton;

	void Start () {
		GameTime = 60.0f;
		catCount = 3;
		RestartButton.SetActive(false);
		ExitButton.SetActive(false);
	}
	
	void FixedUpdate () {
		GameTime = Mathf.Clamp(GameTime, 0.0f, 60.0f);
		Text time = TimeText.GetComponent<Text>();
		time.text = GameTime.ToString("F0");
		GameTime -= Time.deltaTime;
		GameObject catgene = GameObject.Find("GameGenerator");
		GameObject cat = GameObject.FindWithTag("m_cat");
		catCountText.GetComponent<Text>().text = "残り " + catCount.ToString() + "回";
		GameObject CountDownText = GameObject.Find("CountDownText");
		Text cdText = CountDownText.GetComponent<Text>();

		if(GameTime < 0.5f){
			cdText.color = new Color((72f / 255f) , (158f / 255f), (206f / 255f), 255f);
			cdText.text = "ゲームオーバー";
			Destroy(catgene);
			Destroy(cat);
			Destroy(SecondText);
			time.text = "";
			RestartButton.SetActive(true);
			ExitButton.SetActive(true);
		}

		if(catCount == 0){
			cdText.color = new Color((72f / 255f) , (158f / 255f), (206f / 255f), 255f);
			cdText.text = "ゲームクリア!";
			Destroy(catgene);
			Destroy(cat);
			Destroy(SecondText);
			time.text = "捕まえた!";
			GameMainCtrl.ceGet += 2;
			GameMainCtrl.f_Q6 = true;
			Invoke("Clear", 1.0f);
		}
	}

	public void GetCat(){
		catCount--;
		AudioSource AS = GetComponent<AudioSource>();
		AS.Play();
	}

	public void Restart(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Exit(){
		SceneManager.LoadScene("Q3");
	}

	void Clear(){
		SceneManager.LoadScene("CutEnd");
	}
}