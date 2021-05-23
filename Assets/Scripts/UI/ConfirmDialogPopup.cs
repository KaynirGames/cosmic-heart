using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ConfirmDialogPopup : MonoBehaviour
{
    [SerializeField] private WindowPopup _dialogWindow = null;
    [SerializeField] private TextMeshProUGUI _titleField = null;
    [SerializeField] private TextMeshProUGUI _messageField = null;

    private UnityAction _onConfirm;
    private UnityAction _onCancel;

    public void Show(string title, string message, UnityAction onConfirm, UnityAction onCancel)
    {
        _titleField.SetText(title);
        _messageField.SetText(message);
        _onConfirm = onConfirm;
        _onCancel = onCancel;
        _dialogWindow.Open();
    }

    public void Show(string title, string message, UnityAction onConfirm)
    {
        Show(title, message, onConfirm, null);
    }

    public void Confirm()
    {
        _onConfirm?.Invoke();
        Hide();
    }

    public void Cancel()
    {
        _onCancel?.Invoke();
        Hide();
    }

    private void Hide()
    {
        _dialogWindow.Close();
        _onConfirm = null;
        _onCancel = null;
    }
}