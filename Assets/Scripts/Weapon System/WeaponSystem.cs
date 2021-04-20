﻿using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public delegate void OnWeaponChanged(int weaponIndex);

    public event OnWeaponChanged OnCurrentWeaponChanged = delegate { };

    [SerializeField] private List<WeaponBase> _weapons = new List<WeaponBase>();

    public WeaponBase CurrentWeapon { get; private set; }

    private Dictionary<string, WeaponBase> _weaponDict;

    private void Awake()
    {
        _weaponDict = new Dictionary<string, WeaponBase>();

        foreach (WeaponBase weapon in _weapons)
        {
            _weaponDict.Add(weapon.GetComponent<WeaponInfo>().ID,
                            weapon);
        }
    }

    private void Start()
    {
        SetCurrentWeapon(0);
    }

    public void SetCurrentWeapon(int weaponIndex)
    {
        CurrentWeapon = _weapons[weaponIndex];
        OnCurrentWeaponChanged.Invoke(weaponIndex);
    }

    public void SetCurrentWeapon(string weaponID)
    {
        CurrentWeapon = _weaponDict[weaponID];
        OnCurrentWeaponChanged.Invoke(_weapons.IndexOf(CurrentWeapon));
    }

    public void UseWeapon(int weaponIndex)
    {
        _weapons[weaponIndex].UseWeapon();
    }

    public void UseWeapon(string weaponID)
    {
        _weaponDict[weaponID].UseWeapon();
    }

    public void UseCurrentWeapon()
    {
        CurrentWeapon.UseWeapon();
    }

    public void UseRandomWeapon()
    {
        int index = Random.Range(0, _weapons.Count);
        UseWeapon(index);
    }
}
