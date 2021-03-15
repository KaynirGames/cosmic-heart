using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    public event System.Action<EnemyGroup> OnGroupDefeat = delegate { };

    [SerializeField] private Enemy _enemyPrefab = null;
    [SerializeField] private Transform _spawnPoint = null;
    [SerializeField] private int _enemyAmount = 1;
    [SerializeField] private float _enemySpawnDelay = .5f;

    private Timer _spawnTimer;
    private List<Enemy> _spawnedEnemies;
    private bool _canSpawn;

    private void Awake()
    {
        _spawnedEnemies = new List<Enemy>();
    }

    private void Start()
    {
        _spawnTimer = new Timer(_enemySpawnDelay);
    }

    private void Update()
    {
        if (_canSpawn)
        {
            SpawnEnemy();
        }

        _spawnTimer.Tick();
    }

    public void SpawnGroup()
    {
        _canSpawn = true;
    }

    private void SpawnEnemy()
    {
        if (_spawnTimer.Elapsed)
        {
            Enemy enemy = Instantiate(_enemyPrefab,
                                      _spawnPoint.transform.position,
                                      Quaternion.identity,
                                      transform);

            RegisterEnemy(enemy);
            _spawnTimer.Reset();
        }

        if (_spawnedEnemies.Count == _enemyAmount)
        {
            _canSpawn = false;
        }
    }

    private void RegisterEnemy(Enemy enemy)
    {
        _spawnedEnemies.Add(enemy);

        enemy.OnEnemyDeath += DisposeEnemy;
    }

    private void DisposeEnemy(Enemy enemy)
    {
        _spawnedEnemies.Remove(enemy);

        enemy.OnEnemyDeath -= DisposeEnemy;
        enemy.gameObject.Dispose();

        if (_spawnedEnemies.Count == 0)
        {
            OnGroupDefeat.Invoke(this);
        }
    }
}
