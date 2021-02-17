using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ImpactDamage : MonoBehaviour, IDamaging
{
    [SerializeField] private float _damage = 1f;

    public float Damage { get => _damage; set => _damage = value; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(_damage);
        }
    }
}
