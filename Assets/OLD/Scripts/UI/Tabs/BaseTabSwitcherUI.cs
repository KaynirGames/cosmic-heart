using UnityEngine;

public class BaseTabSwitcherUI : MonoBehaviour
{
    [SerializeField] protected BaseTabHandlerUI _tabHandler = null;

    protected int _tabIndex;

    public void Switch(int tabIndex)
    {
        ShowContent(tabIndex);
    }

    public void SwitchPrevious()
    {
        Switch(_tabIndex - 1);
    }

    public void SwitchNext()
    {
        Switch(_tabIndex + 1);
    }

    public void SwitchCurrent()
    {
        Switch(_tabIndex);
    }

    protected virtual void ShowContent(int index)
    {
        HideContent(_tabIndex);

        _tabHandler.GetTabWindow(index)
                   .Open();

        _tabIndex = index;

        _tabHandler.HandleTabButtons(_tabIndex);
    }

    protected virtual void HideContent(int index)
    {
        _tabHandler.GetTabWindow(index)
                   .Close();
    }
}
