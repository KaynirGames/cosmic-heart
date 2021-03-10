using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveRigidbody2D : MonoBehaviour, IMoveHandler
{
    [SerializeField] private float _moveSpeed = 1f;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector3 direction)
    {
        _rigidbody2D.velocity = direction * _moveSpeed;
    }

    public void SetMoveSpeed(float moveSpeed)
    {
        _moveSpeed = moveSpeed;
    }
}
