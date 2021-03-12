using UnityEngine;

public class DamageEffect : MonoBehaviour, ISpecialEffect
{
    [SerializeField] private float _damage = 1f;

    public void Play(GameObject target)
    {
        if (target.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(_damage);
        }
    }
}
