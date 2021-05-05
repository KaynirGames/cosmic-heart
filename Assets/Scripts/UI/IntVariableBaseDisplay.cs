using UnityEngine;

public abstract class IntVariableBaseDisplay : MonoBehaviour
{
    [SerializeField] protected IntVariableSO _intVariable = null;

    protected virtual void Awake()
    {
        _intVariable.OnValueChanged += UpdateDisplayValue;
    }

    public void UpdateVariableValue(int value)
    {
        _intVariable.SetValue(value);
    }

    public void UpdateVariableValue(IntVariableSO intVariable)
    {
        UpdateVariableValue(intVariable.Value);
    }

    protected abstract void UpdateDisplayValue(int value);

    protected virtual void OnDisable()
    {
        _intVariable.OnValueChanged -= UpdateDisplayValue;
    }
}
