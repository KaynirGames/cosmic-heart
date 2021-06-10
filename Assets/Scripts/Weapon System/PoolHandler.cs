using System.Collections.Generic;
using UnityEngine;

public class PoolHandler : MonoBehaviour
{
    [SerializeField] private GameObject _prefab = null;
    [SerializeField] private GameObjectQueueSO _pool = null;

    private Queue<GameObject> _poolQueue;

    private void Awake()
    {
        _poolQueue = _pool.GetQueue();
    }

    public GameObject Take()
    {
        GameObject gameObject = _poolQueue.Count > 0
            ? _poolQueue.Dequeue()
            : Instantiate(_prefab);

        gameObject.SetActive(true);

        return gameObject;
    }
}