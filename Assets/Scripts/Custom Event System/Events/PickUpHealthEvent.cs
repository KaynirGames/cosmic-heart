using UnityEngine;

public class PickUpHealthEvent : BaseEvent
{
    [SerializeField] private IntReference _health = null;

    protected override void Invoke(GameObject target)
    {
        if (target.TryGetComponent(out IRecoverable recoverable))
        {
            recoverable.Recover(_health.Value);
        }
    }
}
