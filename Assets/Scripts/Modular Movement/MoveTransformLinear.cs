using UnityEngine;

public class MoveTransformLinear : MonoBehaviour, IMoveHandler
{
    [SerializeField] private Vector3 _moveDirection = Vector3.zero;
    [SerializeField] private float _moveSpeed = 1f;

    private void Update()
    {
        transform.Translate(_moveDirection.normalized
                            * _moveSpeed
                            * Time.deltaTime);
    }

    public void SetMoveDirection(Vector3 moveDirection)
    {
        _moveDirection = moveDirection;
    }

    public void SetMoveSpeed(float moveSpeed)
    {
        _moveSpeed = moveSpeed;
    }
}
