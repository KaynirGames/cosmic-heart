using UnityEngine;

public abstract class BaseTabHandlerUI : MonoBehaviour
{
    [SerializeField] protected WindowUI[] _tabs = null;

    public WindowUI GetTabWindow(int tabIndex)
    {
        return _tabs[tabIndex];
    }

    public abstract void HandleTabButtons(int tabIndex);
}
