using UnityEngine;

public abstract class BaseActionInput : MonoBehaviour
{
    public abstract bool GetInputDown();

    public abstract bool GetInputHold();

    public abstract bool GetInputUp();
}
