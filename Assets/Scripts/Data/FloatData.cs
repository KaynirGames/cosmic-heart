using UnityEngine;

public class FloatData : BaseData<float>
{
    public event OnDataValueChanged OnValueChanged = delegate { };

    [SerializeField] private float _minValue = float.MinValue;
    [SerializeField] private float _maxValue = float.MaxValue;

    public override void ChangeValue(float amount)
    {
        _value += amount;
        _value = ClampValue(_value);
        OnValueChanged.Invoke(_value);
    }

    public override float GetValue()
    {
        return _value;
    }

    public override void SetValue(float value)
    {
        _value = ClampValue(value);
        OnValueChanged.Invoke(_value);
    }

    private float ClampValue(float value)
    {
        return Mathf.Clamp(value, _minValue, _maxValue);
    }
}
