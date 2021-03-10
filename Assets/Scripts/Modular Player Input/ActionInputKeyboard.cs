using UnityEngine;

public class ActionInputKeyboard : MonoBehaviour, IActionInputHandler
{
    [SerializeField] private KeyCode _actionKey = KeyCode.None;

    public bool GetInputDown()
    {
        return Input.GetKeyDown(_actionKey);
    }

    public bool GetInputHold()
    {
        return Input.GetKey(_actionKey);
    }

    public bool GetInputUp()
    {
        return Input.GetKeyUp(_actionKey);
    }
}
