using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat : MonoBehaviour {
	float catLife;
	float catTransparency = 0f;
	float catTransparencySpeed = 1f;

	SpriteRenderer sr;

	void Start(){
		sr = GetComponent<SpriteRenderer>();
		sr.color = new Color(1.0f, 1.0f, 1.0f, 0);
		//猫の速度判定
		GameObject gameDirector = GameObject.Find("GameDirector");
		int catC = gameDirector.GetComponent<GameDirector>().catCount;
		if(catC==3){
			catLife = 1f;
			catTransparencySpeed = 0.8f;
		}else if(catC == 2){
			catLife = 0.8f;
			catTransparencySpeed = 1.2f;
		}else{
			catLife = 0.5f;
			catTransparencySpeed = 2f;
		}
	}
	
	
	void FixedUpdate () {
		//猫の処理
		catLife -= Time.deltaTime;
		catTransparency += Time.deltaTime * catTransparencySpeed;
		CapsuleCollider2D cc2d = GetComponent<CapsuleCollider2D>();
		if(catTransparency < 0.2f||catTransparency > 0.7f){
			cc2d.enabled = false;
		}else{
			cc2d.enabled = true;
		}

		sr.color = new Color(1.0f,1.0f,1.0f,Mathf.Sin(180 * catTransparency * Mathf.Deg2Rad));
		if(catLife < 0){
			GameObject catgene = GameObject.Find("CatGenerator");
			catgene.GetComponent<CatGenerator>().catgene();
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
			//タップ成功の処理
			GameObject catgene = GameObject.Find("CatGenerator");
			catgene.GetComponent<CatGenerator>().catgene();
			GameObject GameDirector = GameObject.Find("GameDirector");
			GameDirector.GetComponent<GameDirector>().GetCat();
			Destroy(gameObject);
		}
	}
}
