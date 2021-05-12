using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUpgradeHandler : MonoBehaviour
{
    private const string COST_FORMAT = "{0} Зол";
    private const string BOUGHT_TEXT = "Куплено";

    [SerializeField] private IntVariableSO _upgradeID = null;
    [SerializeField] private IntVariableSO _moneyStorage = null;
    [SerializeField] private ShopUpgradeDataSO[] _upgrades = null;
    [SerializeField] private TextMeshProUGUI _upgradeDescField = null;
    [SerializeField] private Button _buyUpgradeButton = null;

    private TextMeshProUGUI _upgradeCostField;

    private void Awake()
    {
        _upgradeCostField = _buyUpgradeButton.GetComponentInChildren<TextMeshProUGUI>();
        _upgradeID.OnValueChanged += DisplayUpgrade;
    }

    private void Start()
    {
        DisplayUpgrade(_upgradeID.Value);
    }

    public void BuyUpgrade()
    {
        _moneyStorage.ApplyChange(-GetUpgradeData(_upgradeID.Value).Cost);
        _upgradeID.ApplyChange(1);
    }

    private void DisplayUpgrade(int index)
    {
        if (index == _upgrades.Length)
        {
            _upgradeCostField.SetText(BOUGHT_TEXT);
            return;
        }

        var upgradeData = GetUpgradeData(index);

        if (_upgradeDescField != null)
        {
            _upgradeDescField.SetText(upgradeData.Desc);
        }

        _upgradeCostField.SetText(string.Format(COST_FORMAT,
                                                upgradeData.Cost));
        _buyUpgradeButton.interactable = _moneyStorage.Value >= upgradeData.Cost;
    }

    private ShopUpgradeDataSO GetUpgradeData(int index)
    {
        return _upgrades[index];
    }
}
