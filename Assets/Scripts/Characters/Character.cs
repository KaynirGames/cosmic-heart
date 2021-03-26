using UnityEngine;

public class Character : MonoBehaviour, IDamageable
{
    public delegate void OnCharacterDeath(Character character);

    [SerializeField] protected CharacterStats _stats = null;
    [SerializeField] protected Animator _animator = null;
    [SerializeField] protected BaseMoveHandler _moveHandler = null;
    [SerializeField] protected BaseMoveInput _moveInput = null;

    public CharacterStats Stats => _stats;
    public Animator Animator => _animator;

    protected virtual void Awake()
    {
        _stats.OnCharacterDeath += Die;
    }

    public void TakeDamage(float damage)
    {
        Stats.Health.ChangeValue(-(int)damage);

        if (Stats.Health.GetValue() <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        gameObject.Dispose();
    }

    protected virtual void HandleMove(Vector3 direction)
    {
        Vector3 velocity = direction
                           * _stats.MoveSpeed.GetValue()
                           * Time.deltaTime;

        _moveHandler.SetVelocity(velocity);
    }
}
