using UnityEngine;

public abstract class IntVariableBaseDisplay : MonoBehaviour
{
    [SerializeField] protected IntVariableSO _intVariable = null;

    protected virtual void Awake()
    {
        _intVariable.OnValueChanged += UpdateDisplayValue;
    }

    protected abstract void UpdateDisplayValue(int value);

    protected virtual void OnDisable()
    {
        _intVariable.OnValueChanged -= UpdateDisplayValue;
    }
}
