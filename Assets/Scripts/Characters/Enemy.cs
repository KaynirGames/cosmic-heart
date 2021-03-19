using UnityEngine;

public class Enemy : Character
{
    public event System.Action<Enemy> OnEnemyDeath = delegate { };

    [SerializeField] private EffectSystem _deathRattleEffects = null;

    protected override void Awake()
    {
        base.Awake();
    }

    public void Attack()
    {
        Animator.SetTrigger("Attack");
    }

    protected override void Die()
    {
        _deathRattleEffects.ActivateEffects(gameObject);
        OnEnemyDeath.Invoke(this);
    }
}