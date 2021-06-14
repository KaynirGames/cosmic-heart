using UnityEngine;
using UnityEngine.UI;

public class SelectiveTabHandlerUI : BaseTabHandlerUI
{
    [SerializeField] private Button[] _tabButtons = null;

    public override void HandleTabButtons(int tabIndex)
    {
        for (int i = 0; i < _tabButtons.Length; i++)
        {
            _tabButtons[i].interactable = i != tabIndex;
        }
    }
}
