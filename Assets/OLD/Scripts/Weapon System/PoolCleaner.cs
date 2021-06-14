using UnityEngine;

public class PoolCleaner : MonoBehaviour
{
    [SerializeField] private GameObjectQueueSO[] _pools = null;

    private void OnDisable()
    {
        foreach (var pool in _pools)
        {
            pool.GetQueue().Clear();
        }
    }
}
