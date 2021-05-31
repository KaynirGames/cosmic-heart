using UnityEngine;

public class CustomGrid<T>
{
    private int _width;
    private int _height;
    private float _cellSize;
    private Vector3 _origin;
    private T[,] _gridArray;

    public CustomGrid(int width, int height, float cellSize, Vector3 origin)
    {
        _width = width;
        _height = height;
        _cellSize = cellSize;
        _origin = origin;
        _gridArray = new T[_width, _height];
    }

    public int GetWidth()
    {
        return _width;
    }

    public int GetHeight()
    {
        return _height;
    }

    public void SetValue(int x, int y, T value)
    {
        if (IsValidPosition(x, y))
        {
            _gridArray[x, y] = value;
        }
    }

    public void SetValue(Vector3 worldPosition, T value)
    {
        Vector2Int gridPos = GetGridPosition(worldPosition);
        SetValue(gridPos.x, gridPos.y, value);
    }

    public T GetValue(int x, int y)
    {
        if (IsValidPosition(x, y))
        {
            return _gridArray[x, y];
        }

        return default;
    }

    public T GetValue(Vector3 worldPosition)
    {
        Vector2Int gridPos = GetGridPosition(worldPosition);
        return GetValue(gridPos.x, gridPos.y);
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * _cellSize + _origin;
    }

    public Vector2Int GetGridPosition(Vector3 worldPosition)
    {
        return new Vector2Int
        {
            x = Mathf.FloorToInt((worldPosition - _origin).x / _cellSize),
            y = Mathf.FloorToInt((worldPosition - _origin).y / _cellSize)
        };
    }

    private bool IsValidPosition(int x, int y)
    {
        return x >= 0 && y >= 0 && x < _width && y < _height;
    }
}