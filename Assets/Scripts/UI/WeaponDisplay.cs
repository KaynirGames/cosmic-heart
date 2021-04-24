using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    [SerializeField] private Image _weaponImage = null;
    [SerializeField] private GameObjectRuntimeListSO _weaponList = null;
    [SerializeField] private GameObjectRuntimeListSO _playerList = null;

    private WeaponInfo[] _weaponInfos;
    private WeaponSystem _weaponSystem;

    private void Start()
    {
        _weaponInfos = System.Array.ConvertAll(_weaponList.GetAll(),
                                               x => x.GetComponent<WeaponInfo>());

        _weaponSystem = _playerList.Get(0).GetComponent<WeaponSystem>();
        _weaponSystem.OnCurrentWeaponChanged += DisplayCurrentWeapon;
        DisplayCurrentWeapon(0);
    }

    private void DisplayCurrentWeapon(int weaponIndex)
    {
        _weaponImage.sprite = _weaponInfos[weaponIndex].WeaponIcon;
    }

    private void OnDisable()
    {
        _weaponSystem.OnCurrentWeaponChanged -= DisplayCurrentWeapon;
    }
}
