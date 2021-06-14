using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    [SerializeField] private Image _weaponImage = null;
    [SerializeField] private GameObjectRuntimeListSO _weaponList = null;
    [SerializeField] private PlayerHandler _playerHandler = null;

    private WeaponInfo[] _weaponInfos;
    private WeaponSystem _weaponSystem;

    private void Awake()
    {
        _playerHandler.OnPlayerActive += Init;
    }

    private void Init(Player player)
    {
        _weaponInfos = System.Array.ConvertAll(_weaponList.GetAll(),
                                               x => x.GetComponent<WeaponInfo>());
        _weaponSystem = player.GetComponent<WeaponSystem>();
        _weaponSystem.OnCurrentWeaponChanged += DisplayCurrentWeapon;
        DisplayCurrentWeapon(0);
    }

    private void DisplayCurrentWeapon(int weaponIndex)
    {
        _weaponImage.sprite = _weaponInfos[weaponIndex].WeaponIcon;
    }
}
