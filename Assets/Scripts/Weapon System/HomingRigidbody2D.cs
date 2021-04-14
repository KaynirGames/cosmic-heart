using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingRigidbody2D : MonoBehaviour
{
    [SerializeField] private BaseTargetLocator _targetLocator = null;
    [SerializeField] private BaseMoveHandler _moveHandler = null;
    [SerializeField, Range(0f, 360f)] private float _rotationControl = 180f;

    private Rigidbody2D _rigidbody;
    private GameObject _target;

    private bool _isFollowing;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!_isFollowing)
        {
            SearchForTarget();
        }
    }

    private void FixedUpdate()
    {
        FollowTarget();
    }

    private void SearchForTarget()
    {
        _target = _targetLocator.LocateTarget();
    }

    private void FollowTarget()
    {
        if (_target == null)
        {
            _rigidbody.angularVelocity = 0f;
            _isFollowing = false;
            return;
        }

        Vector2 direction = transform.position - _target.transform.position;
        float cross = Vector3.Cross(direction.normalized, transform.right).z;

        _rigidbody.angularVelocity = cross * _rotationControl;
        _moveHandler.SetDirection(transform.right);
        _isFollowing = true;
    }
}
