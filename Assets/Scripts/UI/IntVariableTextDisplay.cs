using TMPro;
using UnityEngine;

public class IntVariableTextDisplay : IntVariableBaseDisplay
{
    [SerializeField] private TextMeshProUGUI _textField = null;
    [SerializeField] private string _numericFormat = "000000000";

    protected override void UpdateDisplayValue(int value)
    {
        _textField.SetText(value.ToString(_numericFormat));
    }
}
