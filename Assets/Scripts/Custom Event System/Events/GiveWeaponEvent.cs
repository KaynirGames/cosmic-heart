using UnityEngine;

public class GiveWeaponEvent : BaseEvent
{
    [SerializeField] private WeaponInfo _weaponInfo = null;

    public override void TryInvoke(GameObject target)
    {
        if (target.TryGetComponent(out WeaponSystem weaponSystem))
        {
            weaponSystem.SetCurrentWeapon(_weaponInfo.ID);
        }
    }
}