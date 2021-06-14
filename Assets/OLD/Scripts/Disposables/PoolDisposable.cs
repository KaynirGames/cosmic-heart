using UnityEngine;

public class PoolDisposable : MonoBehaviour, IDisposable
{
    [SerializeField] private GameObjectQueueSO _pool = null;

    public void Dispose(GameObject gameObject)
    {
        _pool.GetQueue().Enqueue(gameObject);
        gameObject.SetActive(false);
    }
}