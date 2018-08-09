using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileKeyboardControl : MonoBehaviour {
    TouchScreenKeyboard keyboard;
    public Text inputText;


    void Start() {
       // keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);


    }

    void Update() {

        if (!keyboard.active) {
            if (keyboard.text == "ウサギ" || keyboard.text == "うさぎ") {
                inputText.text = "正解";

            } else {
                inputText.text = "不正解";
                TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);

            }
        }
    }

    public void OpenKeyboard() {
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);


    }
}
