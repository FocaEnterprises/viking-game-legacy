using System;
using UnityEngine;

public class StructureManager : MonoBehaviour
{
    [SerializeField]
    public BuildPrefabs constructorHouse;

    public BuildPrefabs[] buildPrefabs;
    private PlacementManager placementManager;

    private void Start()
    {
        placementManager = GetComponent<PlacementManager>();
        buildPrefabs = new BuildPrefabs[]{ constructorHouse };
    }

    public void PlaceStructure(Vector3Int position)
    {
        PlaceStructure(position, buildPrefabs[0].prefab);
    }

    public void PlaceStructure(Vector3Int position, GameObject prefab)
    {
        if (CheckPositionBeforePlacement(position))
        {
            placementManager.PlaceObjectOnTheMap(position, prefab, CellType.Structure);
        }
    }

    private bool CheckPositionBeforePlacement(Vector3Int position)
    {
        if (placementManager.CheckIfPositionInBound(position) == false)
        {
            return false;
        }

        if (placementManager.CheckIfPositionIsFree(position) == false)
        {
            return false;
        }
        
        return true;
    }
}

[Serializable]
public struct BuildPrefabs
{
    public GameObject prefab;
}