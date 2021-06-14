using UnityEngine;

public class ScorePointsEvent : BaseEvent
{
    [SerializeField] private IntReference _pointAmount = null;
    [SerializeField] private IntVariableSO _pointStorage = null;

    public override void TryInvoke(GameObject target)
    {
        _pointStorage.ApplyChange(_pointAmount.Value);
    }
}