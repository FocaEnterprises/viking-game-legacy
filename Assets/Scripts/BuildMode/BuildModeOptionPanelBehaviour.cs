using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildModeOptionPanelBehaviour : MonoBehaviour {
    [SerializeField] int toggleOffset = 370;
    [SerializeField] float lerpAmount = 10;

    Vector3 startPosition;

    bool toggleStatus = false;

    RectTransform selfRectTransform;

    void Start() {
        selfRectTransform = this.GetComponent<RectTransform>();
        startPosition = selfRectTransform.position;
    }

    public void Toggle() {
        toggleStatus = (toggleStatus == true) ? false : true;
    }

    void FixedUpdate() {
        if (toggleStatus == true) {
            selfRectTransform.position = Vector3.Lerp(
                selfRectTransform.position,
                new Vector3(
                    startPosition.x - toggleOffset,
                    startPosition.y
                ),
                Time.fixedDeltaTime * lerpAmount
            );
        }
        else {
            selfRectTransform.position = Vector3.Lerp(
                selfRectTransform.position,
                startPosition,
                Time.fixedDeltaTime * lerpAmount
            );
        }
    }
}
