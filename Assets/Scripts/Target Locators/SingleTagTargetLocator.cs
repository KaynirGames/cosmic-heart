using UnityEngine;

public class SingleTagTargetLocator : BaseTargetLocator
{
    [SerializeField] private string _targetTag = null;

    public override GameObject LocateTarget()
    {
        return GameObject.FindGameObjectWithTag(_targetTag);
    }
}
