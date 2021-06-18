using TMPro;
using UnityEngine;

public class ShopUpgradeHandler : MonoBehaviour
{
    [SerializeField] private IntVariableSO _upgradeID = null;
    [SerializeField] private IntVariableSO _moneyStorage = null;
    [SerializeField] private ShopUpgradeSO[] _upgrades = null;
    [SerializeField] private ShopUpgradeSO _maxUpgrade = null;
    [Header("Отображение улучшения:")]
    [SerializeField] private TextMeshProUGUI _upgradeDescField = null;
    [SerializeField] private ButtonStateHandler _upgradeButtonHandler = null;
    [SerializeField] private string _upgradeCostFormat = "{0} Зол";
    [SerializeField] private string _upgradeBoughtText = "Куплено";
    [Header("Подтвержение улучшения:")]
    [SerializeField] private ConfirmDialogPopup _upgradeConfirmPopup = null;
    [SerializeField] private string _confirmTitleText = "Улучшение";
    [SerializeField] private string _confirmMessageFormat = "Приобрести за {0} Зол?";

    private ShopUpgradeSO _upgrade;

    private void Awake()
    {
        _upgradeID.OnValueChanged += DisplayUpgrade;
        _moneyStorage.OnValueChanged += UpdateUpgradeButton;
    }

    private void Start()
    {
        DisplayUpgrade();
    }

    public void TryBuyUpgrade()
    {
        _upgradeConfirmPopup.Show(_confirmTitleText,
                                  string.Format(_confirmMessageFormat, _upgrade.Cost),
                                  BuyUpgrade);
    }

    public void DisplayUpgrade()
    {
        DisplayUpgrade(_upgradeID.Value);
    }

    private void DisplayUpgrade(int index)
    {
        if (index == _upgrades.Length)
        {
            _moneyStorage.OnValueChanged -= UpdateUpgradeButton;
            _upgradeDescField.SetText(_maxUpgrade.Desc);
            _upgradeButtonHandler.SetButtonState(_upgradeBoughtText,
                                                 false,
                                                 null);
            return;
        }

        _upgrade = _upgrades[index];
        _upgradeDescField.SetText(_upgrade.Desc);
        _upgradeButtonHandler.SetButtonState(string.Format(_upgradeCostFormat, _upgrade.Cost),
                                             _moneyStorage.Value >= _upgrade.Cost,
                                             TryBuyUpgrade);
    }

    private void BuyUpgrade()
    {
        //_moneyStorage.ApplyChange(-_upgrade.Cost);
        //_upgradeID.ApplyChange(1);
    }

    private void UpdateUpgradeButton(int money)
    {
        _upgradeButtonHandler.SetInteraction(money >= _upgrade.Cost);
    }
}