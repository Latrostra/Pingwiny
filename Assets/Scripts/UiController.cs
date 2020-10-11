using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public Action OnBuildArea;
    public Action OnDestroy;
    public Action OnCancelAction;
    [SerializeField]
    public Button buildButton;
    [SerializeField]
    public Button cancelButton;
    [SerializeField]
    public Button destroyButton;
    [SerializeField]
    public GameObject cancelButtonPanel; 
    // Start is called before the first frame update
    void Start()
    {
        cancelButtonPanel.SetActive(false);
        buildButton.onClick.AddListener(OnBuildAreaCallBack);
        destroyButton.onClick.AddListener(OnDestroyButtonCallBack);
        cancelButton.onClick.AddListener(OnCancelButtonCallBack);
    }

    private void OnBuildAreaCallBack() {
        cancelButtonPanel.SetActive(true);
        OnBuildArea?.Invoke();
    }

    private void OnCancelButtonCallBack() {
        cancelButtonPanel.SetActive(false);
        OnCancelAction?.Invoke();
    }

    private void OnDestroyButtonCallBack() {
        cancelButtonPanel.SetActive(true);
        OnDestroy?.Invoke();
    }
}
