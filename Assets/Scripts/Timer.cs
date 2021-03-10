using UnityEngine;

public class Timer
{
    public bool Elapsed { get; private set; }

    private float _duration;
    private float _elapsedTime;

    public Timer(float duration)
    {
        ChangeDuration(duration);
    }

    public void ChangeDuration(float duration)
    {
        _duration = duration;
        _elapsedTime = 0f;
        Elapsed = true;
    }

    public void Reset()
    {
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

    public void Tick(bool unscaledTime = false)
    {
        float delta = unscaledTime
            ? Time.unscaledDeltaTime
            : Time.deltaTime;

        Tick(delta);
    }
}
