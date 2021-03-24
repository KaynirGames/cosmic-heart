using UnityEngine;

public class RandomMoveInput : BaseMoveInput
{
    [SerializeField] private float _nextDirectionTime = 1f;
    [Space]
    [SerializeField, Range(-1f, 1f)] private float _minX = -1f;
    [SerializeField, Range(-1f, 1f)] private float _maxX = 1f;
    [Space]
    [SerializeField, Range(-1f, 1f)] private float _minY = -1f;
    [SerializeField, Range(-1f, 1f)] private float _maxY = 1f;

    private Timer _nextDirectionTimer;
    private Vector3 _randomDirection;

    private void Start()
    {
        _nextDirectionTimer = new Timer(_nextDirectionTime);
        _randomDirection = CalculateDirection();
        _nextDirectionTimer.Reset();
    }

    private void Update()
    {
        if (_nextDirectionTimer.Elapsed)
        {
            _randomDirection = CalculateDirection();
            _nextDirectionTimer.Reset();
        }

        _nextDirectionTimer.Tick();
    }

    public override Vector3 GetDirection()
    {
        return _randomDirection;
    }

    private Vector3 CalculateDirection()
    {
        float randomX = Random.Range(_minX, _maxX);
        float randomY = Random.Range(_minY, _maxY);

        return new Vector3(randomX, randomY);
    }
}
