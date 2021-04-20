using UnityEngine;

public class CharacterStats : MonoBehaviour, IDamageable
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
        int damagedHealth = _health.Value - (int)damage;

        _health.SetValue(Mathf.Clamp(damagedHealth, 0, _maxHealth.Value));
    }
}