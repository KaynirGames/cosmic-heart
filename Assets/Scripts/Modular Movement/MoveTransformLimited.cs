using UnityEngine;

public class MoveTransformLimited : MonoBehaviour, IMoveHandler
{
    [SerializeField] private float _moveSpeed = 1f;
    [Header("Ограничение перемещения:")]
    [SerializeField] private Vector3 _minMoveLimit = Vector3.zero;
    [SerializeField] private Vector3 _maxMoveLimit = Vector3.zero;

    private Vector3 _currentDirection = Vector3.zero;

    private void Update()
    {
        transform.Translate(_currentDirection.normalized
                            * _moveSpeed
                            * Time.deltaTime);

        if (_currentDirection != Vector3.zero)
        {
            float limitedX = Mathf.Clamp(transform.position.x,
                                         _minMoveLimit.x,
                                         _maxMoveLimit.x);

            float limitedY = Mathf.Clamp(transform.position.y,
                                         _minMoveLimit.y,
                                         _maxMoveLimit.y);

            transform.position = new Vector3(limitedX, limitedY);
        }
    }

    public void SetMoveDirection(Vector3 moveDirection)
    {
        _currentDirection = moveDirection;
    }

    public void SetMoveSpeed(float moveSpeed)
    {
        _moveSpeed = moveSpeed;
    }
}
