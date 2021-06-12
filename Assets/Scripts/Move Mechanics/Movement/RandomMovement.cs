using UnityEngine;

public class RandomMovement : BaseMovement
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
    }

    protected override void Update()
    {
        if (_nextDirectionTimer.Elapsed)
        {
            _randomDirection = CalculateDirection();
            _nextDirectionTimer.Reset();
        }

        _nextDirectionTimer.Tick();

        base.Update();
    }

    private Vector3 CalculateDirection()
    {
        float randomX = Random.Range(_minX, _maxX);
        float randomY = Random.Range(_minY, _maxY);

        return new Vector3(randomX, randomY);
    }

    protected override void Move()
    {
        _moveHandler.SetDirection(_randomDirection);
    }
}
