﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startEnding : MonoBehaviour {
	IEnumerator Start(){
		yield return new WaitForSeconds(3.0f);
		SceneManager.LoadScene("Ending");
	}
}
