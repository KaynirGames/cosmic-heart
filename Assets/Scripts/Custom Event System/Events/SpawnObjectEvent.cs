using UnityEngine;

public class SpawnObjectEvent : BaseEvent
{
    [SerializeField] private GameObject _prefab = null;

    protected override void Invoke(GameObject target)
    {
        if (_prefab != null)
        {
            Instantiate(_prefab,
                        target.transform.position,
                        Quaternion.identity);
        }
    }
}
