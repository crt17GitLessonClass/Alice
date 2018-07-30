using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat : MonoBehaviour {
	[SerializeField]
	float catAlife = 0.5f;
	float catTransparency = 0;
	[SerializeField]
	int catTransparencySpeed = 0;

	SpriteRenderer sr;

	void Start(){
		sr = GetComponent<SpriteRenderer>();
		sr.color = new Color(1.0f, 1.0f, 1.0f, 0);
	}
	
	
	void FixedUpdate () {
		catAlife += Time.deltaTime;

		catTransparency += Time.deltaTime * catTransparencySpeed;

		CapsuleCollider2D cc2d = GetComponent<CapsuleCollider2D>();
		if(catTransparency < 0.4f){
			cc2d.enabled = false;
		}else{
			cc2d.enabled = true;
		}


		sr.color = new Color(1.0f,1.0f,1.0f,Mathf.Sin(180 * catTransparency * Mathf.Deg2Rad));

		if(catAlife > 1){
			GameObject catgene = GameObject.FindWithTag("Generator");
			catgene.GetComponent<CatGenerator>().catgene();
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
			GameObject catgene = GameObject.FindWithTag("Generator");
			catgene.GetComponent<CatGenerator>().catgene();
			Destroy(gameObject);
			// ここにタップ成功時の処理
			GameObject GameDirector = GameObject.FindWithTag("Director");
			GameDirector.GetComponent<GameDirector>().GetCat();
		}
	}
}
