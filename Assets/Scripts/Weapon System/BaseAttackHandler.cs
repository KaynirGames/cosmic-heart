using UnityEngine;

public abstract class BaseAttackHandler : MonoBehaviour
{
    public bool IsReady { get; protected set; }

    public abstract void Attack();
}
