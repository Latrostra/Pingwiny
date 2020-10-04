using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private InputManager inputManager;
    [SerializeField]
    private PlacementManager placementManager;
    [SerializeField]
    private UiController uiController;
    private GridStructure grid;
    [SerializeField]
    private int cellSize = 3;
    [SerializeField]
    private CameraMovement cameraMovement;
    public int width, length;
    private bool isBuildingMode = false;
    // Start is called before the first frame update
    private void Awake() {
        cameraMovement.SetCameraBounds(width, 0, length, 0);
        inputManager.OnPointerDown += OnPointerDownHandler;
        inputManager.OnPointerSecondChange += OnSecondPointerChangeHandler;
        inputManager.OnPointerSecondUp += OnSecondPointerUpHandler;
        uiController.OnBuildArea += OnBuildingModeHandler;
        uiController.OnCancelAction += OnCancelModeHandler;
    }
    void Start()
    {
        grid = new GridStructure(cellSize, width, length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDownHandler(Vector3 position) {
        Vector3 gridPosition = grid.CalculateGridPosition(position);
        if (isBuildingMode && grid.IsCellTaken(gridPosition) == false) {
            placementManager.CreateBuildings(gridPosition, grid);
        }
    }

    public void OnSecondPointerChangeHandler(Vector3 position) {
        if (isBuildingMode == false) {
            cameraMovement.MoveCamera(position);
        }
    }

    public void OnSecondPointerUpHandler() {
        cameraMovement.StopCameraMovement();
    }

    private void OnBuildingModeHandler() {
        isBuildingMode = true;
    }

    private void OnCancelModeHandler() {
        isBuildingMode = false;
    }
}
