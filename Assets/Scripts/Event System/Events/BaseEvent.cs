using UnityEngine;

public abstract class BaseEvent : MonoBehaviour
{
    [SerializeField] protected GameObject _owner = null;
    [SerializeField] protected EventMode _eventMode = EventMode.Target;

    public void TryInvoke(GameObject target)
    {
        switch (_eventMode)
        {
            case EventMode.Target:
                Invoke(target);
                break;
            case EventMode.Owner:
                Invoke(_owner);
                break;
            case EventMode.None:
                Invoke(null);
                break;
        }
    }

    protected abstract void Invoke(GameObject target);

    protected enum EventMode
    {
        Target,
        Owner,
        None
    }
}
