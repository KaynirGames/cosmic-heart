using System.Collections.Generic;
using UnityEngine;

public class PathCreator : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints = new List<Transform>();
    [SerializeField] private float _waypointRadius = .15f;
    [SerializeField] private bool _drawPath = true;
    [SerializeField] private Color _lineColor = Color.green;
    [SerializeField] private Color _radiusColor = Color.red;

    public Vector3[] GetPoints()
    {
        return _waypoints.ConvertAll(point => point.position)
                         .ToArray();
    }

    public bool InPosition(Vector3 worldPos, Vector3 pointPos)
    {
        return (worldPos - pointPos).sqrMagnitude <= _waypointRadius;
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