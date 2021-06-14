using TMPro;
using UnityEngine;

public class IntVariableTextDisplay : IntVariableBaseDisplay
{
    [SerializeField] private TextMeshProUGUI _textField = null;
    [SerializeField] private string _format = "{0:000000000}";

    protected override void UpdateDisplayValue(int value)
    {
        _textField.SetText(string.Format(_format, value));
    }
}
