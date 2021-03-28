using UnityEngine;

public class TriggerBoundaryChecker : MonoBehaviour, IBoundaryChecker
{
    [SerializeField] private string _boundaryID = "LevelBounds";

    private bool _isWithinBounds;

    public bool IsWithinBounds()
    {
        return _isWithinBounds;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetOverlapResult(collision, true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SetOverlapResult(collision, false);
    }

    private void SetOverlapResult(Collider2D collision, bool result)
    {
        if (collision.TryGetComponent(out IBoundary boundary))
        {
            if (boundary.CheckOverlap(_boundaryID))
            {
                _isWithinBounds = result;
                return;
            }
        }

        _isWithinBounds = false;
    }
}
