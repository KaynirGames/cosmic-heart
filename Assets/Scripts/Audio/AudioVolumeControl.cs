using UnityEngine;
using UnityEngine.Audio;

public class AudioVolumeControl : MonoBehaviour
{
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
        return Mathf.Pow(10, GetVolume() / 20);
    }

    public void SetVolume(float value)
    {
        _audioMixer.SetFloat(_volumeParameter,
                             20 * Mathf.Log10(value));
    }
}
