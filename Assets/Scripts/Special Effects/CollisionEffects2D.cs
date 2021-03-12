using UnityEngine;

[RequireComponent(typeof(SpecialEffectMaster))]
public class CollisionEffects2D : MonoBehaviour
{
    private SpecialEffectMaster _effectMaster;

    private void Awake()
    {
        _effectMaster = GetComponent<SpecialEffectMaster>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _effectMaster.CreateEffects(collision.gameObject);
    }
}