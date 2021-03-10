using UnityEngine;

public class MoveTransform : MonoBehaviour, IMoveHandler
{
    [SerializeField] private float _moveSpeed = 1f;

    private Vector3 _moveDirection = Vector3.zero;

    private void Update()
    {
        transform.Translate(_moveDirection
                            * _moveSpeed
                            * Time.deltaTime);
    }

    public void Move(Vector3 moveDirection)
    {
        _moveDirection = moveDirection;
    }

    public void SetMoveSpeed(float moveSpeed)
    {
        _moveSpeed = moveSpeed;
    }
}
