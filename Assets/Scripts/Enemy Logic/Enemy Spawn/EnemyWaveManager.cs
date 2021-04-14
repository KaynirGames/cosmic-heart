using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    [SerializeField] private EnemyWave[] _enemyWaves = null;

    public EnemyWave CurrentWave { get; private set; }

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

        CurrentWave = _wavesQueue.Dequeue();
        CurrentWave.Spawn();
    }
}
