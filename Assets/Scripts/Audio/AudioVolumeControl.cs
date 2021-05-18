using UnityEngine;
using UnityEngine.Audio;

public class AudioVolumeControl : MonoBehaviour
{
    private const int LOG_BASE = 10;
    private const int DECIBEL_FACTOR = 20;
    private const float MIN_VOLUME_RATE = 0.0001f;

    [SerializeField] private string _volumeParameter = "MasterVolume";
    [SerializeField] private AudioMixer _audioMixer = null;

    public bool IsOn { get; private set; }

    private float _previousVolume;

    private void Awake()
    {
        _previousVolume = GetVolume();
    }

    public float GetVolume()
    {
        return Mathf.Pow(LOG_BASE, GetMixerVolume() / DECIBEL_FACTOR);
    }

    public void SetVolume(float value)
    {
        _previousVolume = GetVolume();

        _audioMixer.SetFloat(_volumeParameter, DECIBEL_FACTOR
                                               * Mathf.Log10(value));
    }

    public void EnableAudio(bool enable)
    {
        IsOn = enable;
        SetVolume(enable ? _previousVolume : MIN_VOLUME_RATE);
    }

    private float GetMixerVolume()
    {
        if (_audioMixer.GetFloat(_volumeParameter, out float volume))
        {
            return volume;
        }

        return 0f;
    }
}