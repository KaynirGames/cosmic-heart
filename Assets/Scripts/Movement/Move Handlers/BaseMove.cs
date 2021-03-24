using UnityEngine;

public abstract class BaseMove : MonoBehaviour, IVelocityHandler
{
    protected Vector3 _currentVelocity = Vector3.zero;

    public virtual void SetVelocity(Vector3 velocity)
    {
        _currentVelocity = velocity;
    }
}
