using UnityEngine;

public abstract class BaseMovement : MonoBehaviour
{
    protected Vector3 _currentVelocity = Vector3.zero;

    public void Move(Vector3 velocity)
    {
        _currentVelocity = velocity;
    }
}
