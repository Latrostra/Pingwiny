using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuildingSelectionState : PlayerState
{
    private BuildingManager buildingManager;
    private GridStructure grid;
    public PlayerBuildingSelectionState(GameManager gameManager, BuildingManager buildingManager, GridStructure grid) : base(gameManager) {
        this.buildingManager = buildingManager;
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
        buildingManager.BuildStructureAt(position);
    }

    public override void OnInputPointerUp() {
        return;
    }

    public override void OnCancel() {
        this.gameManager.TransistionToState(this.gameManager.playerSelectionState);
    }
}
