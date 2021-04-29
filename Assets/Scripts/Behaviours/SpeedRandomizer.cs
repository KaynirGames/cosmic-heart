using UnityEngine;

public class SpeedRandomizer : MonoBehaviour
{
    private const int SPEED_PRECISION = 100;

    [SerializeField] private float _minSpeed = 3.0f;
    [SerializeField] private float _maxSpeed = 5.0f;

    private ISpeedHandler _speedHandler;

    private void Awake()
    {
        _speedHandler = GetComponent<ISpeedHandler>();
    }

    private void Start()
    {
        float speed = Random.Range(_minSpeed, _maxSpeed);
        _speedHandler.SetSpeed(speed.Precise(SPEED_PRECISION));
    }
}
