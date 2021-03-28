using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CollisionEnterEffects2D : MonoBehaviour
{
    [SerializeField] private EffectSystem _effectSystem = null;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _effectSystem.ActivateEffects(collision.gameObject);
    }
}
