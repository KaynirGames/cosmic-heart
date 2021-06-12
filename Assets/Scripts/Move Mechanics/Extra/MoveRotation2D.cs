using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveRotation2D : MonoBehaviour
{
    [SerializeField] private BaseMoveHandler _moveHandler = null;
    [SerializeField, Range(0f, 360f)] private float _rotationControl = 180f;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    private void Rotate()
    {
        float cross = Vector3.Cross(_moveHandler.GetDirection(),
                                    transform.up).z;

        float rotation = cross * _rotationControl * Time.deltaTime;

        _rigidbody2D.AddTorque(rotation);

        //_rigidbody2D.angularVelocity = -cross * _rotationControl * Time.deltaTime;
    }
}