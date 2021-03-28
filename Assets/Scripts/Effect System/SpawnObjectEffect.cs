using UnityEngine;

public class SpawnObjectEffect : BaseEffect
{
    [SerializeField] private GameObject _prefab = null;

    public override void Activate(GameObject go)
    {
        if (_prefab != null)
        {
            Instantiate(_prefab,
                        GetProperTarget(go).transform.position,
                        Quaternion.identity);
        }
    }
}
