using UnityEngine;

public class Enemy : MonoBehaviour
{
    private CharacterStats _enemyStats;

    private void Awake()
    {
        _enemyStats = GetComponent<CharacterStats>();

        _enemyStats.OnCharacterDeath += DestroyEnemy;
    }

    private void DestroyEnemy()
    {
        gameObject.Dispose();
    }
}