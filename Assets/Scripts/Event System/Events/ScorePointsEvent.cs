using UnityEngine;

public class ScorePointsEvent : BaseEvent
{
    [SerializeField] private IntReference _pointAmount = null;
    [SerializeField] private IntVariableSO _pointStorage = null;

    protected override void Invoke(GameObject target)
    {
        _pointStorage.ApplyChange(_pointAmount.Value);
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        _eventMode = EventMode.None;
    }
#endif
}
