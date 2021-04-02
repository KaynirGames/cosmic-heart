using System.Collections.Generic;
using UnityEngine;

public class PathCreator : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints = null;
    [SerializeField] private float _waypointRadius = .15f;
    [SerializeField] private bool _drawPath = true;
    [SerializeField] private Color _lineColor = Color.green;
    [SerializeField] private Color _radiusColor = Color.red;

    public int EndPointIndex => _waypoints.Count - 1;

    public WaypointData GetNextWaypoint(Vector3 worldPos, int currentWaypoint, bool reversePath = false)
    {
        Vector3 waypointPos = GetPosition(currentWaypoint);

        if (InPosition(worldPos, waypointPos))
        {
            currentWaypoint += reversePath ? -1 : 1;
            currentWaypoint = Mathf.Clamp(currentWaypoint, 0, EndPointIndex);

            waypointPos = GetPosition(currentWaypoint);
        }

        return new WaypointData(waypointPos, currentWaypoint);
    }

    public bool InPosition(Vector3 worldPos, int waypointIndex)
    {
        return InPosition(worldPos, GetPosition(waypointIndex));
    }

    private bool InPosition(Vector3 worldPos, Vector3 waypointPos)
    {
        return Vector3.Distance(worldPos, waypointPos) <= _waypointRadius;
    }

    private Vector3 GetPosition(int waypointIndex)
    {
        return _waypoints[waypointIndex].position;
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