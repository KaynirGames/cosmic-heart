using UnityEngine;

public class DisposeOwnerEvent : BaseEvent
{
    public override void TryInvoke(GameObject target)
    {
        _eventOwner.Dispose();
    }
}
