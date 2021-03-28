using UnityEngine;

public class DamageEffect : BaseEffect
{
    [SerializeField] private float _damage = 1f;

    public override void Activate(GameObject go)
    {
        if (GetProperTarget(go).TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(_damage);
        }
    }
}
