using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RigidbodyMovement2D : BaseMovement
{
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(transform.position
                                  + _currentVelocity);
    }
}
