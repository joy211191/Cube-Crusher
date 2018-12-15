using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

    public float speed;
    Rigidbody rigidbody;
    Scoring scoring;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
        scoring = GetComponent<Scoring>();
    }

    private void FixedUpdate() {
        if (!scoring.gameComplete) {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            rigidbody.AddForce(transform.forward + (new Vector3(h, 0, v)) * speed);
        }
    }
}
