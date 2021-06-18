using UnityEngine;

public class VariableSO<T> : ScriptableObject
{
    public event System.Action<T> OnValueChanged;

    [SerializeField] private T _value = default;

    public T Value => _value;

    public void SetValue(T value)
    {
        _value = value;
        OnValueChanged?.Invoke(value);
    }
}