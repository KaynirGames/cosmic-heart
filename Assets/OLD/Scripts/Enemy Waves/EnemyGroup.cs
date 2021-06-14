using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [Header("Настройки спавна врагов:")]
    [SerializeField] private GameObject _enemyPrefab = null;
    [SerializeField] private BaseSpawnArea _spawnArea = null;
    [SerializeField] private int _enemyAmount = 1;
    [SerializeField] private float _enemySpawnDelay = .5f;

    private Timer _spawnTimer;
    private int _spawnCount;
    private bool _canSpawn;

    private void Start()
    {
        _spawnTimer = new Timer(_enemySpawnDelay);
    }

    private void Update()
    {
        if (_canSpawn)
        {
            SpawnEnemy();
            _spawnTimer.Tick();
        }
    }

    public void Spawn()
    {
        _canSpawn = true;
        _spawnCount = 0;
    }

    private void SpawnEnemy()
    {
        if (_spawnTimer.Elapsed)
        {
            GameObject enemy = Instantiate(_enemyPrefab,
                                           _spawnArea.GetSpawnPosition(),
                                           Quaternion.identity);

            enemy.SetActive(true);

            _spawnTimer.Reset();
            _spawnCount++;
        }

        if (_spawnCount == _enemyAmount)
        {
            _canSpawn = false;
        }
    }
}
