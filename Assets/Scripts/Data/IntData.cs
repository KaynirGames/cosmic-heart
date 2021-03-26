using UnityEngine;

public class IntData : BaseData<int>
{
    public event OnDataValueChanged OnValueChanged = delegate { };

    [SerializeField] private int _minValue = int.MinValue;
    [SerializeField] private int _maxValue = int.MaxValue;

    public override void ChangeValue(int amount)
    {
        _value = ClampValue(_value + amount);
        OnValueChanged.Invoke(_value);
    }

    public override int GetValue()
    {
        return _value;
    }

    public override void SetValue(int value)
    {
        _value = ClampValue(value);
        OnValueChanged.Invoke(_value);
    }

    private int ClampValue(int value)
    {
        return Mathf.Clamp(value, _minValue, _maxValue);
    }
}
