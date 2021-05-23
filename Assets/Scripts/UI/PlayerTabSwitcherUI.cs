using UnityEngine;

public class PlayerTabSwitcherUI : BaseTabSwitcherUI
{
    private const string SELECT_TEXT = "Выбрать";
    private const string SELECTED_TEXT = "Выбрано";
    private const string LOCKED_TEXT = "Закрыто";

    [SerializeField] private IntVariableSO _playerShipID = null;
    [SerializeField] private IntVariableSO _shipUpgradeID = null;
    [SerializeField] private ShopUpgradeHandler _shipUpgradeHandler = null;
    [SerializeField] private ButtonStateHandler _shipButtonHandler = null;

    protected override void ShowContent(int index)
    {
        base.ShowContent(index);
        UpdateShipButton(index);
    }

    private void SetShip()
    {
        _playerShipID.SetValue(_tabIndex);
        UpdateShipButton(_tabIndex);
    }

    private void BuyShip()
    {
        _shipUpgradeHandler.TryBuyUpgrade();
        UpdateShipButton(_tabIndex);
    }

    private void UpdateShipButton(int index)
    {
        bool isLocked = index > _shipUpgradeID.Value;

        if (isLocked)
        {
            HandleLockedShipButton(index);
            return;
        }

        HandleUnlockedShipButton(index);
    }

    private void HandleLockedShipButton(int index)
    {
        if (index == _shipUpgradeID.Value + 1)
        {
            _shipUpgradeHandler.DisplayUpgrade();
            _shipButtonHandler.SetOnClickAction(BuyShip);
            return;
        }

        _shipButtonHandler.SetButtonState(LOCKED_TEXT,
                                          false,
                                          null);
    }

    private void HandleUnlockedShipButton(int index)
    {
        if (index == _playerShipID.Value)
        {
            _shipButtonHandler.SetButtonState(SELECTED_TEXT,
                                              false,
                                              null);
            return;
        }

        _shipButtonHandler.SetButtonState(SELECT_TEXT,
                                          true,
                                          SetShip);
    }
}