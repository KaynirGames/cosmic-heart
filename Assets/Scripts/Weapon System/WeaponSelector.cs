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
        SelectWeapon(_weapons[0]);
    }

    public void SelectWeapon(Weapon weapon)
    {
        if (_weaponDict.ContainsKey(weapon.ID))
        {
            CurrentWeapon = _weaponDict[weapon.ID];
        }
    }
}
