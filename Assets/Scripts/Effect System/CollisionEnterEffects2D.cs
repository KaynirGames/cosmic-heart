using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(EffectSystem))]
public class CollisionEnterEffects2D : MonoBehaviour
{
    private EffectSystem _effectSystem;

    private void Awake()
    {
        _effectSystem = GetComponent<EffectSystem>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _effectSystem.ActivateEffects(collision.gameObject);
    }
}
