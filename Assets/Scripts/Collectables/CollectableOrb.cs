using UnityEngine;

public class CollectableOrb : Collectable
{
    [SerializeField] private GameObjectVariableSO _worldBounds = null;
    [SerializeField] private GameObjectVariableSO _player = null;
    [SerializeField] private int _energyGain = 10;

    private IColorHandler[] _colorHandlers;
    private ColorOverDistance _colorOverDistance;
    private EnergyConsumer _energyConsumer;
    
    private float _maxDistance;

    private void Awake()
    {
        _colorHandlers = GetComponentsInChildren<IColorHandler>();
        _colorOverDistance = GetComponent<ColorOverDistance>();
    }

    private void Start()
    {
        _maxDistance = GetMaxDistance();
        UpdateOrbColor();
        _energyConsumer = _player.Value.GetComponent<EnergyConsumer>();
    }

    public override void Collect()
    {
        _energyConsumer.ChangeEnergy(_energyGain);

        base.Collect();
    }

    private void UpdateOrbColor()
    {
        Color color = _colorOverDistance.LerpColor(_maxDistance);

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
}