using UnityEngine;

public abstract class BaseMoveHandler : MonoBehaviour, IDirectionHandler, ISpeedHandler
{
    [SerializeField] protected BaseMoveInput _moveInput = null;
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

    protected abstract void Move();

    protected virtual Vector3 GetVelocity()
    {
        _direction = _moveInput.GetInput();

        return _direction * _moveSpeed * Time.deltaTime;
    }
}