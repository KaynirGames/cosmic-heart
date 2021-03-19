using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    public event System.Action<EnemyGroup> OnGroupDefeat = delegate { };

    [Header("Настройки спавна:")]
    [SerializeField] private Enemy _enemyPrefab = null;
    [SerializeField] private Transform _spawnPoint = null;
    [SerializeField] private int _enemyAmount = 1;
    [SerializeField] private float _enemySpawnDelay = .5f;
    [Header("Настройки атаки:")]
    [SerializeField] private float _enemyAttackDelay = .5f;
    [SerializeField] private BaseGroupAttack _attackPattern = null;

    private Timer _spawnTimer;
    private List<Enemy> _spawnedEnemies;
    private bool _canSpawn;

    private Timer _attackTimer;

    private void Awake()
    {
        _spawnedEnemies = new List<Enemy>();
    }

    private void Start()
    {
        _spawnTimer = new Timer(_enemySpawnDelay);
        _attackTimer = new Timer(_enemyAttackDelay);
    }

    private void Update()
    {
        if (HandleGroupSpawn())
        {
            return;
        }

        HandleGroupAttack();
    }

    public void ActivateEnemyGroup()
    {
        _canSpawn = true;
        _attackTimer.Reset();
    }

    private bool HandleGroupSpawn()
    {
        if (_canSpawn)
        {
            SpawnEnemy();
            _spawnTimer.Tick();
            return true;
        }

        return false;
    }

    private void HandleGroupAttack()
    {
        if (_attackTimer.Elapsed)
        {
            _attackPattern.Execute(_spawnedEnemies);
            _attackTimer.Reset();
        }

        _attackTimer.Tick();
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
