using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntVariableTextDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textField = null;
    [SerializeField] private IntVariableSO _intVariable = null;
    [SerializeField] private string _numericFormat = "000000000";

    private void Start()
    {
        UpdateTextField(_intVariable.Value);
    }

    private void UpdateTextField(int value)
    {
        _textField.SetText(value.ToString(_numericFormat));
    }

    private void OnEnable()
    {
        _intVariable.OnValueChanged += UpdateTextField;
    }

    private void OnDisable()
    {
        _intVariable.OnValueChanged -= UpdateTextField;
    }
}
