using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RotatingObject : MonoBehaviour
{
    [SerializeField, Range(0f, 360f)] private float _rotationAngle = 45f;
    [SerializeField] private float _rotationSpeed = 100f;
    [SerializeField] private bool _randomizeRotation = false;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        SetRotation();
    }

    private void SetRotation()
    {
        float angle = _randomizeRotation
            ? _rotationAngle * Random.value
            : _rotationAngle;

        float speed = _randomizeRotation
            ? _rotationSpeed * Random.value
            : _rotationSpeed;

        _rigidbody2D.angularVelocity = GetAngularVelocity(angle, speed);
    }

    private float GetAngularVelocity(float angle, float speed)
    {
        return angle * speed * Mathf.Deg2Rad;
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (_rigidbody2D != null)
        {
            SetRotation();
        }
    }
#endif
}
