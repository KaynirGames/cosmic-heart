using UnityEngine;

public abstract class BaseMoveHandler : MonoBehaviour
{
    [SerializeField] protected BaseMoveInput _moveInput = null;
    [SerializeField] protected float _moveSpeed = 5f;

    public Vector3 Direction { get; protected set; }
    public Vector3 Velocity { get; protected set; }

    public float MoveSpeed => _moveSpeed;

    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }

    public void SetSpeed(float speed)
    {
        _moveSpeed = speed;
    }

    protected abstract void Move();

    protected virtual void CalculateVelocity()
    {
        Direction = _moveInput.GetInput();
        Velocity = Direction * _moveSpeed * Time.deltaTime;
    }
}