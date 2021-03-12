using UnityEngine;

public class SpecialEffectMaster : MonoBehaviour
{
    private ISpecialEffect[] _specialEffects;

    private void Awake()
    {
        _specialEffects = GetComponentsInChildren<ISpecialEffect>();
    }

    public void CreateEffects(GameObject target)
    {
        foreach (ISpecialEffect effect in _specialEffects)
        {
            effect.Play(target);
        }
    }
}
