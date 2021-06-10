using UnityEngine;

public class TemporaryObject : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 1f;

    private Timer _timer;

    private void Awake()
    {
        _timer = new Timer(_lifeTime);
        _timer.Reset();
    }

    private void OnEnable()
    {
        if (_timer != null)
        {
            _timer.Reset();
        }
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