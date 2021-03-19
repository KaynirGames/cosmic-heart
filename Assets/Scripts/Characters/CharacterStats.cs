using UnityEngine;

public class CharacterStats : MonoBehaviour, IDamageable
{
    public event System.Action OnCharacterDeath = delegate { };

    [SerializeField] private IntData _health = null;
    [SerializeField] private FloatData _moveSpeed = null;

    public IntData Health => _health;
    public FloatData MoveSpeed => _moveSpeed;

    public void TakeDamage(float damage)
    {
        _health.ChangeValue(-(int)damage);

        if (_health.GetValue() <= 0)
        {
            OnCharacterDeath.Invoke();
        }
    }
}