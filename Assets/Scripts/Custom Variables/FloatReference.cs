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
            OnValueChanged.Invoke(Value);
            return;
        }

        _variable.ApplyChange(amount);
    }

    public void SetValue(float value)
    {
        if (_useConstant)
        {
            _constantValue = value;
            OnValueChanged.Invoke(Value);
            return;
        }

        _variable.SetValue(value);
    }

    public static implicit operator float(FloatReference floatReference)
    {
        return floatReference.Value;
    }
}
