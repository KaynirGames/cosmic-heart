using UnityEngine;

public struct WaypointData
{
    public Vector3 Position { get; }
    public int Index { get; }

    public WaypointData(Vector3 position, int index)
    {
        Position = position;
        Index = index;
    }
}
