using UnityEngine;

public class Timer
{
    public bool Elapsed { get; private set; }

    private float _duration;
    private float _elapsedTime;
    private bool _unscaled;

    public Timer(float duration, bool unscaled = false)
    {
        SetDuration(duration);
        _unscaled = unscaled;
    }

    public void SetDuration(float duration)
    {
        _duration = duration;
        _elapsedTime = 0f;
        Elapsed = true;
    }

    public void Reset()
    {
        if (_elapsedTime >= 0)
        {
            _elapsedTime = 0f;
        }

        _elapsedTime += _duration;

        Elapsed = false;
    }

    public void Tick(float delta)
    {
        if (Elapsed) { return; }

        _elapsedTime -= delta;

        if (_elapsedTime <= 0)
        {
            Elapsed = true;
        }
    }

    public void Tick()
    {
        float delta = _unscaled
            ? Time.unscaledDeltaTime
            : Time.deltaTime;

        Tick(delta);
    }
}
