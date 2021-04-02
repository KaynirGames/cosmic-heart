using UnityEngine;

public class DisposeObjectEvent : BaseEvent
{
    protected override void Invoke(GameObject target)
    {
        target.Dispose();
    }
}
