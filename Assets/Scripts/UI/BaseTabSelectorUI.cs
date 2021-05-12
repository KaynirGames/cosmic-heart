using UnityEngine;

public class BaseTabSelectorUI : MonoBehaviour
{
    [Header("Base Settings:")]
    [SerializeField] protected WindowUI[] _tabs = null;
    [SerializeField] protected GameObject _prevTabButton = null;
    [SerializeField] protected GameObject _nextTabButton = null;

    protected int _tabIndex;

    public void SwitchPrevious()
    {
        ShowContent(_tabIndex - 1);
    }

    public void SwitchNext()
    {
        ShowContent(_tabIndex + 1);
    }

    public void SwitchLast()
    {
        ShowContent(_tabIndex);
    }

    protected virtual void ShowContent(int index)
    {
        HideContent(_tabIndex);

        _tabs[index].OpenWindow();
        _tabIndex = index;

        UpdateTabButtons();
    }

    protected virtual void HideContent(int index)
    {
        _tabs[index].CloseWindow();
    }

    protected void UpdateTabButtons()
    {
        _prevTabButton.SetActive(_tabIndex > 0);
        _nextTabButton.SetActive(_tabIndex < _tabs.Length - 1);
    }
}
