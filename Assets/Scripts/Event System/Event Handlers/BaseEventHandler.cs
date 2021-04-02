using UnityEngine;

public class BaseEventHandler : MonoBehaviour
{
    [SerializeField] protected BaseEvent[] _events = null;

    public virtual void InvokeEvents(GameObject target)
    {
        foreach (BaseEvent baseEvent in _events)
        {
            baseEvent.TryInvoke(target);
        }
    }
}
