using UnityEngine;

public abstract class BaseEvent : MonoBehaviour
{
    [SerializeField] protected GameObject _owner = null;
    [SerializeField] protected EventMode _eventMode = EventMode.OnTarget;

    public void TryInvoke(GameObject target)
    {
        switch (_eventMode)
        {
            case EventMode.OnTarget:
                Invoke(target);
                break;
            case EventMode.OnOwner:
                Invoke(_owner);
                break;
        }
    }

    protected abstract void Invoke(GameObject target);

    protected enum EventMode
    {
        OnTarget,
        OnOwner
    }
}
