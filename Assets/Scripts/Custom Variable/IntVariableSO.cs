using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Variables/Int Variable")]
public class IntVariableSO : ScriptableObject, IVariable<int>
{
    public event Action<int> OnValueChanged = delegate { };

    [SerializeField] private int _value = 0;

    public int Value => _value;

    public void ApplyChange(int amount)
    {
        _value += amount;
        OnValueChanged.Invoke(_value);
    }

    public void SetValue(int value)
    {
        _value = value;
        OnValueChanged.Invoke(value);
    }
}
