using UnityEngine;

public class Enemy : Character
{
    public event OnCharacterDeath OnEnemyDeath = delegate { };

    [SerializeField] private EffectSystem _deathRattleEffects = null;

    private Vector3 _moveDirection;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        _baseMove.SetVelocity(_moveDirection * Stats.MoveSpeed.GetValue() * Time.deltaTime);
    }

    public void Attack()
    {
        Animator.SetTrigger("Attack");
    }

    public void SetMoveDirection(Vector3 direction)
    {
        _moveDirection = direction;
    }

    protected override void Die()
    {
        _deathRattleEffects.ActivateEffects(gameObject);
        OnEnemyDeath.Invoke(this);
    }
}