using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] private EnemyGroup[] _enemyGroups = null;
    [SerializeField] private UnityEvent _onWaveDefeat = null;

    private List<EnemyGroup> _spawnedGroups;

    public void SpawnWave()
    {
        _spawnedGroups = new List<EnemyGroup>();

        foreach (EnemyGroup group in _enemyGroups)
        {
            group.ActivateEnemyGroup();
            RegisterEnemyGroup(group);
        }
    }

    private void RegisterEnemyGroup(EnemyGroup group)
    {
        _spawnedGroups.Add(group);
        group.OnGroupDefeat += DisposeEnemyGroup;
    }

    private void DisposeEnemyGroup(EnemyGroup group)
    {
        _spawnedGroups.Remove(group);
        group.OnGroupDefeat -= DisposeEnemyGroup;

        if (_spawnedGroups.Count == 0)
        {
            Debug.Log("Wave was defeated!");
            _onWaveDefeat?.Invoke();
        }
    }
}
