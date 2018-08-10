using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour {

	public GameObject Camera;
	public Vector3[] PutPosEasy;

	bool[] panelOn = new bool[20];
	Vector3 startPos;

	Camera cam;
	GameObject MovingPiece;
	BoxCollider MovingPieceCol;
	Renderer MovingPieceRen;

	void Start () {
		cam = Camera.GetComponent<Camera>();
		for(int i = 0; i < panelOn.Length; i++){
			panelOn[i] = false;
		}
	}
	
	void FixedUpdate () {
		if(Input.touchCount == 1){
			Touch t = Input.GetTouch(0);
			if(t.phase == TouchPhase.Began){
				transform.position = cam.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, -Camera.transform.position.z));
			}
			if(MovingPiece != null){
				MovingPiece.transform.position = cam.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, -Camera.transform.position.z));
				if(t.phase == TouchPhase.Ended){
					MovingPiece.transform.position = SearchNearest(cam.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, -Camera.transform.position.z)));
					MovingPieceRen.sortingOrder--;
					MovingPieceCol.enabled = true;
					MovingPiece = null;
					transform.position = new Vector3(0, 0, 10);
				}
			}
		}
	}

	void OnTriggerEnter(Collider other){
		startPos = other.gameObject.transform.position;
		MovingPiece = other.gameObject;
		MovingPieceCol = other.gameObject.GetComponent<BoxCollider>();
		MovingPieceCol.enabled = false;
		MovingPieceRen = other.gameObject.GetComponent<Renderer>();
		MovingPieceRen.sortingOrder++;
		for(int i = 0; i < PutPosEasy.Length; i++){
			if(PutPosEasy[i] == MovingPiece.transform.position){
				panelOn[i] = false;
			}
		}
	}

	Vector3 SearchNearest(Vector3 pos){
		float nearest = 10000f;
		Vector3 nearestPos = new Vector3(0, 0, 0);
		for(int i = 0; i < PutPosEasy.Length; i++){
			float dist = Vector3.Distance(PutPosEasy[i], pos);
			if(dist < nearest){
				nearest = dist;
				nearestPos = PutPosEasy[i];
			}
		}
		for(int i = 0; i < PutPosEasy.Length; i++){
			if(PutPosEasy[i] == nearestPos){
				if(panelOn[i]){
					nearestPos = startPos;
				}else{
					panelOn[i] = true;
				}
			}
		}
		return nearestPos;
	}
}
