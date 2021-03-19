using UnityEngine;

public class EffectSystem : MonoBehaviour
{
    [SerializeField] private BaseEffect[] _effects = null;

    public void ActivateEffects(GameObject target)
    {
        foreach (BaseEffect effect in _effects)
        {
            effect.Activate(target);
        }
    }
}
