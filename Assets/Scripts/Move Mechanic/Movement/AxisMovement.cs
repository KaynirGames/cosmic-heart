using UnityEngine;

public class AxisMovement : BaseMovement
{
    [SerializeField] private string _horizontalAxis = "Horizontal";
    [SerializeField] private string _verticalAxis = "Vertical";
    [SerializeField] private bool _horizontalSnap = false;
    [SerializeField] private bool _verticalSnap = false;

    protected override void Move()
    {
        float horizontal = GetAxisValue(_horizontalAxis, _horizontalSnap);
        float vertical = GetAxisValue(_verticalAxis, _verticalSnap);

        _moveHandler.SetDirection(new Vector3(horizontal, vertical));
    }

    private float GetAxisValue(string axisName, bool snapOption)
    {
        return snapOption
            ? Input.GetAxisRaw(axisName)
            : Input.GetAxis(axisName);
    }
}
