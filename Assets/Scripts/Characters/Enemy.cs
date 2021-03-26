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

    private void Update()
    {
        HandleMove(_moveInput.GetDirection());
    }

    public void Initialize(BaseMoveInput moveInputOnEnter)
    {
        _moveInput = moveInputOnEnter;

        enabled = true;
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