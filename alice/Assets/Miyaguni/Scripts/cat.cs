using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat : MonoBehaviour {
	float catAlife = 0.5f;
	float catTransparency = 0f;
	float catTransparencySpeed = 2f;

	SpriteRenderer sr;

	void Start(){
		sr = GetComponent<SpriteRenderer>();
		sr.color = new Color(1.0f, 1.0f, 1.0f, 0);
	}
	
	
	void FixedUpdate () {
		catAlife -= Time.deltaTime;

		catTransparency += Time.deltaTime * catTransparencySpeed;
		//Debug.Log(catTransparency);

		CapsuleCollider2D cc2d = GetComponent<CapsuleCollider2D>();
		if(catTransparency < 0.4f||catTransparency > 0.7f){
			cc2d.enabled = false;
		}else{
			cc2d.enabled = true;
		}


		sr.color = new Color(1.0f,1.0f,1.0f,Mathf.Sin(180 * catTransparency * Mathf.Deg2Rad));

		if(catAlife < 0){
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
