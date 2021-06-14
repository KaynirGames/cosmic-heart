using UnityEngine;

public class GiveHealthEvent : BaseEvent
{
    [SerializeField] private IntReference _health = null;

    public override void TryInvoke(GameObject target)
    {
        if (target.TryGetComponent(out IRecoverable recoverable))
        {
            recoverable.Recover(_health.Value);
        }
    }
}