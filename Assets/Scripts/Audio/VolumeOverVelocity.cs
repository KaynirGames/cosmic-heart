using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class VolumeOverVelocity : MonoBehaviour
{
    [SerializeField] private SoundSO _soundSO = null;
    [SerializeField] private AnimationCurve _pitchCurve = AnimationCurve.Linear(0f, 0f, 1f, 3f);
    [SerializeField] private float _maxVelocity = 50f;

    private AudioSource _audioSource;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _audioSource.clip = _soundSO.GetAudioClip();
        _audioSource.volume = _soundSO.VolumeScale;
    }

    private void Update()
    {
        _audioSource.pitch = EvaluatePitch(_rigidbody2D.velocity.sqrMagnitude
                                           / _maxVelocity);
    }

    public float EvaluatePitch(float time)
    {
        return _pitchCurve.Evaluate(time);
    }
}