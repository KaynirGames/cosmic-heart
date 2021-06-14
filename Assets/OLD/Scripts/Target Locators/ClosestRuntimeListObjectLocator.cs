using UnityEngine;

public class ClosestRuntimeListObjectLocator : BaseTargetLocator
{
    [SerializeField] private GameObjectRuntimeListSO _gameObjectList = null;

    public override GameObject LocateTarget()
    {
        return gameObject.FindClosestObject(_gameObjectList.GetAll());
    }
}
