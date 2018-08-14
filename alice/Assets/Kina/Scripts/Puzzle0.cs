using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle0 : MonoBehaviour {

	public GameObject Camera;
	public Text timeLimitText;
	public int timeLimit = 300;

	GameObject PutPos;
	Vector3 startPos;
	int count = 20;
	bool touching = false;

	Camera cam;
	GameObject MovingPiece;
	BoxCollider MovingPieceCol;
	Renderer MovingPieceRen;

	void Start () {
		StartCoroutine(countDown());
		cam = Camera.GetComponent<Camera>();
	}
	
	void FixedUpdate () {
		if(Input.touchCount == 1){
			Touch t = Input.GetTouch(0);
			transform.position = cam.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, -Camera.transform.position.z));
			if(t.phase == TouchPhase.Began){
				touching = true;
			}
			if(MovingPiece != null){
				MovingPiece.transform.position = cam.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, -Camera.transform.position.z));
				if(t.phase == TouchPhase.Ended){
					if(PutPos != null && PutPos.name.Substring(0) == MovingPiece.name.Substring(9)){
						MovingPiece.transform.position = PutPos.transform.position;
						count--;
					}else{
						MovingPiece.transform.position = startPos;
						MovingPieceCol.enabled = true;
					}
					MovingPieceRen.sortingOrder--;
					MovingPiece = null;
					PutPos = null;
					touching = false;
				}
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if(touching && other.gameObject.tag == "K_Piece"){
			startPos = other.gameObject.transform.position;
			MovingPiece = other.gameObject;
			touching = false;
			MovingPieceCol = other.gameObject.GetComponent<BoxCollider>();
			MovingPieceCol.enabled = false;
			MovingPieceRen = other.gameObject.GetComponent<Renderer>();
			MovingPieceRen.sortingOrder++;
		}
		if(other.gameObject.tag == "K_PutPos"){
			PutPos = other.gameObject;
		}
	}
	IEnumerator countDown(){
		while(timeLimit >= 0){
			yield return new WaitForSeconds(1.0f);
			timeLimit--;
			timeLimitText.text = timeLimit.ToString();
		}
	}
}
