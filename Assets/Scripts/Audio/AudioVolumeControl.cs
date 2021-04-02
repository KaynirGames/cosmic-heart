using UnityEngine;
using UnityEngine.Audio;

public class AudioVolumeControl : MonoBehaviour
{
    private const int LOG_BASE = 10;
    private const int DECIBEL_FACTOR = 20;

    [SerializeField] private string _volumeParameter = "MasterVolume";
    [SerializeField] private AudioMixer _audioMixer = null;

    public float GetVolume()
    {
        if (_audioMixer.GetFloat(_volumeParameter, out float volume))
        {
            return volume;
        }

        return 0f;
    }

    public float GetVolumePercentage()
    {
        return Mathf.Pow(LOG_BASE, GetVolume() / DECIBEL_FACTOR);
    }

    public void SetVolume(float value)
    {
        _audioMixer.SetFloat(_volumeParameter,
                             DECIBEL_FACTOR * Mathf.Log10(value));
    }
}
