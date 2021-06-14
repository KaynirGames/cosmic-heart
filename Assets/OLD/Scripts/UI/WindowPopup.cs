using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Canvas))]
public class WindowPopup : MonoBehaviour
{
    [SerializeField] private UnityEvent _onOpen = null;
    [SerializeField] private UnityEvent _onClose = null;

    private Canvas _canvas;

    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
    }

    public void Open()
    {
        _canvas.enabled = true;
        _onOpen?.Invoke();
    }

    public void Close()
    {
        _onClose?.Invoke();
        _canvas.enabled = false;
    }
}