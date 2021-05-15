using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUpgradeHandler : MonoBehaviour
{
    [SerializeField] private IntVariableSO _upgradeID = null;
    [SerializeField] private IntVariableSO _moneyStorage = null;
    [SerializeField] private ShopUpgradeSO[] _upgrades = null;
    [Space]
    [SerializeField] private TextMeshProUGUI _upgradeDescField = null;
    [SerializeField] private TextMeshProUGUI _upgradeCostField = null;
    [SerializeField] private Button _upgradeButton = null;
    [SerializeField] private string _upgradeCostFormat = "{0} $";
    [SerializeField] private string _upgradeBoughtText = "Куплено";
    [SerializeField] private string _upgradeMaxText = "Макс.";

    private ShopUpgradeSO _upgrade;

    private void Awake()
    {
        _upgradeID.OnValueChanged += DisplayUpgrade;
        _moneyStorage.OnValueChanged += EnableUpgradeButton;
    }

    private void Start()
    {
        DisplayUpgrade(_upgradeID.Value);
    }

    public void BuyUpgrade()
    {
        _moneyStorage.ApplyChange(-_upgrade.Cost);
        _upgradeID.ApplyChange(1);
    }

    private void EnableUpgradeButton(int money)
    {
        _upgradeButton.interactable = money >= _upgrade.Cost;
    }

    private void DisplayUpgrade(int index)
    {
        if (index == _upgrades.Length)
        {
            _upgradeDescField.SetText(_upgradeMaxText);
            _upgradeCostField.SetText(_upgradeBoughtText);
            _upgradeButton.interactable = false;
            return;
        }

        _upgrade = _upgrades[index];

        _upgradeDescField.SetText(_upgrade.Desc);
        _upgradeCostField.SetText(string.Format(_upgradeCostFormat,
                                                _upgrade.Cost));
        EnableUpgradeButton(_moneyStorage.Value);
    }
}