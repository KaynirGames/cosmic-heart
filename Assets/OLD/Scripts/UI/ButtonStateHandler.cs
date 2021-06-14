using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonStateHandler : MonoBehaviour
{
    private Button _button;
    private TextMeshProUGUI _textField;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _textField = _button.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetButtonState(string text, bool interactable, UnityAction onClick)
    {
        SetText(text);
        SetInteraction(interactable);
        SetOnClickAction(onClick);
    }

    public void SetText(string text)
    {
        _textField.SetText(text);
    }

    public void SetInteraction(bool enable)
    {
        _button.interactable = enable;
    }

    public void SetOnClickAction(UnityAction onClick)
    {
        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(onClick);
    }
}