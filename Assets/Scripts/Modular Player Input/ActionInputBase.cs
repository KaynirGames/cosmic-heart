using UnityEngine;

public abstract class ActionInputBase : MonoBehaviour
{
    public abstract bool GetInputDown();

    public abstract bool GetInputHold();

    public abstract bool GetInputUp();
}
