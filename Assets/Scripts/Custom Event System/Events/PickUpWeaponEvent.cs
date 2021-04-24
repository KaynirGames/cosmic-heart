using UnityEngine;

public class PickUpWeaponEvent : BaseEvent
{
    [SerializeField] private WeaponInfo _weaponInfo = null;

    protected override void Invoke(GameObject target)
    {
        if (target.TryGetComponent(out WeaponSystem weaponSystem))
        {
            weaponSystem.SetCurrentWeapon(_weaponInfo.ID);
        }
    }
}