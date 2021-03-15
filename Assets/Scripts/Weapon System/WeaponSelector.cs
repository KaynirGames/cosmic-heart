using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
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
        SelectWeapon(0);
    }

    public bool SelectWeapon(int weaponIndex)
    {
        if (_weapons.Length > 0)
        {
            CurrentWeapon = _weapons[weaponIndex];
            return true;
        }

        return false;
    }

    public bool SelectWeapon(string weaponID)
    {
        if (_weaponDict.ContainsKey(weaponID))
        {
            CurrentWeapon = _weaponDict[weaponID];
            return true;
        }

        return false;
    }

    public bool SelectWeapon(Weapon weapon)
    {
        return SelectWeapon(weapon.ID);
    }

    public bool SelectRandomWeapon()
    {
        return SelectWeapon(Random.Range(0,
                                         _weapons.Length));
    }
}
