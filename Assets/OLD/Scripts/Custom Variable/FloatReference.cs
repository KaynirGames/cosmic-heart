using System;
using UnityEngine;

[Serializable]
public class FloatReference : IVariable<float>
{
    public event Action<float> OnValueChanged = delegate { };

    [SerializeField] private float _constantValue = 0f;
    [SerializeField] private FloatVariableSO _variable = null;
    [SerializeField] private bool _useConstant = true;

    public float Value => _useConstant ? _constantValue : _variable.Value;

    public FloatReference() { }

    public FloatReference(float value)
    {
        _constantValue = value;
        _useConstant = true;
    }

    public void ApplyChange(float amount)
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

    public void SetValue(float value)
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