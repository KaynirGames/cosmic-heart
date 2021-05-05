using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Canvas))]
public class WindowUI : MonoBehaviour
{
    [SerializeField] private UnityEvent _onOpenWindow = null;
    [SerializeField] private UnityEvent _onCloseWindow = null;

    private Canvas _canvas;

    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
    }

    public void OpenWindow()
    {
        _canvas.enabled = true;
        _onOpenWindow?.Invoke();
    }

    public void CloseWindow()
    {
        _canvas.enabled = false;
        _onCloseWindow?.Invoke();
    }
}
