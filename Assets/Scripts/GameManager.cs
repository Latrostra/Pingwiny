using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public InputManager inputManager;
    public PlacementManager placementManager;
    public UiController uiController;
    public CameraMovement cameraMovement;
    public int width, length;
    private GridStructure grid;
    private BuildingManager buildingManager;
    [SerializeField]
    private int cellSize = 3;

    private PlayerState state;
    public PlayerState State { get => state;}

    public PlayerSelectionState playerSelectionState;
    public PlayerBuildingSelectionState playerBuildingSelectionState;
    public PlayerDemolishState playerDemolishState;


    // Start is called before the first frame update
    private void Awake() {
        grid = new GridStructure(cellSize, width, length);
        buildingManager = new BuildingManager(placementManager, cellSize, width, length);

        playerSelectionState = new PlayerSelectionState(this, cameraMovement);
        playerBuildingSelectionState = new PlayerBuildingSelectionState(this, buildingManager, grid);
        playerDemolishState = new PlayerDemolishState(this, buildingManager, grid);
        state = playerSelectionState;
    }
    void Start()
    {
        cameraMovement.SetCameraBounds(width, 0, length, 0);
#region InputManagerCache
        inputManager.OnPointerDown += OnPointerDownHandler;
        inputManager.OnPointerUp += OnPointerUpHandler;
        inputManager.OnPointerChange += OnPointerChange;
        inputManager.OnPointerSecondChange += OnSecondPointerChangeHandler;
        inputManager.OnPointerSecondUp += OnSecondPointerUpHandler;
#endregion
        uiController.OnBuildArea += OnBuildingModeHandler;
        uiController.OnCancelAction += OnCancelModeHandler;
        uiController.OnDestroy += OnDestroyModeHandler;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDownHandler(Vector3 position) {
        state.OnInputPointerDown(position);
    }

    public void OnPointerUpHandler() {
        state.OnInputPointerUp();
    }

    public void OnPointerChange(Vector3 position) {
        state.OnInputPointerChange(position);
    }

    public void OnSecondPointerChangeHandler(Vector3 position) {
        state.OnInputPanChange(position);
    }

    public void OnSecondPointerUpHandler() {
        state.OnInputPointerUp();
    }

    private void OnBuildingModeHandler() {
        TransistionToState(playerBuildingSelectionState);
    }

    private void OnDestroyModeHandler() {
        TransistionToState(playerDemolishState);
    }

    private void OnCancelModeHandler() {
        state.OnCancel();
    }

    public void TransistionToState(PlayerState state) {
        this.state = state;
        this.state.EnterState();
    }
}
