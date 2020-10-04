using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public Action<Vector3> OnPointerDown;
    public Action OnPointerUp;
    public Action<Vector3> OnPointerChange;
    public Action<Vector3> OnPointerSecondChange;
    public Action OnPointerSecondUp;

    [SerializeField]
    private Camera camera;
    [SerializeField]
    private LayerMask mouseInputMask;
    [SerializeField]
    private int cellSize = 3;
    

    public void Update() {
        GetPointerPosition();
        GetPanningPointer();
    }

    private void GetPointerPosition() {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, mouseInputMask)) {
                Vector3 position = hit.point - transform.position;
                OnPointerDown?.Invoke(position);
            }
        }
    }

    private void GetPanningPointer() {
        if (Input.GetMouseButton(1)) {
            var position = Input.mousePosition;
            OnPointerSecondChange?.Invoke(position);
        }
        if (Input.GetMouseButtonUp(1)) {
            OnPointerSecondUp?.Invoke();
        }
    }
}
