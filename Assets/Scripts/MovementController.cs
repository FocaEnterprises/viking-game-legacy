using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
    [SerializeField]
    float movementSpeed = 4.0f;
    [SerializeField]
    float rotationSpeed = 4.0f;

    float velocity = .0f;
    float rotation = .0f;

    static Transform s_selfTransform;

    void Start() {
        s_selfTransform = this.GetComponent<Transform>();
    }

    void Update() {
        rotation = Input.GetAxis("Horizontal");
        velocity = Input.GetAxis("Vertical");
    }

    /* roda sempre em 60 fps */
    void FixedUpdate() {
        s_selfTransform.Translate(Vector3.forward * velocity * movementSpeed * Time.fixedDeltaTime, Space.Self);
        s_selfTransform.Rotate(new Vector3(.0f, rotation * rotationSpeed, .0f), Space.Self);
    }
}
