using UnityEngine;

public abstract class BaseMoveHandler : MonoBehaviour, IDirectionHandler, ISpeedHandler
{
    [SerializeField] protected float _moveSpeed = 5f;

    protected Vector3 _direction;

    public Vector3 GetDirection()
    {
        return _direction;
    }

    public float GetSpeed()
    {
        return _moveSpeed;
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    public void SetSpeed(float speed)
    {
        _moveSpeed = speed;
    }

    protected Vector3 GetVelocity()
    {
        return GetVelocity(Time.deltaTime);
    }

    protected Vector3 GetVelocity(float deltaTime)
    {
        return _direction * _moveSpeed * deltaTime;
    }
}