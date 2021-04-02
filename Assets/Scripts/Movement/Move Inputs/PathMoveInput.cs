using UnityEngine;

public class PathMoveInput : BaseMoveInput
{
    [SerializeField] private PathCreator _pathCreator = null;
    [SerializeField] private bool _loopPath = false;

    private WaypointData _waypoint;
    private int _lastWaypointIndex;
    private bool _isFollowing;
    private bool _isReverse;

    private void Start()
    {
        _waypoint = GetWaypoint(0);
        _lastWaypointIndex = _pathCreator.EndPointIndex;
        _isFollowing = true;
        _isReverse = false;
    }

    private void Update()
    {
        if (_isFollowing)
        {
            FollowPath();
        }
    }

    public override Vector3 GetMoveInput()
    {
        return _isFollowing
            ? (_waypoint.Position - transform.position).normalized
            : Vector3.zero;
    }

    private WaypointData GetWaypoint(int index)
    {
        return _pathCreator.GetNextWaypoint(transform.position,
                                            index,
                                            _isReverse);
    }

    private void FollowPath()
    {
        if (CheckPathEnd())
        {
            if (!_loopPath)
            {
                _isFollowing = false;
                return;
            }

            HandlePathLoop();
        }

        _waypoint = GetWaypoint(_waypoint.Index);
    }

    private void HandlePathLoop()
    {
        _lastWaypointIndex = _lastWaypointIndex == 0
            ? _pathCreator.EndPointIndex
            : 0;

        _isReverse = !_isReverse;
    }

    private bool CheckPathEnd()
    {
        return _waypoint.Index == _lastWaypointIndex
            ? _pathCreator.InPosition(transform.position,
                                      _lastWaypointIndex)
            : false;
    }
}
