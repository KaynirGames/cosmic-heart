public class Timer
{
    public bool Elapsed { get; private set; }

    private float _duration;
    private float _elapsedTime;

    public Timer(float duration)
    {
        _duration = duration;
        Elapsed = true;
    }

    public Timer() : this(0f) { }

    public void ChangeDuration(float duration)
    {
        _duration = duration;
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
}
