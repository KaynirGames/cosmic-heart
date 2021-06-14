using UnityEngine;

public class MouseMoveInput : BaseMoveInput
{
    [SerializeField, Range(0, 1)] private int _mouseButton = 0;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    public override Vector3 GetInput()
    {
        Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

        return Input.GetMouseButton(_mouseButton)
            ? (mousePosition - transform.position).normalized
            : Vector3.zero;
    }
}