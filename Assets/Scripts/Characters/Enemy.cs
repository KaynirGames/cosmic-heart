using UnityEngine;

public class Enemy : Character
{
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

        base.Die();
    }
}