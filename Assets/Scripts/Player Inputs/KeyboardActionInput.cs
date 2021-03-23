using UnityEngine;

public class KeyboardActionInput : BaseActionInput
{
    [SerializeField] private KeyCode _keyCode = KeyCode.Space;

    public override bool GetInputDown()
    {
        return Input.GetKeyDown(_keyCode);
    }

    public override bool GetInputHold()
    {
        return Input.GetKey(_keyCode);
    }

    public override bool GetInputUp()
    {
        return Input.GetKeyUp(_keyCode);
    }
}
