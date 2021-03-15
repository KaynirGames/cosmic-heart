using UnityEngine;

public class Enemy : Character
{
    public event System.Action<Enemy> OnEnemyDeath = delegate { };

    protected override void Die()
    {
        OnEnemyDeath.Invoke(this);
    }
}