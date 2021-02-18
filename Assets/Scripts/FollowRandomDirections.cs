using UnityEngine;

public class FollowRandomDirections : MonoBehaviour
{
    [Header("Зона перемещения:")]
    [SerializeField] private Vector3 _minMoveLimit = Vector3.zero;
    [SerializeField] private Vector3 _maxMoveLimit = Vector3.zero;
    [Header("Время перемещения:")]
    [SerializeField] private float _minMovementTime = 1f;
    [SerializeField] private float _maxMovementTime = 2f;

    private IMoveHandler _moveHandler;

    private Timer _movementTimer;
    private Vector3 _randomDirection;

    private void Awake()
    {
        _moveHandler = GetComponent<IMoveHandler>();
    }

    private void Start()
    {
        _movementTimer = new Timer();
    }

    private void Update()
    {
        if (_movementTimer.Elapsed)
        {
            _moveHandler.SetMoveDirection(GetRandomDirection());
            _movementTimer.ChangeDuration(GetRandomDuration());
            _movementTimer.Reset();
            return;
        }

        _movementTimer.Tick(Time.deltaTime);

        CheckForBorders();
    }

    private Vector3 GetRandomDirection()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);

        _randomDirection = new Vector3(randomX, randomY);

        return _randomDirection;
    }

    private float GetRandomDuration()
    {
        return Random.Range(_minMovementTime, _maxMovementTime);
    }

    private void CheckForBorders()
    {
        transform.position = transform.position.ClampPosition2D(_minMoveLimit, _maxMoveLimit);

        if (transform.position.x <= _minMoveLimit.x || transform.position.x >= _maxMoveLimit.x)
        {
            _randomDirection.x *= -1;
        }

        if (transform.position.y <= _minMoveLimit.y || transform.position.y >= _maxMoveLimit.y)
        {
            _randomDirection.y *= -1;
        }

        _moveHandler.SetMoveDirection(_randomDirection);
    }
}
