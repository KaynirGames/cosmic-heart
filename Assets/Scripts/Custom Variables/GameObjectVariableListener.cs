using UnityEngine;

public class GameObjectVariableListener : MonoBehaviour
{
    [SerializeField] private GameObjectVariableSO _variable = null;

    private void OnEnable()
    {
        _variable.SetValue(gameObject);
    }

    private void OnDisable()
    {
        _variable.SetValue(null);
    }
}