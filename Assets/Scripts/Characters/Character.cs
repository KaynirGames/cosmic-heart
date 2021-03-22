using UnityEngine;

public class Character : MonoBehaviour, IDamageable
{
    public delegate void OnCharacterDeath(Character character);

    [SerializeField] protected CharacterStats _stats = null;
    [SerializeField] protected Animator _animator = null;

    public CharacterStats Stats => _stats;
    public Animator Animator => _animator;

    protected virtual void Awake()
    {
        _stats.OnCharacterDeath += Die;
    }

    protected virtual void Die()
    {
        gameObject.Dispose();
    }

    public void TakeDamage(float damage)
    {
        Stats.Health.ChangeValue(-(int)damage);

        if (Stats.Health.GetValue() <= 0)
        {
            Die();
        }
    }
}
