using UnityEngine;

public class VariableReference<T, V> : VariableReferenceWrapper where V : VariableSO<T>
{
    public System.Action<T> OnValueChanged;

    [SerializeField] private bool _useConstant = true;
    [SerializeField] private T _constantValue = default;
    [SerializeField] private V _variable = default;

    public T Value => _useConstant ? _constantValue : _variable.Value;

    public VariableReference() { }

    public VariableReference(T value)
    {
        _constantValue = value;
        _useConstant = true;
    }

    public VariableReference(V variable)
    {
        _variable = variable;
        _useConstant = false;
    }

    public void SetValue(T value)
    {
        if (_useConstant)
        {
            _constantValue = value;
        }
        else
        {
            _variable.SetValue(value);
        }

        OnValueChanged?.Invoke(value);
    }
}