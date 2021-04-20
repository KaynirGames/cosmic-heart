using System.Collections.Generic;
using UnityEngine;

public class PathCreator : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints = new List<Transform>();
    [SerializeField] private float _waypointRadius = .15f;
    [SerializeField] private bool _drawPath = true;
    [SerializeField] private Color _lineColor = Color.green;
    [SerializeField] private Color _radiusColor = Color.red;

    public int EndPointIndex => _waypoints.Count - 1;

    public WaypointData GetNextPointData(Vector3 worldPos, int currentPoint, FollowPathMode followMode)
    {
        Vector3 waypointPos = GetPosition(Mathf.Abs(currentPoint));

        if (InPosition(worldPos, waypointPos))
        {
            currentPoint = GetNextPointIndex(currentPoint, followMode);
            waypointPos = GetPosition(currentPoint);
        }

        return new WaypointData(waypointPos, currentPoint);
    }

    public bool InPosition(Vector3 worldPos, int waypointIndex)
    {
        return InPosition(worldPos, GetPosition(waypointIndex));
    }

    private bool InPosition(Vector3 worldPos, Vector3 waypointPos)
    {
        return (worldPos - waypointPos).sqrMagnitude <= _waypointRadius;
    }

    private Vector3 GetPosition(int waypointIndex)
    {
        return _waypoints[waypointIndex].position;
    }

    private int GetNextPointIndex(int currentIndex, FollowPathMode followMode)
    {
        switch (followMode)
        {
            case FollowPathMode.PingPong:
                return GetPingPongPointIndex(currentIndex);
            case FollowPathMode.Loop:
                return GetLoopPointIndex(currentIndex);
            case FollowPathMode.Direct:
                return GetDirectPointIndex(currentIndex);
            default:
                return GetDirectPointIndex(currentIndex);
        }
    }

    private int GetDirectPointIndex(int currentIndex)
    {
        return Mathf.Clamp(++currentIndex, 0, EndPointIndex);
    }

    private int GetPingPongPointIndex(int currentIndex)
    {
        return Mathf.Abs(++currentIndex);
    }

    private int GetLoopPointIndex(int currentIndex)
    {
        return currentIndex == EndPointIndex
            ? currentIndex - EndPointIndex
            : ++currentIndex;
    }

    private void OnDrawGizmos()
    {
        if (!_drawPath)
        {
            return;
        }

        if (_waypoints.Count > 0)
        {
            for (int i = 0; i < _waypoints.Count; i++)
            {
                Vector3 position = _waypoints[i].position;

                if (i > 0)
                {
                    Vector3 previous = _waypoints[i - 1].position;
                    Gizmos.color = _lineColor;
                    Gizmos.DrawLine(position, previous);
                    Gizmos.color = _radiusColor;
                    Gizmos.DrawWireSphere(position, _waypointRadius);
                }
            }
        }
    }
}