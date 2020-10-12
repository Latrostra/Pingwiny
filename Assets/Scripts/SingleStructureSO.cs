using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName="New Single Structure", menuName="Structure/StructureData/SingleStructure")]
public class SingleStructureSO : BaseStructureSO
{
    public GameObject[] gameObjectVariant;
    public bool upgradable;
    public UpgradeType[] availableUpgrades;
}

[System.Serializable]
public struct UpgradeType {
    public GameObject[] upgradeVarians;
    public int newIncome;
    public int newUpkeep;
}
