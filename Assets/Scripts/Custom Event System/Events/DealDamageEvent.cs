using UnityEngine;

public class DealDamageEvent : BaseEvent
{
    [SerializeField] private float _damage = 1f;

    protected override void Invoke(GameObject target)
    {
        if (target.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(_damage);
        }
    }
}
