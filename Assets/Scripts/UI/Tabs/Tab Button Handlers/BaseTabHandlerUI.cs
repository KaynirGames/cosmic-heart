using UnityEngine;

public abstract class BaseTabHandlerUI : MonoBehaviour
{
    [SerializeField] protected WindowPopup[] _tabs = null;

    public WindowPopup GetTabWindow(int tabIndex)
    {
        return _tabs[tabIndex];
    }

    public abstract void HandleTabButtons(int tabIndex);
}
