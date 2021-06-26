using UnityEngine;

public class EnergyConsumer : MonoBehaviour
{
    public System.Action OnEnergyDrained;

    [SerializeField] private IntReference _current = null;
    [SerializeField] private IntReference _max = null;
    [SerializeField] private float _consumeTime = .5f;
    [SerializeField] private int _consumeAmount = 1;

    private Timer _consumeTimer;
    private bool _isDrained;

    private void Start()
    {
        _current.SetValue(_max.Value);
        _consumeTimer = new Timer(_consumeTime, true);
        _consumeTimer.OnTimerElapsed += ConsumeEnergy;
        _consumeTimer.Reset();
    }

    private void Update()
    {
        if (_isDrained) { return; }

        _consumeTimer.Tick();
    }

    public void ChangeEnergy(int amount)
    {
        _current.SetValue(Mathf.Clamp(_current.Value + amount,
                                      0,
                                      _max.Value));
    }

    private void ConsumeEnergy()
    {
        ChangeEnergy(-_consumeAmount);

        if (_current.Value == 0)
        {
            _isDrained = true;
            OnEnergyDrained?.Invoke();
        }
    }
}