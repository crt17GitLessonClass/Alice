using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearUI : MonoBehaviour {
	IEnumerator Start(){
		yield return new WaitForSeconds(1.0f);
		GameObject ExitButton = transform.Find("Exit").gameObject;
		ExitButton.SetActive(true);
	}

	public void ExitQ3(){
		SceneManager.LoadScene("Q3");
	}
}