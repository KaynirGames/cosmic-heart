using UnityEngine;

public class ActionInputKeyboard : ActionInputBase
{
    [SerializeField] private KeyCode _actionKey = KeyCode.None;

    public override bool GetInputDown()
    {
        return Input.GetKeyDown(_actionKey);
    }

    public override bool GetInputHold()
    {
        return Input.GetKey(_actionKey);
    }

    public override bool GetInputUp()
    {
        return Input.GetKeyUp(_actionKey);
    }
}
