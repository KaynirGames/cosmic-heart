using UnityEngine;

public class MouseMovement : BaseMovement
{
    [SerializeField, Range(0, 1)] private int _mouseButton = 0;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    protected override void Move()
    {
        Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = Input.GetMouseButton(_mouseButton)
            ? (mousePosition - transform.position).normalized
            : Vector3.zero;

        _moveHandler.SetDirection(direction);
    }
}