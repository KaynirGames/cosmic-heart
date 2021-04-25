using UnityEngine;

public class PathMovement : BaseMovement
{
    [SerializeField] private PathCreator _pathCreator = null;
    [SerializeField] private PathMode _pathMode = PathMode.Direct;

    private int _endPointIndex;
    private int _targetPointIndex;
    private Vector3 _targetPointPosition;

    private bool _isFollowing;
    private bool _isReverse;

    private Vector3[] _pathPoints;

    private void Start()
    {
        _pathPoints = _pathCreator.GetPoints();

        _targetPointIndex = 0;
        _endPointIndex = _pathPoints.Length - 1;

        _targetPointPosition = _pathPoints[0];

        _isFollowing = true;
        _isReverse = false;
    }

    protected override void Update()
    {
        if (_isFollowing)
        {
            FollowNextPoint();
        }

        Move();
    }

    protected override void Move()
    {
        Vector3 direction = _isFollowing
            ? (_targetPointPosition - transform.position).normalized
            : Vector3.zero;

        _moveHandler.SetDirection(direction);
    }

    private void FollowNextPoint()
    {
        if (IsPointReached())
        {
            _targetPointIndex = GetNextPointIndex(_pathMode);
            _targetPointPosition = _pathPoints[_targetPointIndex];
        }
    }

    private bool IsPointReached()
    {
        return _pathCreator.InPosition(transform.position,
                                       _targetPointPosition);
    }

    private int GetNextPointIndex(PathMode pathMode)
    {
        switch (pathMode)
        {
            default:
                return GetDirectPathIndex();
            case PathMode.PingPong:
                return GetPingPongPathIndex();
            case PathMode.Loop:
                return GetLoopPathIndex();
        }
    }

    private int GetDirectPathIndex()
    {
        if (_targetPointIndex == _endPointIndex)
        {
            _isFollowing = false;
            return _endPointIndex;
        }

        return ++_targetPointIndex;
    }

    private int GetPingPongPathIndex()
    {
        if (_targetPointIndex == _endPointIndex)
        {
            _endPointIndex = _endPointIndex == 0
                ? _pathPoints.Length - 1
                : 0;

            _isReverse = !_isReverse;
        }

        return _isReverse
            ? --_targetPointIndex
            : ++_targetPointIndex;
    }

    private int GetLoopPathIndex()
    {
        if (_targetPointIndex == _endPointIndex)
        {
            _targetPointIndex = 0;
            return 0;
        }

        return ++_targetPointIndex;
    }

    private enum PathMode
    {
        Direct,
        PingPong,
        Loop
    }
}