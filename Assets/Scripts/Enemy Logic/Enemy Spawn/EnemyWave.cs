using UnityEngine;
using UnityEngine.Events;

public class EnemyWave : MonoBehaviour
{
    [SerializeField] private EnemyGroup[] _enemyGroups = null;
    [SerializeField] private UnityEvent _onWaveDefeat = null;
    [SerializeField] private GameObjectRuntimeListSO _enemyRuntimeList = null;

    public void Spawn()
    {
        _enemyRuntimeList.OnLastObjectRemoved += StopWave;

        foreach (EnemyGroup group in _enemyGroups)
        {
            group.Spawn();
        }
    }

    private void StopWave()
    {
        _enemyRuntimeList.OnLastObjectRemoved -= StopWave;
        _onWaveDefeat?.Invoke();
        Debug.Log("Wave was defeated!");
    }
}
