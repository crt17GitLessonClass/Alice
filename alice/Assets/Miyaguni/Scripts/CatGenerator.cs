using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatGenerator : MonoBehaviour {
    [SerializeField]
    GameObject[] cats;

	void Start () {
		Invoke("catgene", 0.5f);
	}

    public void catgene() {
        int i = Random.Range(0, cats.Length);
        int catCount = 0;
        catCount--;
        if(catCount <= 0){
            Instantiate(cats[i], new Vector2(Random.Range(-7.35f,7.35f),Random.Range(-4,4)), Quaternion.identity);
            catCount = 1;
        }
    }
}
