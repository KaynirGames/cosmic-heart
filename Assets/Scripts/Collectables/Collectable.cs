using UnityEngine;
using UnityEngine.Events;

public class Collectable : MonoBehaviour, ICollectable
{
    [SerializeField] protected UnityEvent _onCollect = null;

    public virtual void Collect()
    {
        _onCollect.Invoke();
    }
}