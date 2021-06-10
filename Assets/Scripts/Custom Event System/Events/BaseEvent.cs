using UnityEngine;

public abstract class BaseEvent : MonoBehaviour
{
    [SerializeField] protected GameObject _eventOwner = null;

    public abstract void TryInvoke(GameObject target);
}
