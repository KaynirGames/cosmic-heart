using UnityEngine;

public abstract class BaseAttackModeHandler : MonoBehaviour
{
    public delegate void OnAttackModeExecution();
    public abstract event OnAttackModeExecution OnExecution;

    public abstract void Execute();
}
