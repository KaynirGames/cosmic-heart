using UnityEngine;

public class PathMoveInput : BaseMoveInput
{
    [SerializeField] private PathCreator _pathCreator = null;
    [SerializeField] private FollowPathMode _followMode = FollowPathMode.Direct;

    private int _endPointIndex;
    private int _targetPointIndex;
    private Vector3 _targetPointPosition;

    private bool _isFollowing;
    private bool _isReverse;

    private void Start()
    {
        _endPointIndex = _pathCreator.EndPointIndex;
        _targetPointIndex = 0;
        _targetPointPosition = GetPointData(0).Position;

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
            ? (_targetPointPosition - transform.position).normalized
            : Vector3.zero;
    }

    private void FollowPath()
    {
        if (CheckPathEnd())
        {
            HandlePathEnd(_followMode);
        }

        WaypointData waypointData = GetPointData(GetCurrentPointIndex());

        _targetPointIndex = Mathf.Abs(waypointData.Index);
        _targetPointPosition = waypointData.Position;
    }

    private int GetCurrentPointIndex()
    {
        return _isReverse
            ? -_targetPointIndex
            : _targetPointIndex;
    }

    private void HandlePathEnd(FollowPathMode followMode)
    {
        switch (followMode)
        {
            case FollowPathMode.Direct:
                HandleDirectPathEnd();
                break;
            case FollowPathMode.PingPong:
                HandlePingPongPathEnd();
                break;
            case FollowPathMode.Loop:
                HandleLoopPathEnd();
                break;
        }
    }

    private WaypointData GetPointData(int index)
    {
        return _pathCreator.GetNextPointData(transform.position,
                                            index,
                                            _followMode);
    }

    private void HandleDirectPathEnd()
    {
        _isFollowing = false;
    }

    private void HandlePingPongPathEnd()
    {
        _endPointIndex = _endPointIndex == 0
            ? _pathCreator.EndPointIndex
            : 0;

        _isReverse = !_isReverse;
    }

    private void HandleLoopPathEnd()
    {
        _isFollowing = true;
    }

    private bool CheckPathEnd()
    {
        return _targetPointIndex == _endPointIndex
            ? _pathCreator.InPosition(transform.position,
                                      _targetPointIndex)
            : false;
    }
}
