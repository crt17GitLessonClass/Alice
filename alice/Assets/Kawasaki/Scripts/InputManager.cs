using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour {

    InputField inputField;


    void Start() {


        inputField = GameObject.Find("InputField").GetComponent<InputField>();

        InitInputField();
    }




    public void InputLogger() {

        string inputValue = inputField.text;

        Debug.Log(inputValue);

        if (inputValue == "うさぎ" || inputValue == "ウサギ")
            print("clear");

        InitInputField();
    }

    


    void InitInputField() {

        // 値をリセット
        inputField.text = "";

        // フォーカス
        inputField.ActivateInputField();
    }

}
