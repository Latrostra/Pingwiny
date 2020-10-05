using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuildingSelectionState : PlayerState
{
    private PlacementManager placementManager;
    private GridStructure grid;
    public PlayerBuildingSelectionState(GameManager gameManager, PlacementManager placementManager, GridStructure grid) : base(gameManager) {
        this.placementManager = placementManager;
        this.grid = grid;
    }
    public override void OnInputPanChange(Vector3 position) {
        return;
    }

    public override void OnInputPanUp() {
        return;
    }

    public override void OnInputPointerChange(Vector3 position) {
        Debug.Log(position);
    }

    public override void OnInputPointerDown(Vector3 position) {
        Vector3 gridPosition = grid.CalculateGridPosition(position);
        if (grid.IsCellTaken(gridPosition) == false) {
            placementManager.CreateBuildings(gridPosition, grid);
        }
    }

    public override void OnInputPointerUp() {
        return;
    }

    public override void OnCancel() {
        this.gameManager.TransistionToState(this.gameManager.playerSelectionState);
    }
}
