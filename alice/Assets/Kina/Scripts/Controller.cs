using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public GameObject cameraObject;
	public BoxCollider[] maruTrueCol;
	public BoxCollider[] maruFalseCol;
	public SpriteRenderer[] maruTrueSprite;
	public SpriteRenderer[] maruFalseSprite;

	public int timeLimit = 60;

	Vector3 cameraStartPos;
	Vector3 touchStartPos;
	Vector3 targetPos;
	Vector3 movingCenter;

	Vector2 pinchCenter;

	float Dist;
	float changingDist;

	bool cameraMoving = false;

	Camera Camera;
	BoxCollider touchCol;

	void Start(){
		StartCoroutine(CountDown());
		cameraStartPos = cameraObject.transform.position;
		Camera = cameraObject.GetComponent<Camera>();
		touchCol = gameObject.GetComponent<BoxCollider>();
	}

	void FixedUpdate(){
		//タッチ・スワイプ
		if(Input.touchCount == 1){
			Touch t = Input.GetTouch(0);
			Vector3 touchingPos = Input.touches[0].position;
			if(t.phase == TouchPhase.Began){
				touchStartPos = Input.touches[0].position;
				movingCenter = cameraObject.transform.position;
				cameraMoving = true;
			}
			if(t.phase == TouchPhase.Ended){
				Dist = Vector2.Distance(touchingPos, touchStartPos);
				if(Dist <= 10f){
					TouchScreen(Camera.ScreenToWorldPoint(new Vector3(touchingPos.x, touchingPos.y, 0 - cameraObject.transform.position.z)));
				}
				cameraMoving = false;
			}
			Vector3 v = touchingPos - touchStartPos;
			if(cameraMoving){
				Vector3 position = movingCenter;
				position.x += -v.x * (cameraObject.transform.position.z / cameraStartPos.z) / 40;
				position.y += -v.y * (cameraObject.transform.position.z / cameraStartPos.z) / 40;
				cameraObject.transform.position = LimitingPos(position);
			}
		}
		//ピンチイン・アウト
		if(Input.touchCount == 2){
			Touch t1 = Input.GetTouch(0);
			Touch t2 = Input.GetTouch(1);
			Vector2 touchPos1 = Input.touches[0].position;
			Vector2 touchPos2 = Input.touches[1].position;
			changingDist = Vector2.Distance(touchPos1, touchPos2);
			if(t1.phase == TouchPhase.Began || t2.phase == TouchPhase.Began){
				pinchCenter = (touchPos1 + touchPos2) / 2;
				movingCenter = cameraObject.transform.position;
				Dist = changingDist;
				targetPos = Camera.ScreenToWorldPoint(new Vector3(pinchCenter.x, pinchCenter.y, 0 - cameraObject.transform.position.z));
				cameraMoving = true;
			}
			if(t1.phase == TouchPhase.Ended || t2.phase == TouchPhase.Ended){
				cameraMoving = false;
			}
			if(cameraMoving){
				Vector3 position = movingCenter;
				position.x += (targetPos.x - cameraStartPos.x) * ((changingDist - Dist) / 250);
				position.y += (targetPos.y - cameraStartPos.y) * ((changingDist - Dist) / 250);
				position.z += (targetPos.z - cameraStartPos.z) * ((changingDist - Dist) / 250);
				cameraObject.transform.position = LimitingPos(position);
			}
		}
	}

	void TouchScreen(Vector3 pos){
		touchCol.center = pos;
	}

	void OnTriggerEnter(Collider other){
		int i = int.Parse(other.gameObject.name);
		maruTrueCol[i].enabled = false;
		maruFalseCol[i].enabled = false;
		maruTrueSprite[i].enabled = true;
		maruFalseSprite[i].enabled = true;
	}

	IEnumerator CountDown(){
		for(int i = timeLimit; i >= 0; i--){
			yield return new WaitForSeconds(1.0f);
			timeLimit--;
		}
	}

	Vector3 LimitingPos(Vector3 pos){
		pos.z = Mathf.Clamp(pos.z, cameraStartPos.z, -5);
		pos.x = Mathf.Clamp(pos.x, -(22f / -cameraStartPos.z * pos.z + 22f), 22f / -cameraStartPos.z * pos.z + 22f);
		pos.y = Mathf.Clamp(pos.y, -(15f / -cameraStartPos.z * pos.z + 15f), 15f / -cameraStartPos.z * pos.z + 15f);
		return pos;
	}
}
