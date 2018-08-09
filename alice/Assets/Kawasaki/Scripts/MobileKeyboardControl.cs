using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MobileKeyboardControl : MonoBehaviour {

    TouchScreenKeyboard keyboard;


    void Start() {
        //keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);

    }

    void Update() {

        if (!keyboard.active) {
            if (keyboard.text == "ウサギ" || keyboard.text == "うさぎ") {
                SceneManager.LoadScene("CutEnd");
               

            } else {
                print("不正解");
                //TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);

            }
        }
    }

    public void OpenKeyboard() {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);


    }
}
