using UnityEngine;

public abstract class BaseMovement : MonoBehaviour
{
    [SerializeField] protected BaseMoveHandler _moveHandler = null;

    protected virtual void Update()
    {
        Move();
    }

    protected abstract void Move();
}
