using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour, IDamageable
{
    public event System.Action OnCharacterDeath = delegate { };
 
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private int _health = 1;

    public float MoveSpeed => _moveSpeed;

    public void TakeDamage(float damage)
    {
        _health -= (int)damage;

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // bla bla
        OnCharacterDeath.Invoke();
    }
}
