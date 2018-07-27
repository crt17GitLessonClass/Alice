using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat : MonoBehaviour {
	[SerializeField]
	float catAlife = 0.5f;
	
	
	void FixedUpdate () {
		catAlife += Time.deltaTime;
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
