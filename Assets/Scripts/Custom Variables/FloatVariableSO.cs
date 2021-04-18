using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Variables/Float Variable")]
public class FloatVariableSO : ScriptableObject, IVariable<float>
{
    public event Action<float> OnValueChanged = delegate { };

    [SerializeField] private float _value = 0f;

    public float Value => _value;

    public void ApplyChange(float amount)
    {
        _value += amount;
        OnValueChanged.Invoke(_value);
    }

    public void SetValue(float value)
    {
        _value = value;
        OnValueChanged.Invoke(value);
    }
}