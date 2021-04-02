using UnityEngine;

public class DirectionMoveInput : BaseMoveInput
{
    [SerializeField] private Vector3 _direction = Vector3.zero;

    public override Vector3 GetMoveInput()
    {
        return _direction;
    }
}
