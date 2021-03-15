using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    [SerializeField] private EnemyWave[] _enemyWaves = null;

    private Queue<EnemyWave> _wavesQueue;

    private void Awake()
    {
        _wavesQueue = new Queue<EnemyWave>(_enemyWaves);
    }

    public void TrySpawnNext()
    {
        if (_wavesQueue.Count == 0)
        {
            //Complete Level
            Debug.Log("Level completed!");
            return;
        }

        EnemyWave wave = _wavesQueue.Dequeue();
        wave.SpawnWave();
    }
}
