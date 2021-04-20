using UnityEngine;

public class SingleAttackModeHandler : BaseAttackModeHandler
{
    public override event OnAttackModeExecution OnExecution = delegate { };

    public override void Execute()
    {
        OnExecution.Invoke();
    }
}
