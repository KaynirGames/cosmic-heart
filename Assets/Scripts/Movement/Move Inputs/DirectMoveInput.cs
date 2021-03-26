using UnityEngine;

public class DirectMoveInput : BaseMoveInput
{
    [SerializeField] private Vector3 _direction = Vector3.zero;

    public override Vector3 GetDirection()
    {
        return _direction;
    }
}
