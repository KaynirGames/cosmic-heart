using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected CharacterStats _stats = null;
    [SerializeField] protected Animator _animator = null;
    [SerializeField] protected BaseMoveHandler _moveHandler = null;
    [SerializeField] protected BaseMoveInput _moveInput = null;

    public CharacterStats Stats => _stats;
    public Animator Animator => _animator;
    public BaseMoveHandler MoveHandler => _moveHandler;
    public BaseMoveInput MoveInput => _moveInput;

    protected virtual void Awake()
    {
        _moveHandler.SetSpeed(_stats.MoveSpeed.Value);
        _stats.Health.OnValueChanged += CheckHealth;
    }

    protected void CheckHealth(int health)
    {
        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        _stats.Health.OnValueChanged -= CheckHealth;
        gameObject.Dispose();
    }

    protected virtual void HandleMove(Vector3 direction)
    {
        _moveHandler.SetDirection(direction);
    }
}
