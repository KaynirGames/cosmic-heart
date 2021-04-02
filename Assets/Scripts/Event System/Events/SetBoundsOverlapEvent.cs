using UnityEngine;

public class SetBoundsOverlapEvent : BaseEvent
{
    [SerializeField] private string _boundsTag = "Default";
    [SerializeField] private bool _withinBounds = false;

    protected override void Invoke(GameObject target)
    {
        if (target.TryGetComponent(out IOverlapChecker checker))
        {
            if (checker.IsValidTag(_boundsTag))
            {
                checker.SetOverlapStatus(_withinBounds);
            }
        }
    }
}
