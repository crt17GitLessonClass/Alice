using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat : MonoBehaviour {
	float catLife = 0.7f;
	float catTransparency = 0f;
	float catTransparencySpeed = 1f;

	SpriteRenderer sr;

	void Start(){
		sr = GetComponent<SpriteRenderer>();
		sr.color = new Color(1.0f, 1.0f, 1.0f, 0);
		GameObject gameDirector = GameObject.FindWithTag("Director");
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
		catLife -= Time.deltaTime;

		catTransparency += Time.deltaTime * catTransparencySpeed;
		//Debug.Log(catTransparency);

		CapsuleCollider2D cc2d = GetComponent<CapsuleCollider2D>();
		if(catTransparency < 0.4f||catTransparency > 0.7f){
			cc2d.enabled = false;
		}else{
			cc2d.enabled = true;
		}


		sr.color = new Color(1.0f,1.0f,1.0f,Mathf.Sin(180 * catTransparency * Mathf.Deg2Rad));

		if(catLife < 0){
			GameObject catgene = GameObject.FindWithTag("Generator");
			catgene.GetComponent<CatGenerator>().catgene();
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
			GameObject catgene = GameObject.FindWithTag("Generator");
			catgene.GetComponent<CatGenerator>().catgene();
			// ここにタップ成功時の処理
			GameObject GameDirector = GameObject.FindWithTag("Director");
			GameDirector.GetComponent<GameDirector>().GetCat();
			Destroy(gameObject);
		}
	}
}
