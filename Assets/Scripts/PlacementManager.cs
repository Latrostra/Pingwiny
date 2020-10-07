using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    [SerializeField]
    private GameObject buildingPrefab;
    [SerializeField]
    private Transform ground;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateBuildings(Vector3 gridPosition, GridStructure grid) {
        GameObject newStructure = Instantiate(buildingPrefab, ground.position+gridPosition, Quaternion.identity);
        grid.PlaceStructureOnTheGrid(newStructure, gridPosition);
    }

    public void RemoveBuildings(Vector3 gridPosition, GridStructure grid)
    {
        grid.RemoveStructureOnTheGrid(gridPosition);
    }
}
