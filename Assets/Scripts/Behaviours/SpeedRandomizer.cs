using UnityEngine;

public class SpeedRandomizer : MonoBehaviour
{
    [SerializeField] private float _minSpeed = 3f;
    [SerializeField] private float _maxSpeed = 5f;

    private ISpeedHandler _speedHandler;

    private void Awake()
    {
        _speedHandler = GetComponent<ISpeedHandler>();
    }

    private void Start()
    {
        _speedHandler.SetSpeed(Random.Range(_minSpeed,
                                            _maxSpeed));
    }
}
