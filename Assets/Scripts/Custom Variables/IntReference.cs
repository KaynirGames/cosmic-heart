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
            OnValueChanged.Invoke(Value);
            return;
        }

        _variable.ApplyChange(amount);
    }

    public void SetValue(int value)
    {
        if (_useConstant)
        {
            _constantValue = value;
            OnValueChanged.Invoke(Value);
            return;
        }

        _variable.SetValue(value);
    }

    public static implicit operator int(IntReference intReference)
    {
        return intReference.Value;
    }
}
