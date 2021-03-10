using UnityEngine;

public class FollowRandomDirections : MonoBehaviour
{
    [Header("Границы перемещения:")]
    [SerializeField] private Vector3 _minMoveBound = Vector3.zero;
    [SerializeField] private Vector3 _maxMoveBound = Vector3.zero;
    [Header("Время перемещения:")]
    [SerializeField] private float _minMoveTime = 1f;
    [SerializeField] private float _maxMoveTime = 2f;

    private IMoveHandler _moveHandler;

    private Timer _moveTimer;
    private Vector3 _randomDirection;

    private void Awake()
    {
        _moveHandler = GetComponent<IMoveHandler>();
    }

    private void Start()
    {
        _moveTimer = new Timer(GetRandomDuration());
    }

    private void Update()
    {
        if (_moveTimer.Elapsed)
        {
            _moveHandler.Move(GetRandomDirection());
            _moveTimer.ChangeDuration(GetRandomDuration());
            _moveTimer.Reset();
            return;
        }

        _moveTimer.Tick();

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
        return Random.Range(_minMoveTime, _maxMoveTime);
    }

    private void CheckForBorders()
    {
        if (transform.position.x <= _minMoveBound.x || transform.position.x >= _maxMoveBound.x)
        {
            _randomDirection.x *= -1;
        }

        if (transform.position.y <= _minMoveBound.y || transform.position.y >= _maxMoveBound.y)
        {
            _randomDirection.y *= -1;
        }

        _moveHandler.Move(_randomDirection);
    }
}
