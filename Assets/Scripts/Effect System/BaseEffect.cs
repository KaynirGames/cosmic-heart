using UnityEngine;

public abstract class BaseEffect : MonoBehaviour
{
    [SerializeField] protected GameObject _owner = null;
    [SerializeField] protected EffectMode _effectMode = EffectMode.OnTarget;

    public abstract void Activate(GameObject target);

    protected GameObject GetProperTarget(GameObject target)
    {
        return _effectMode == EffectMode.OnTarget
            ? target
            : _owner;
    }

    protected enum EffectMode
    {
        OnTarget,
        OnOwner
    }
}
