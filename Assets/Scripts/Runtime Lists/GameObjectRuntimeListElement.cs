using UnityEngine;

public class GameObjectRuntimeListElement : MonoBehaviour
{
    [SerializeField] private GameObjectRuntimeListSO _gameObjectRuntimeList = null;

    private void OnEnable()
    {
        _gameObjectRuntimeList.Add(gameObject);
    }

    private void OnDisable()
    {
        _gameObjectRuntimeList.Remove(gameObject);
    }
}