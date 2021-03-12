using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    [SerializeField]
    public int width, height;

    private VillageGrid placementGrid;

    private Dictionary<Vector3Int, GameObject> structureDictionary = new Dictionary<Vector3Int, GameObject>();

    private void Start()
    {
        placementGrid = new VillageGrid(width, height);
    }

    internal bool CheckIfPositionInBound(Vector3Int position)
    {
        return position.x >= 0 && position.x < width && position.z >= 0 && position.z < height;    
    }

    internal void PlaceObjectOnTheMap(Vector3Int position, GameObject structurePrefab, CellType type)
    {
        GameObject structure = CreateANewBuild(position, structurePrefab, type);
        placementGrid[position.x, position.z] = type;
        structureDictionary.Add(position, structure);
    }

    internal bool CheckIfPositionIsFree(Vector3Int position)
    {
        return CheckIfPositionIsOfType(position, CellType.Empty);
    }

    private bool CheckIfPositionIsOfType(Vector3Int position, CellType type)
    {
        return placementGrid[position.x, position.z] == type;
    }

    internal List<Vector3Int> GetNeighboursOfTypeFor(Vector3Int position, CellType type)
    {
        var neighbourVertices = placementGrid.GetAdjacentCellsOfType(position.x, position.z, type);
        List<Vector3Int> neighbours = new List<Vector3Int>();

        foreach (var point in neighbourVertices)
        {
            neighbours.Add(new Vector3Int(point.X, 0, point.Y));
        }

        return neighbours;
    }

    private GameObject CreateANewBuild(Vector3Int position, GameObject structurePrefab, CellType type)
    {
        GameObject structure = Instantiate(structurePrefab);
        structure.transform.position = position;

        return structure;
    }
}