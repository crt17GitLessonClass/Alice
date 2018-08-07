using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatGenerator : MonoBehaviour {
    [SerializeField]
    GameObject[] cats;
    [SerializeField]
	Vector2[] catPopPos;

	void Start () {
		Invoke("catgene", 0.5f);
	}

    public void catgene() {
        int i = Random.Range(0, cats.Length);
        Instantiate(cats[i], catPopPos[i], Quaternion.identity);
        // int catCount = 0;
        // if(catCount <= 0){
        //     Instantiate(cats[i], catPopPos[i], Quaternion.identity);
        // }
    }
}
