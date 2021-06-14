using UnityEngine;

public class SpawnObjectEvent : BaseEvent
{
    [SerializeField] private GameObject _prefab = null;

    public override void TryInvoke(GameObject target)
    {
        if (_prefab != null)
        {
            Instantiate(_prefab,
                        target.transform.position,
                        Quaternion.identity);
        }
    }
}