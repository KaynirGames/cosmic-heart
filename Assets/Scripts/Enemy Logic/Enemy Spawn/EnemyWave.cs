using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] private EnemyGroup[] _enemyGroups = null;
    [SerializeField] private UnityEvent _onWaveDefeat = null;

    private List<Enemy> _spawnedEnemies;

    public void Spawn()
    {
        _spawnedEnemies = new List<Enemy>();

        foreach (EnemyGroup group in _enemyGroups)
        {
            group.OnEnemySpawn += RegisterEnemy;
            group.Spawn();
        }
    }

    private void RegisterEnemy(Enemy enemy)
    {
        _spawnedEnemies.Add(enemy);
        enemy.OnEnemyDeath += DisposeEnemy;
    }

    private void DisposeEnemy(Character enemyCharacter)
    {
        Enemy enemy = enemyCharacter as Enemy;

        _spawnedEnemies.Remove(enemy);

        enemy.OnEnemyDeath -= DisposeEnemy;
        enemy.gameObject.Dispose();

        if (_spawnedEnemies.Count == 0)
        {
            Debug.Log("Wave was defeated!");
            _onWaveDefeat?.Invoke();
        }
    }
}
