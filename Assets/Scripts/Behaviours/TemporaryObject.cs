using UnityEngine;

public class TemporaryObject : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 1f;

    private Timer _timer;

    private void Start()
    {
        _timer = new Timer(_lifeTime);
        _timer.Reset();
    }

    private void Update()
    {
        if (_timer.Elapsed)
        {
            gameObject.Dispose();
            return;
        }

        _timer.Tick(Time.deltaTime);
    }
}
