using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected CharacterStats _stats = null;
    [SerializeField] protected Animator _animator = null;

    public CharacterStats Stats => _stats;
    public Animator Animator => _animator;

    protected ISpeedHandler _speedHandler;

    protected virtual void Awake()
    {
        _speedHandler = GetComponent<ISpeedHandler>();
        _speedHandler.SetSpeed(_stats.MoveSpeed.Value);

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
}
