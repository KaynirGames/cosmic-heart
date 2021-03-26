using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BoundaryBehavior : MonoBehaviour, IBoundary
{
    [SerializeField] private string _boundaryID = "LevelBounds";

    private Collider2D _collider2D;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
        _collider2D.isTrigger = true;
    }

    public bool CheckOverlap(string boundaryID)
    {
        return _boundaryID == boundaryID;
    }
}
