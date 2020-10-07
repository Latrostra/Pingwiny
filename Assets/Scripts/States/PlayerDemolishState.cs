using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDemolishState : PlayerState
{
    public BuildingManager buildingManager;
    public GridStructure grid;
    public PlayerDemolishState(GameManager gameManager, BuildingManager buildingManager) : base(gameManager)
    {
        this.buildingManager = buildingManager;
        this.grid = grid;
    }
    public override void OnCancel()
    {
        this.gameManager.TransistionToState(this.gameManager.playerSelectionState);
    }

    public override void OnInputPanChange(Vector3 position)
    {
        throw new System.NotImplementedException();
    }

    public override void OnInputPanUp()
    {
        throw new System.NotImplementedException();
    }

    public override void OnInputPointerChange(Vector3 position)
    {
        throw new System.NotImplementedException();
    }

    public override void OnInputPointerDown(Vector3 position)
    {
        buildingManager.RemoveStructureAt(position);
    }

    public override void OnInputPointerUp()
    {
        throw new System.NotImplementedException();
    }
}
