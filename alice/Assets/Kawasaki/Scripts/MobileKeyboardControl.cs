using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MobileKeyboardControl : MonoBehaviour {

    TouchScreenKeyboard keyboard;
    public Text test;
    int cutend = 4;
    


    void Start() {
        //keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        

    }

    void Update() {

        if (!keyboard.active) {
            if (keyboard.text == "ウサギ" || keyboard.text == "うさぎ") {
                test.GetComponent<Text>().text = "正解";
                GameMainCtrl.ceGet += cutend;
                GameMainCtrl.f_Q5 = true;
                SceneManager.LoadScene("CutEnd");
               

            } else {
                //TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
                test.GetComponent<Text>().text = "不正解";

            }
        }
    }

    public void OpenKeyboard() {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);


    }
}
