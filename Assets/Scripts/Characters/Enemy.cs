using UnityEngine;

public class Enemy : Character
{
    public event OnCharacterDeath OnEnemyDeath = delegate { };

    [SerializeField] private EffectSystem _deathRattleEffects = null;

    private BaseMoveInput _moveInputOnLoop;

    protected override void Awake()
    {
        base.Awake();

        enabled = false;
    }

    public void Initialize(BaseMoveInput moveInputOnEnter, BaseMoveInput moveInputOnLoop)
    {
        _moveInput = moveInputOnEnter;
        _moveInputOnLoop = moveInputOnLoop;

        enabled = true;
    }

    public void Attack()
    {
        Animator.SetTrigger("Attack");
    }

    public void Move()
    {
        HandleMove(_moveInput.GetDirection());
    }

    public void SetLoopMoveInput()
    {
        _moveInput = _moveInputOnLoop;
    }

    protected override void Die()
    {
        _deathRattleEffects.ActivateEffects(gameObject);
        OnEnemyDeath.Invoke(this);
    }
}