using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private Image _mask = null;
    [SerializeField] private IntVariableSO _value = null;
    [SerializeField] private IntVariableSO _maxValue = null;

    private void Awake()
    {
        _value.OnValueChanged += UpdateBarValue;
        _maxValue.OnValueChanged += UpdateMaxBarValue;
    }

    private void UpdateBarValue(int value)
    {
        _mask.fillAmount = (float)value / _maxValue.Value;
    }

    private void UpdateMaxBarValue(int maxValue)
    {
        UpdateBarValue(_value.Value);
    }
}