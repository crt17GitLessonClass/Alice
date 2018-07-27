﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	// 位置座標
	private Vector3 position;
	// スクリーン座標をワールド座標に変換した位置座標
	private Vector3 screenToWorldPointPosition;
	
	void Update () {
		// Vector3でマウス位置座標を取得する
		position = Input.mousePosition;
		// Z軸修正
		position.z = 10f;
		// マウス位置座標をスクリーン座標からワールド座標に変換する
		screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
		// ワールド座標に変換されたマウス座標を代入
		gameObject.transform.position = screenToWorldPointPosition;

		BoxCollider2D bc2d = GetComponent<BoxCollider2D>();
		if(Input.touchCount > 0 || Input.GetMouseButtonDown(0)){
			bc2d.enabled = true;
			StartCoroutine("bc2dEnabl", bc2d);
		}
	}

	IEnumerator bc2dEnabl(BoxCollider2D BC2D){
		yield return new WaitForSeconds(0.05f);
		BC2D.enabled = false;
	}
}
