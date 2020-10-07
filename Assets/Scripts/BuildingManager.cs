using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager
{
    GridStructure grid;
    PlacementManager placementManager;

    public BuildingManager(PlacementManager placementManager, int cellSize, int width, int length) {
        this.placementManager = placementManager;
        grid = new GridStructure(cellSize, width, length);
    }

    public void BuildStructureAt(Vector3 inputPosition) {
        Vector3 gridPosition = grid.CalculateGridPosition(inputPosition);
        if (grid.IsCellTaken(gridPosition)==false) {
            placementManager.CreateBuildings(gridPosition, grid);
        }
    }

    public void RemoveStructureAt(Vector3 inputPosition)
    {
        Vector3 gridPosition = grid.CalculateGridPosition(inputPosition);
        if (grid.IsCellTaken(gridPosition)==false) {
            placementManager.RemoveBuildings(gridPosition, grid);
        }
    }
}
