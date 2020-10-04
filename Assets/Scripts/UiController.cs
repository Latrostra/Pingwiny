using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public Action OnBuildArea;
    public Action OnCancelAction;
    [SerializeField]
    private Button buildButton;
    [SerializeField]
    private Button cancelButton;
    [SerializeField]
    private GameObject cancelButtonPanel; 
    // Start is called before the first frame update
    void Start()
    {
        cancelButtonPanel.SetActive(false);
        buildButton.onClick.AddListener(OnBuildAreaCallBack);
        cancelButton.onClick.AddListener(OnCancelButtonCallBack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBuildAreaCallBack() {
        cancelButtonPanel.SetActive(true);
        OnBuildArea?.Invoke();
    }

    private void OnCancelButtonCallBack() {
        cancelButtonPanel.SetActive(false);
        OnCancelAction?.Invoke();
    }
}
