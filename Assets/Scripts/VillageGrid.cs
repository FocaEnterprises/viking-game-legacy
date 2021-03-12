using System.Collections.Generic;

/// <summary>
/// Source https://github.com/SunnyValleyStudio/SimpleCityBuilder/blob/master/Grid.cs
/// </summary>
public class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }
}

public enum CellType
{
    Empty,
    Ruin,
    Structure,
    None
}

public class VillageGrid
{
    private int _width;
    private int _height;
    
    private CellType[,] _grid;

    public VillageGrid(int width, int height)
    {
        _width = width;
        _height = height;
        _grid = new CellType[width, height];
    }

    public CellType this[int i, int j]
    {
        get
        {
            return _grid[i, j];
        }

        set
        {
            _grid[i, j] = value;
        }
    }

    public List<Point> GetAllAdjacentCells(int x, int y)
    {
        List<Point> adjacentCells = new List<Point>();

        if (x > 0)
        {
            adjacentCells.Add(new Point(x - 1, y));
        }

        if (x < _width - 1)
        {
            adjacentCells.Add(new Point(x + 1, y));
        }

        if (y > 0)
        {
            adjacentCells.Add(new Point(x, y - 1));
        }

        if (y < _height - 1)
        {
            adjacentCells.Add(new Point(x, y + 1));
        }

        return adjacentCells;
    }

    public List<Point> GetAdjacentCellsOfType(int x, int y, CellType type)
    {
        List<Point> adjacentCells = GetAllAdjacentCells(x, y);

        for (int i = adjacentCells.Count - 1; i >= 0; i--)
        {
            if (_grid[adjacentCells[i].X, adjacentCells[i].Y] != type)
            {
                adjacentCells.RemoveAt(i);
            }
        }

        return adjacentCells;
    }
}