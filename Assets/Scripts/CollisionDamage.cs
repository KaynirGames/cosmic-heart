using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CollisionDamage : MonoBehaviour
{
    [SerializeField] private float _damage = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(_damage);
        }
    }
}
