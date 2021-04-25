using UnityEngine;

public class DirectionMovement : BaseMovement
{
    [SerializeField] private Vector3 _direction = Vector3.zero;

    protected override void Move()
    {
        _moveHandler.SetDirection(_direction);
    }
}
