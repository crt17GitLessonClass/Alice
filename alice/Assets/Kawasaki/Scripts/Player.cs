using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    float speed = 10.0f;
    GameController GC;
    Rigidbody rb;


    void Start() {
        GC = GameObject.Find("GameController").GetComponent<GameController>();
        rb = GetComponent<Rigidbody>();


    }

    void FixedUpdate() {
        Move();

    }

    void Update() {


    }

    void Move() {
        if (GC.clear || GC.gameover) {
            rb.velocity = Vector3.zero;
            return;
        }

        Vector3 dir = Vector3.zero;

        dir.x = Input.acceleration.x;
        dir.z = Input.acceleration.y;

        // Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(dir * speed);

    }


    void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "card1" && GC.flag1) {
            GC.flag1 = false;
            GC.flag4 = true;
        } else if (other.gameObject.tag == "card4" && GC.flag4) {
            GC.flag4 = false;
            GC.flag5 = true;
        } else if (other.gameObject.tag == "card5" && GC.flag5) {
            GC.flag5 = false;
            GC.flag10 = true;
        } else if (other.gameObject.tag == "card10" && GC.flag10) {
            GC.flag10 = false;
            GC.Clear();
        } else {
            GC.Reset(this.gameObject);

        }

    }
}
