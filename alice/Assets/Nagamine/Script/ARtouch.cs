using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARtouch : MonoBehaviour
{             

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ProcessTag();            
        }          
    }

    void ProcessTag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, 1000))
        {
            switch (hit.collider.tag)
            {
                case "Alice":
                    //print("rayがAliceに当たった。");
                    Debug.LogFormat("rayが {0} に当たった。", hit.collider.tag);
                    //SceneManager.LoadScene("GameMain");    
                    break;

                case "CutEnd":
                    Debug.LogFormat("rayが {0} に当たった。", hit.collider.tag);
                    // 切れ端をgetした時の処理
                    break;

                case "Twins":
                    Debug.LogFormat("rayが {0} に当たった。", hit.collider.tag);
                    // twinsをタッチした時の処理 
                    //SceneManager.LoadScene("Q2");
                    break;

                case "Cat":
                    Debug.LogFormat("rayが {0} に当たった。", hit.collider.tag);
                    // catをタッチした時の処理
                    //SceneManager.LoadScene("Q3");
                    break;

                case "Alie_folf":
                    Debug.LogFormat("rayが {0} に当たった。", hit.collider.tag);
                    // alice_folfをタッチした時の処理
                    //SceneManager.LoadScene("Q4");
                    break;

                case "WhiteRabbit":
                    Debug.LogFormat("rayが {0} に当たった。", hit.collider.tag);
                    // whiterabbitをタッチした時の処理
                    //SceneManager.LoadScene("Q5");
                    break;

                case "Caterpillar":
                    // caterrpillarをタッチした時の処理
                    //SceneManager.LoadScene("Q6");
                    break;

                default:
                    break;
            }
        }   
    }
}
