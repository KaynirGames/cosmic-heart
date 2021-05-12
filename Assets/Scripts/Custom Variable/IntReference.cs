using System;
using UnityEngine;

[Serializable]
public class IntReference : IVariable<int>
{
    public event Action<int> OnValueChanged = delegate { };

    [SerializeField] private int _constantValue = 0;
    [SerializeField] private IntVariableSO _variable = null;
    [SerializeField] private bool _useConstant = true;

    public int Value => _useConstant ? _constantValue : _variable.Value;

    public IntReference() { }

    public IntReference(int value)
    {
        _constantValue = value;
        _useConstant = true;
    }

    public void ApplyChange(int amount)
    {
        if (_useConstant)
        {
            _constantValue += amount;
        }
        else
        {
            _variable.ApplyChange(amount);
        }

        OnValueChanged.Invoke(Value);
    }

    public void SetValue(int value)
    {
        if (_useConstant)
        {
            _constantValue = value;
        }
        else
        {
            _variable.SetValue(value);
        }

        OnValueChanged.Invoke(Value);
    }
}