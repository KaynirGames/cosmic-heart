using UnityEngine;

public class SpawnObjectEffect : BaseEffect
{
    [SerializeField] private GameObject _prefab = null;

    public override void Activate(GameObject target)
    {
        if (_prefab != null)
        {
            Instantiate(_prefab,
                        target.transform.position,
                        Quaternion.identity);
        }
    }
}
