using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingRigidbody2D : MonoBehaviour
{
    [SerializeField] private BaseTargetLocator _targetLocator = null;
    [SerializeField] private BaseMoveHandler _moveHandler = null;
    [SerializeField, Range(0f, 360f)] private float _rotationControl = 180f;

    private Rigidbody2D _rigidbody;
    private GameObject _target;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _target = _targetLocator.LocateTarget();
    }

    private void FixedUpdate()
    {
        if (_target == null) { return; }

        Vector2 direction = transform.position - _target.transform.position;

        float cross = Vector3.Cross(direction.normalized, transform.right).z;

        _rigidbody.angularVelocity = cross * _rotationControl;

        _moveHandler.SetDirection(transform.right);
    }
}
