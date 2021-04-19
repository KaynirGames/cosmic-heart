using UnityEngine;

public class RuntimeListGameObject : MonoBehaviour
{
    [SerializeField] private GameObjectRuntimeListSO _runtimeListSO = null;

    private void OnEnable()
    {
        _runtimeListSO.Add(gameObject);
    }

    private void OnDisable()
    {
        _runtimeListSO.Remove(gameObject);
    }
}