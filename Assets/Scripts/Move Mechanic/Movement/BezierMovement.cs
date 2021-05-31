using BezierSolution;
using UnityEngine;

public class BezierMovement : BaseMovement
{
    [SerializeField] private BezierSpline _spline = null;
    [SerializeField] private TravelMode _travelMode = TravelMode.Once;

    [Range(0f, 1f)]
    private float _normalizedTime = 0f;
    private bool _isForward = true;
    private bool _isFolowing = true;

    protected override void Move()
    {
        float speed = _isForward
            ? _moveHandler.GetSpeed()
            : -_moveHandler.GetSpeed();

        Vector3 targetPos = _spline.MoveAlongSpline(ref _normalizedTime,
                                                    speed * Time.deltaTime);

        _moveHandler.SetDirection(_isFolowing
            ? (targetPos - transform.position).normalized
            : Vector3.zero);

        if (_isForward)
        {
            ValidateForwardTime();
            return;
        }

        ValidateBackwardTime();
    }

    private void ValidateForwardTime()
    {
        if (_normalizedTime >= 1f)
        {
            switch (_travelMode)
            {
                case TravelMode.Once:
                    _normalizedTime = 1f;
                    _isFolowing = false;
                    break;
                case TravelMode.Loop:
                    _normalizedTime -= 1f;
                    break;
                case TravelMode.PingPong:
                    _normalizedTime = 2f - _normalizedTime;
                    _isForward = !_isForward;
                    break;
            }
        }
    }

    private void ValidateBackwardTime()
    {
        if (_normalizedTime <= 0f)
        {
            switch (_travelMode)
            {
                case TravelMode.Once:
                    _normalizedTime = 0f;
                    _isFolowing = false;
                    break;
                case TravelMode.Loop:
                    _normalizedTime += 1f;
                    break;
                case TravelMode.PingPong:
                    _normalizedTime *= -1;
                    _isForward = !_isForward;
                    break;
            }
        }
    }
}