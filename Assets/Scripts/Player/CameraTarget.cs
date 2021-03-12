using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour {
    [SerializeField] Camera mainCamera;

    [Header("Camera Configuration")]
    [SerializeField] float cameraOffsetX = .0f;
    [SerializeField] float cameraOffsetZ = -8.0f;
    [SerializeField] float cameraDistance = 12.0f;
    [SerializeField] short cameraAngle = 45;
    [SerializeField] float minZoom = 8.0f;
    [SerializeField] float maxZoom = 22.0f;
    [SerializeField] float zoomSpeed = .1f;
    [SerializeField] float cameraLerp = 5.0f;

    Transform selfTransform;

    void Start() {
        selfTransform = this.GetComponent<Transform>();
    }

    void Update() {
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.I))
            if (cameraDistance < maxZoom)
                cameraDistance += zoomSpeed;
            
        if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.O))
            if (cameraDistance > minZoom)
                cameraDistance -= zoomSpeed;
    }

    void FixedUpdate() {
        mainCamera.transform.rotation = Quaternion.Euler(cameraAngle, .0f, .0f);

        mainCamera.transform.position = Vector3.Lerp(
            mainCamera.transform.position,
            new Vector3(
                selfTransform.position.x + cameraOffsetX,
                selfTransform.position.y + cameraDistance,
                selfTransform.position.z + cameraOffsetZ
            ),
            Time.fixedDeltaTime * cameraLerp
        );
    }
}
