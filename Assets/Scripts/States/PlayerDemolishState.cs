﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDemolishState : PlayerState
{
    public BuildingManager buildingManager;
    public GridStructure grid;
    public PlayerDemolishState(GameManager gameManager, BuildingManager buildingManager, GridStructure grid) : base(gameManager)
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
        return;
    }

    public override void OnInputPanUp()
    {
        return;
    }

    public override void OnInputPointerChange(Vector3 position)
    {
        return;
    }

    public override void OnInputPointerDown(Vector3 position)
    {
        buildingManager.RemoveStructureAt(position);
    }

    public override void OnInputPointerUp()
    {
        return;
    }
}
