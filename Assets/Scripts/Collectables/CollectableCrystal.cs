using UnityEngine;

public class CollectableCrystal : Collectable
{
    [SerializeField] private GameObjectVariableSO _worldBounds = null;
    [SerializeField] private GameObjectVariableSO _cosmicHeart = null;
    [SerializeField] private Gradient _gradient = null;

    private IColorHandler[] _colorHandlers;
    private float _maxDistance;
    private Transform _target;

    private void Awake()
    {
        _colorHandlers = GetComponentsInChildren<IColorHandler>();
    }

    private void Start()
    {
        _maxDistance = GetMaxDistance();
        _target = _cosmicHeart.Value.transform;
        UpdateCrystalColor();
    }

    private void UpdateCrystalColor()
    {
        Color color = _gradient.Evaluate(GetTargetDistance()
                                         / _maxDistance);

        foreach (var handler in _colorHandlers)
        {
            handler.SetColor(color);
        }
    }

    private float GetMaxDistance()
    {
        Vector2 size = _worldBounds.Value.transform.localScale;

        return Vector2.Distance(size, -size);
    }

    private float GetTargetDistance()
    {
        return Vector2.Distance(transform.position,
                                _target.position);
    }
}