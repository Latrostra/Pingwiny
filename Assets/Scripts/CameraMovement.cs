﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3? basePointerPosition = null;
    [SerializeField]
    private float cameraMovementSpeed = 0.05f;
    private int cameraXMin, cameraXMax, cameraZMin, cameraZMax;

    public void MoveCamera(Vector3 pointerPosition) {
        if (basePointerPosition.HasValue == false) {
            basePointerPosition = pointerPosition;
        }
        Vector3 newPosition = pointerPosition - basePointerPosition.Value;
        newPosition = new Vector3(newPosition.x, 0, newPosition.y);
        transform.Translate(newPosition * cameraMovementSpeed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, cameraXMin, cameraXMax),
                                        0,
                                        Mathf.Clamp(transform.position.z, cameraZMin, cameraZMax));
    }

    public void StopCameraMovement() {
        basePointerPosition = null;
    }

    public void SetCameraBounds(int cameraXMax, int cameraXMin, int cameraZMax, int cameraZMin) {
        this.cameraXMax = cameraXMax;
        this.cameraXMin = cameraXMin;
        this.cameraZMax = cameraZMax;
        this.cameraZMin = cameraZMin;
    }
}
