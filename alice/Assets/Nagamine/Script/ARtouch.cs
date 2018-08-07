using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARtouch : MonoBehaviour
{
    //GameObject gameObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, 1000))
            {
                //Debug.Log(hit.gameObject.name);
                if(hit.collider.tag == "Alice")
                {
                    print("rayがAliceに当たった。");
                    //SceneManager.LoadScene("Q3");
                }
            }
        }
    }
}
