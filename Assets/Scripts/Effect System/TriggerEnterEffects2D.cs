using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TriggerEnterEffects2D : MonoBehaviour
{
    [SerializeField] private EffectSystem _effectSystem = null;

    private Collider2D _collider2D;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
        _collider2D.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _effectSystem.ActivateEffects(collision.gameObject);
    }
}
