using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileKeyboardControl : MonoBehaviour {
    TouchScreenKeyboard keyboard;
    public Text inputText;


    void Start() {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        

    }

    void Update() {
        if (!keyboard.active) {
            
        }
    }
}
