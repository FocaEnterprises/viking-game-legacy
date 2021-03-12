using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
    [SerializeField]
    float movementSpeed = 5.0f;
    [SerializeField]
    byte rotationSmoothness = 10;

    Vector3 velocity = Vector3.zero;

    Transform selfTransform;

    void Start() {
        selfTransform = this.GetComponent<Transform>();
    }

    void Update() {
        velocity.x = Input.GetAxisRaw("Horizontal");
        velocity.z = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() {
        velocity = velocity.normalized;

        if (velocity != Vector3.zero) {
            selfTransform.Translate(
                Vector3.forward * velocity.magnitude * movementSpeed * Time.fixedDeltaTime,
                Space.Self
            );

            var direction = Quaternion.LookRotation(velocity);
            selfTransform.rotation = Quaternion.Lerp(
                selfTransform.rotation,
                direction,
                Time.fixedDeltaTime * rotationSmoothness
            );
        }
    }
}
