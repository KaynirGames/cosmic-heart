using UnityEngine;

public abstract class BaseMoveHandler : MonoBehaviour
{
    [SerializeField] protected BaseMoveInput _moveInput = null;
    [SerializeField] protected float _moveSpeed = 5f;

    public Vector3 Direction { get; private set; }

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

    protected virtual Vector3 GetVelocity()
    {
        Direction = _moveInput.GetInput();

        return Direction * _moveSpeed * Time.deltaTime;
    }
}