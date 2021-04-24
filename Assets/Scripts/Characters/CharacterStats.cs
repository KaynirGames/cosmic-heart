using UnityEngine;

public class CharacterStats : MonoBehaviour, IDamageable, IRecoverable
{
    [SerializeField] private IntReference _health = null;
    [SerializeField] private IntReference _maxHealth = null;
    [SerializeField] private FloatReference _moveSpeed = null;

    public IntReference Health => _health;
    public FloatReference MoveSpeed => _moveSpeed;

    private void Start()
    {
        _health.SetValue(_maxHealth.Value);
    }

    public void TakeDamage(float damage)
    {
        ChangeHealth(-(int)damage);
    }

    public void Recover(float recovery)
    {
        ChangeHealth((int)recovery);
    }

    protected void ChangeHealth(int healthChange)
    {
        int changedHealth = _health.Value + healthChange;

        _health.SetValue(Mathf.Clamp(changedHealth,
                                     0,
                                     _maxHealth.Value));
    }
}