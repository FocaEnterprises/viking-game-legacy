using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
    [SerializeField]
    float movementSpeed = 4.0f;
    [SerializeField]
    byte rotationSmoothness = 15;

    Vector3 velocity = Vector3.zero;

    Transform selfTransform;

    void Start() {
        selfTransform = this.GetComponent<Transform>();
    }

    void Update() {
        velocity.x = Input.GetAxis("Horizontal");
        velocity.z = Input.GetAxis("Vertical");
    }

    void FixedUpdate() {
        if (velocity != Vector3.zero) {
            selfTransform.Translate(
                Vector3.forward * velocity.magnitude * movementSpeed * Time.fixedDeltaTime,
                Space.Self
            );

            var direction = Quaternion.LookRotation(velocity);
            selfTransform.rotation = Quaternion.Lerp(selfTransform.rotation, direction, Time.fixedDeltaTime * rotationSmoothness);
        }
    }
}
