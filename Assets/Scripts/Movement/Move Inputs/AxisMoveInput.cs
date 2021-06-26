using UnityEngine;

public class AxisMoveInput : BaseMoveInput
{
    [SerializeField] private string _horizontalAxis = "Horizontal";
    [SerializeField] private string _verticalAxis = "Vertical";

    public override Vector3 GetInput()
    {
        float horizontal = Input.GetAxis(_horizontalAxis);
        float vertical = Input.GetAxis(_verticalAxis);

        return new Vector3(horizontal, vertical);
    }
}