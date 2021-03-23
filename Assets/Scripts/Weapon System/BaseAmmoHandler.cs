using UnityEngine;

public abstract class BaseAmmoHandler : MonoBehaviour
{
    public abstract bool CheckAmmo();

    public abstract void ConsumeAmmo();

    public abstract void Reload();
}