using UnityEngine;

[System.Serializable]
public class Timer
{
    public event System.Action OnTimerElapsed;

    [SerializeField] private float _duration = 0f;
    [SerializeField] private bool _unscaled = false;

    public bool Elapsed { get; private set; }

    private float _elapsedTime;

    public Timer(float duration, bool unscaled)
    {
        SetDuration(duration);
        SetTimeScale(unscaled);
    }

    public Timer(float duration) : this(duration, false) { }

    public void SetDuration(float duration)
    {
        _duration = duration;
        _elapsedTime = 0f;
    }

    public void SetTimeScale(bool unscaled)
    {
        _unscaled = unscaled;
    }

    public void Reset()
    {
        _elapsedTime = _duration;
        Elapsed = false;
    }

    public void Tick(float delta)
    {
        if (Elapsed) { return; }

        _elapsedTime -= delta;

        if (_elapsedTime <= 0)
        {
            Elapsed = true;
            OnTimerElapsed?.Invoke();
        }
    }

    public void Tick()
    {
        Tick(_unscaled
            ? Time.unscaledDeltaTime
            : Time.deltaTime);
    }
}