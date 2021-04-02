using UnityEngine;

public class Enemy : Character
{
    public event OnCharacterDeath OnEnemyDeath = delegate { };

    [SerializeField] private BaseEventHandler _onDeathEvents = null;

    protected override void Awake()
    {
        base.Awake();

        enabled = false;
    }

    public void Attack()
    {
        Animator.SetTrigger("Attack");
    }

    public void Move()
    {
        HandleMove(_moveInput.GetMoveInput());
    }

    protected override void Die()
    {
        _onDeathEvents.InvokeEvents(gameObject);
        OnEnemyDeath.Invoke(this);
    }
}