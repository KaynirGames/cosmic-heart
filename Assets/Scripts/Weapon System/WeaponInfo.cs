using UnityEngine;

public class WeaponInfo : MonoBehaviour
{
    [SerializeField] private string _weaponID = null;
    [SerializeField] private Sprite _weaponIcon = null;

    public string ID => _weaponID;
    public Sprite WeaponIcon => _weaponIcon;
}
