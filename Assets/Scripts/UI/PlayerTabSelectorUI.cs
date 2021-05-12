using UnityEngine;
using UnityEngine.UI;

public class PlayerTabSelectorUI : BaseTabSelectorUI
{
    [Header("Player Selector Settings:")]
    [SerializeField] private IntVariableSO _playerShipID = null;
    [SerializeField] private IntVariableSO _shipUpgradeID = null;
    [SerializeField] private ShopUpgradeHandler _shipUpgradeHandler = null;
    [SerializeField] private Button _setButton = null;
    [SerializeField] private Button _selectedButton = null;
    [SerializeField] private Button _buyButton = null;
    [SerializeField] private Button _lockedButton = null;

    public void SetShip()
    {
        _playerShipID.SetValue(_tabIndex);
        ShowActionButtons(_tabIndex);
    }

    public void BuyShip()
    {
        _shipUpgradeHandler.BuyUpgrade();
        ShowActionButtons(_tabIndex);
    }

    protected override void ShowContent(int index)
    {
        base.ShowContent(index);
        ShowActionButtons(index);
    }

    private void ShowActionButtons(int index)
    {
        bool isLocked = index > _shipUpgradeID.Value;

        _lockedButton.gameObject.SetActive(isLocked && index != _shipUpgradeID.Value + 1);
        _buyButton.gameObject.SetActive(isLocked && index == _shipUpgradeID.Value + 1);

        _setButton.gameObject.SetActive(!isLocked && index != _playerShipID.Value);
        _selectedButton.gameObject.SetActive(!isLocked && index == _playerShipID.Value);
    }
}
