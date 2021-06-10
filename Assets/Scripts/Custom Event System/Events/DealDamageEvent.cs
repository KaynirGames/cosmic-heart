using UnityEngine;

public class DealDamageEvent : BaseEvent
{
    [SerializeField] private float _damage = 1f;

    public override void TryInvoke(GameObject target)
    {
        if (target.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(_damage);
        }
    }
}