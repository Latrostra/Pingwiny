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
    

    public void Update() {
        GetPointerPosition();
        GetPanningPointer();
    }

    private void GetPointerPosition() {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            CallActionOnPointer(OnPointerDown);
        }
        if (Input.GetMouseButton(0)) {
            CallActionOnPointer(OnPointerChange);
        }

        if (Input.GetMouseButtonUp(0)) {
            OnPointerUp?.Invoke();
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

    private void CallActionOnPointer(Action<Vector3> action) {
        Vector3? position = GetMousePosition();
            if (position.HasValue)
            {
                action?.Invoke(position.Value);
                position = null;
            }
    }
    private Vector3? GetMousePosition()
    {
        var ray = camera.ScreenPointToRay(Input.mousePosition);
        Vector3? position = null;
        RaycastHit hit;
        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, mouseInputMask))
        {
            position = hit.point - transform.position;
        }

        return position;
    }

    
}
