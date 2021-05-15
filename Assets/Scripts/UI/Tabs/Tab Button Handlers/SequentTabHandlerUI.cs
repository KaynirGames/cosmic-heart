using UnityEngine;
using UnityEngine.UI;

public class SequentTabHandlerUI : BaseTabHandlerUI
{
    [SerializeField] private Button _previousTabButton = null;
    [SerializeField] private Button _nextTabButton = null;

    public override void HandleTabButtons(int tabIndex)
    {
        _previousTabButton.interactable = tabIndex > 0;
        _nextTabButton.interactable = tabIndex < _tabs.Length - 1;
    }
}
