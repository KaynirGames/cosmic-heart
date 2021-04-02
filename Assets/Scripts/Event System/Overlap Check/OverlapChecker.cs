using UnityEngine;

public class OverlapChecker : MonoBehaviour, IOverlapChecker
{
    [SerializeField] private string _overlapTag = "Default";

    private bool _isOverlapping;

    public bool GetOverlapStatus()
    {
        return _isOverlapping;
    }

    public bool IsValidTag(string tag)
    {
        return _overlapTag == tag;
    }

    public void SetOverlapStatus(bool isOverlapping)
    {
        _isOverlapping = isOverlapping;
    }
}
