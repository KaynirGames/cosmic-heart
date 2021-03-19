using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] private Weapon[] _weapons = null;

    public Weapon CurrentWeapon { get; private set; }

    private Dictionary<string, Weapon> _weaponDict;

    private void Awake()
    {
        _weaponDict = new Dictionary<string, Weapon>();

        foreach (Weapon weapon in _weapons)
        {
            _weaponDict.Add(weapon.ID, weapon);
        }
    }

    private void Start()
    {
        SetCurrentWeapon(0);
    }

    public void SetCurrentWeapon(int weaponIndex)
    {
        CurrentWeapon = _weapons[weaponIndex];
    }

    public void SetCurrentWeapon(string weaponID)
    {
        CurrentWeapon = _weaponDict[weaponID];
    }

    public void UseWeapon(int weaponIndex)
    {
        _weapons[weaponIndex].Attack();
    }

    public void UseWeapon(string weaponID)
    {
        _weaponDict[weaponID].Attack();
    }

    public void UseCurrentWeapon()
    {
        CurrentWeapon.Attack();
    }

    public void UseRandomWeapon()
    {
        int index = Random.Range(0, _weapons.Length);
        UseWeapon(index);
    }
}
